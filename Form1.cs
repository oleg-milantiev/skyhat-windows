﻿using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

/* TODO
 * debug флаг в конфиге / регистри / ...
 * installer icon
 * release, не debug
 * telegram - https://github.com/Marfusios/websocket-client
 */

using Microsoft.Win32;

namespace SkyHat
{
    public partial class Form1 : Form
    {

        private const int DEBUG_INFO = 1;
        private const int DEBUG_VERBOSE = 2;
        private const int DEBUG_DEBUG = 3;

        private const int DEBUG = DEBUG_DEBUG;

        private SerialPort serial = new SerialPort();
        private RegistryKey registry;

        private System.Threading.Timer timerSerial;
//        private System.Threading.Timer timerTelegram;

        private bool telegramEnabled;
        private string telegramUrl, telegramHash;

        private int connectingTimeout;

        #region Form Build
        public Form1()
        {
            InitializeComponent();
        }

        private void log(int level, string function, string message = null)
        {
            if (DEBUG < level)
            {
                return;
            }

            string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    "mo\\SkyHat"
                );

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += "\\log.txt";

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path)) { }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString() +"["+ level +"]: "+ function +(message != null ? ("\t"+ message) : ""));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log(DEBUG_INFO, "Form_Load", "start");

            comPort.Items.Clear();
            comPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            log(DEBUG_DEBUG, "Form_Load", "Read ports: "+ comPort.Items.Count);

            registry = Registry.CurrentUser.CreateSubKey("SOFTWARE\\mo\\SkyHat");

            readConfig();

            lightPresetRefresh();

            if (registry.GetValue("comPort", "").ToString() != "")
            {
                string portName = registry.GetValue("comPort", "").ToString();

                log(DEBUG_VERBOSE, "Form_Load", "Setting active port: "+ portName);
                comPort.SelectedItem = portName;
            }

            timerSerial = new System.Threading.Timer(_ => timerSerial_Tick(), null, 0, 100); // 10 раза в сек
            //timerTelegram = new System.Threading.Timer(_ => timerTelegram_Tick(), null, 0, 10000); // раз в 10 сек

            log(DEBUG_INFO, "Form_Load", "finish");
        }
        #endregion

        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            log(DEBUG_VERBOSE, "comPort_SelectedIndexChanged");
            
            registry.SetValue("comPort", comPort.SelectedItem.ToString());

            SerialConnect();
        }


        #region Serial

        private void serial_DataReceived_EEPROM_Invoke(byte [] serialBuf)
        {
            log(DEBUG_DEBUG, "serial_DataReceived_EEPROM_Invoke", "start");

            connectingTimeout = -1; // drop initial connection timeout event

            partLeft.Checked = (char)serialBuf[1] == 'l';
            partRight.Checked = (char)serialBuf[1] == 'r';
            partBoth.Checked = (char)serialBuf[1] == 'b';

            firstLeft.Checked = (char)serialBuf[2] == 'l';
            firstRight.Checked = (char)serialBuf[2] == 'r';

            timeoutLeft.Value = serialBuf[3] > 254 ? 254 : serialBuf[3];
            timeoutRight.Value = serialBuf[4] > 254 ? 254 : serialBuf[4];

            thresholdLeft.Value = serialBuf[5] > 254 ? 254 : serialBuf[5];
            thresholdRight.Value = serialBuf[6] > 254 ? 254 : serialBuf[6];

            maxSpeedLeft.Value = serialBuf[7] > 254 ? 254 :
                (serialBuf[7] < 10 ? 10 : serialBuf[7]);
            maxSpeedRight.Value = serialBuf[8] > 254 ? 254 :
                (serialBuf[8] < 10 ? 10 : serialBuf[8]);

            velocityLeft.Value = serialBuf[9] > 254 ? 254 :
                (serialBuf[9] < 1 ? 1 : serialBuf[9]);
            velocityRight.Value = serialBuf[10] > 254 ? 254 :
                (serialBuf[10] < 1 ? 1 : serialBuf[10]);

            reverseLeft.Checked = serialBuf[11] == 1;
            reverseRight.Checked = serialBuf[12] == 1;

            lightPreset1.Enabled = true;
            lightPreset2.Enabled = true;
            lightPreset3.Enabled = true;
            lightPreset4.Enabled = true;
            lightPreset5.Enabled = true;
            saveLightPreset1.Enabled = true;
            saveLightPreset2.Enabled = true;
            saveLightPreset3.Enabled = true;
            saveLightPreset4.Enabled = true;
            saveLightPreset5.Enabled = true;

            partLeft.Enabled = true;
            partRight.Enabled = true;
            partBoth.Enabled = true;

            firstLeft.Enabled = true;
            firstRight.Enabled = true;

            timeoutLeft.Enabled = true;
            timeoutRight.Enabled = true;
            thresholdLeft.Enabled = true;
            thresholdRight.Enabled = true;
            maxSpeedLeft.Enabled = true;
            maxSpeedRight.Enabled = true;
            velocityLeft.Enabled = true;
            velocityRight.Enabled = true;
            reverseLeft.Enabled = true;
            reverseRight.Enabled = true;

            moveOpenDefault.Enabled = true;
            moveCloseDefault.Enabled = true;
            moveOpenLeft.Enabled = true;
            moveCloseLeft.Enabled = true;
            moveOpenRight.Enabled = true;
            moveCloseRight.Enabled = true;
            moveOpenBoth.Enabled = true;
            moveCloseBoth.Enabled = true;
            moveAbort.Enabled = true;
            moveAbortDefault.Enabled = true;

            status.Text = "Connected";
            status.BackColor = System.Drawing.Color.LightGreen;

            settingsSave.Enabled = false;

            log(DEBUG_DEBUG, "serial_DataReceived_EEPROM_Invoke", "finish");
        }

        private void serial_DataReceived_Get_Invoke(byte [] serialBuf)
        {
            log(DEBUG_DEBUG, "serial_DataReceived_Get_Invoke", "start");

            light.BackColor = System.Drawing.Color.FromArgb(serialBuf[7], serialBuf[7], serialBuf[7]);
            statusLight.Text = serialBuf[7].ToString();

            /* debug
                status.Text = serialBuf[1].ToString() + "," +
                    serialBuf[2].ToString() + "," +
                    serialBuf[3].ToString() + "," +
                    serialBuf[4].ToString() + "," +
                    serialBuf[5].ToString() + "," +
                    serialBuf[6].ToString() + "," +
                    serialBuf[7].ToString() + "," +
                    serialBuf[8].ToString() + "," +
                    serialBuf[9].ToString();
            */

            switch ((char)serialBuf[3])
            {
                case 'c':
                    statusHatLeft.Text = "Closing";
                    break;

                case 'g':
                    statusHatLeft.Text = "Waiting";
                    break;

                case 'o':
                    statusHatLeft.Text = "Opening";
                    break;

                default:
                    switch ((char)serialBuf[5])
                    {
                        case 'c':
                            statusHatLeft.Text = "Close";

                            if (status.BackColor == System.Drawing.Color.LightYellow)
                            {
                                status.Text = "";
                                status.BackColor = System.Drawing.Color.LightGreen;
                            }

                            break;

                        case 'o':
                            statusHatLeft.Text = "Open";

                            if (status.BackColor == System.Drawing.Color.LightYellow)
                            {
                                status.Text = "";
                                status.BackColor = System.Drawing.Color.LightGreen;
                            }
                            break;

                        default:
                            statusHatLeft.Text = "Unknown";
                            break;
                    }
                    break;
            }

            switch ((char)serialBuf[4])
            {
                case 'c':
                    statusHatRight.Text = "Closing";
                    break;

                case 'g':
                    statusHatRight.Text = "Waiting";
                    break;

                case 'o':
                    statusHatRight.Text = "Opening";
                    break;

                default:
                    switch ((char)serialBuf[6])
                    {
                        case 'c':
                            statusHatRight.Text = "Close";

                            if (status.BackColor == System.Drawing.Color.LightYellow)
                            {
                                status.Text = "";
                                status.BackColor = System.Drawing.Color.LightGreen;
                            }

                            break;

                        case 'o':
                            statusHatRight.Text = "Open";

                            if (status.BackColor == System.Drawing.Color.LightYellow)
                            {
                                status.Text = "";
                                status.BackColor = System.Drawing.Color.LightGreen;
                            }
                            break;

                        default:
                            statusHatRight.Text = "Unknown";
                            break;
                    }
                    break;
            }

            log(DEBUG_DEBUG, "serial_DataReceived_Get_Invoke", "finish");
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            log(DEBUG_DEBUG, "serial_DataReceived", "start");

            if ((serialSendLast != null) && (serialSendLast.Length > 1))
            {
                switch (serialSendLast[1])
                {
                    case (byte)'g':
                        log(DEBUG_DEBUG, "serial_DataReceived", "GET - start");

                        byte[] serialBuferGet = new byte[11];

                        try
                        {
                            serial.Read(serialBuferGet, 0, serialBuferGet.Length);
                            log(DEBUG_DEBUG, "serial_DataReceived", "GET - read data");

                            //0 byte start = 0xEE
                            //1 byte, current: Текущий ток в ADU датчика
                            //2 byte, timeout: Текущий таймаут в секундах (через сколько секунд мотор вырубится с ошибкой)
                            //3 byte, moveLeftTo: Куда движется левая створка ('c', 'o' или 's')
                            //4 byte, moveRightTo: Куда движется правая створка ('c', 'o' или 's')
                            //5 byte, statusLeft: Статус левой крышки, см. ниже
                            //6 byte, statusRight: Статус правой крышки, см. ниже
                            //7 byte, light: Текущая яркость лампочки (0..255)
                            //8 byte, speedLeft: скорость левой крышки
                            //9 byte, speedRight: скорость левой крышки
                            //10 byte stop = 0x00

                            if ((serialBuferGet[0] == (byte)0xee) && (serialBuferGet[10] == (byte) 0))
                            {
                                log(DEBUG_DEBUG, "serial_DataReceived", "GET - read successful");

                                Invoke((MethodInvoker)(() =>
                                    serial_DataReceived_Get_Invoke(serialBuferGet)
                                ));
                            }
                        }
                        catch
                        {
                            log(DEBUG_DEBUG, "serial_DataReceived", "GET - read fail");

                            SerialDisconnect();
                        }
                        break;

                    case (byte)'e':
                        log(DEBUG_DEBUG, "serial_DataReceived", "EEPROM - start");

                        byte[] serialBuf = new byte[14];

                        serial.Read(serialBuf, 0, serialBuf.Length);
                        log(DEBUG_DEBUG, "serial_DataReceived", "EEPROM - read data");

                        if ((serialBuf[0] == (byte)0xee) && (serialBuf[13] == (byte)0))
                        {
                            log(DEBUG_DEBUG, "serial_DataReceived", "EEPROM - read successful");

                            Invoke((MethodInvoker)(() =>
                                serial_DataReceived_EEPROM_Invoke(serialBuf)
                            ));
                        }

                        //- byte start = 0xEE
                        //1 byte, part: какой мотор используется. Параметр: 'l' (левый), 'r' (правый), 'b' (оба по очереди).
                        //2 byte, first: какая крышка едет первой при открытии (при закрытии наоборот). Параметр: 'l' (левая, по-умолчанию) или 'r' (правая).
                        //3 byte, timeoutLeft: задание таймаута движения левой крышки в секундах. Параметр: число секунд (3, например)
                        //4 byte, timeoutRight: задание таймаута движения правой крышки в секундах. Параметр: число секунд (3, например)
                        //5 byte, thresholdLeft: задание порога срабатывания датчика тока при движении левого мотора. Параметр: число порога (25, например)
                        //6 byte, thresholdRight: задание порога срабатывания датчика тока при движении правого мотора. Параметр: число порога (25, например)
                        //7 byte, maxSpeedLeft: задание максимальной скорости левого мотора в ШИМ 0..255. Параметр: число скорости (255, например)
                        //8 byte, maxSpeedRight: задание максимальной скорости правого мотора в ШИМ 0..255. Параметр: число скорости (255, например)
                        //9 byte, velocityLeft: ускорение (скорость разгона) левого мотора. Параметр: число ускорения (5, например)
                        //10 byte, velocityRight: ускорение (скорость разгона) правого мотора. Параметр: число ускорения (5, например)
                        //11 byte, reverseLeft: реверс левого мотора (1 / 0)
                        //12 byte, reverseRight: реверс правого мотора (1 / 0)
                        //- byte stop = 0x00

                        // todo а почему нет try / catch? и туда log(fail)

                        break;
                }
            }
        }

        private bool SerialConnect()
        {
            log(DEBUG_INFO, "SerialConnect", "start");

            if (serial.IsOpen)
            {
                log(DEBUG_DEBUG, "SerialConnect", "isOpen - disconnect");
            
                SerialDisconnect();
            }

            serial = new SerialPort();
            connectingTimeout = 5;

            try
            {
                string port = registry.GetValue("comPort", "").ToString();

                log(DEBUG_DEBUG, "SerialConnect", "try to connect to "+ port);

                serial.PortName = port;
                serial.BaudRate = 115200;
                serial.Parity = Parity.None;
                serial.DataBits = 8;
                serial.StopBits = StopBits.One;
                serial.ReadBufferSize = 100;
                serial.DataReceived += serial_DataReceived;

                if (string.IsNullOrEmpty(serial.PortName))
                {
                    MessageBox.Show("Choose COM port", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                serial.DtrEnable = true;
                serial.RtsEnable = true;

                serial.ReadTimeout = 5000;

                serial.Open();

                Thread.Sleep(2000);

                //SerialCommand_Get();
                log(DEBUG_DEBUG, "SerialConnect", "try to connect - finish");

                if (!serialSend(new byte[] { (byte)'c', (byte)'e' }))
                {
                    log(DEBUG_DEBUG, "SerialConnect", "try to connect - fail send EEPROM get");

                    return false;
                }

                return true;
            }
            catch (UnauthorizedAccessException Ex)
            {
                log(DEBUG_VERBOSE, "SerialConnect", "fail - unauth");

                MessageBox.Show("Permission error opening COM port", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception Ex)
            {
                log(DEBUG_VERBOSE, "SerialConnect", "fail - exception: "+ Ex.Message);

                MessageBox.Show("Unknown error opening COM port: " + Ex.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (serial.IsOpen)
                {
                    SerialDisconnect();
                }

                return false;
            }

            MessageBox.Show("Error SkyHat link", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }

        private byte[] serialSendLast;

        private bool serialSend(byte[] package)
        {
            log(DEBUG_INFO, "SerialSend", "start");

            if (!serial.IsOpen)
            {
                log(DEBUG_VERBOSE, "SerialSend", "not is open");

                return false;
            }

            try
            {
                serial.Write(package, 0, package.Length);

                serialSendLast = package;

                log(DEBUG_DEBUG, "SerialSend", "sent succesful");

                return true;
            }
            catch (Exception Ex)
            {
                log(DEBUG_VERBOSE, "SerialSend", "fail: "+ Ex.Message);

                if (serial.IsOpen)
                {
                    log(DEBUG_DEBUG, "SerialSend", "fail - is open (try to disconnect)");

                    SerialDisconnect();
                }

                MessageBox.Show("Error sending command via COM port", "Sending command error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        }
        
        private void SerialDisconnect()
        {
            log(DEBUG_INFO, "SerialDisconnect", "start");

            if (serial.IsOpen)
            {
                try
                {
                    log(DEBUG_DEBUG, "SerialDisconnect", "isOpen - close()");

                    serial.Close();
                    serial.Dispose();
                }
                catch
                {
                }
            }

            Invoke((MethodInvoker)(() =>
                SerialDisconnectInvoke()
            ));
            
            log(DEBUG_VERBOSE, "SerialDisconnect", "finish");
        }
        #endregion

        private void SerialDisconnectInvoke()
        {
            log(DEBUG_DEBUG, "SerialDisconnectInvoke", "start");

            status.BackColor = System.Drawing.Color.LightPink;
            status.Text = "Disconnected";

            lightPreset1.Enabled = false;
            lightPreset2.Enabled = false;
            lightPreset3.Enabled = false;
            lightPreset4.Enabled = false;
            lightPreset5.Enabled = false;
            saveLightPreset1.Enabled = false;
            saveLightPreset2.Enabled = false;
            saveLightPreset3.Enabled = false;
            saveLightPreset4.Enabled = false;
            saveLightPreset5.Enabled = false;

            partLeft.Enabled = false;
            partRight.Enabled = false;
            partBoth.Enabled = false;

            firstLeft.Enabled = false;
            firstRight.Enabled = false;

            timeoutLeft.Enabled = false;
            timeoutRight.Enabled = false;
            thresholdLeft.Enabled = false;
            thresholdRight.Enabled = false;
            maxSpeedLeft.Enabled = false;
            maxSpeedRight.Enabled = false;
            velocityLeft.Enabled = false;
            velocityRight.Enabled = false;
            reverseLeft.Enabled = false;
            reverseRight.Enabled = false;

            settingsSave.Enabled = false;

            moveOpenDefault.Enabled = false;
            moveCloseDefault.Enabled = false;

            moveOpenLeft.Enabled = false;
            moveCloseLeft.Enabled = false;
            moveOpenRight.Enabled = false;
            moveCloseRight.Enabled = false;
            moveOpenBoth.Enabled = false;
            moveCloseBoth.Enabled = false;
            moveAbort.Enabled = false;
            moveAbortDefault.Enabled = false;

            log(DEBUG_DEBUG, "SerialDisconnectInvoke", "finish");
        }


        private void settingsSave_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void saveSettings()
        {
            log(DEBUG_DEBUG, "saveSettings", "start");

            timerSend = new byte[] { (byte)'c', (byte)'s',
                (byte)(partLeft.Checked ? 'l' : (partRight.Checked ? 'r' : 'b')),
                (byte)(firstLeft.Checked ? 'l' : 'r'),
                (byte)timeoutLeft.Value,
                (byte)timeoutRight.Value,
                (byte)thresholdLeft.Value,
                (byte)thresholdRight.Value,
                (byte)maxSpeedLeft.Value,
                (byte)maxSpeedRight.Value,
                (byte)velocityLeft.Value,
                (byte)velocityRight.Value,
                (byte)(reverseLeft.Checked ? 1 : 0),
                (byte)(reverseRight.Checked ? 1 : 0),
            };

            timerText = "Settings saved successfully";
            timerColor = System.Drawing.Color.LightGreen;

            settingsSave.Enabled = false;

            log(DEBUG_DEBUG, "saveSettings", "finish");
        }

        private bool confirmSave()
        {
            if (settingsSave.Enabled)
            {
                DialogResult result = MessageBox.Show("Settings are changed. Save settings before action?", "Save settings confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        saveSettings();
                        break;

                    case DialogResult.No:
                        //SerialCommand_Get();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            return true;
        }

        private void moveOpen(byte ch)
        {
            log(DEBUG_VERBOSE, "moveOpen", "start");

            if (!confirmSave())
            {
                return;
            }

            timerSend = new byte[] { (byte)'c', (byte)'o', ch };
            timerText = "Start opening";
            timerColor = System.Drawing.Color.LightYellow;
            
            brightness.Value = 0;

            log(DEBUG_DEBUG, "moveOpen", "finish");
        }

        private void moveClose(byte ch)
        {
            log(DEBUG_VERBOSE, "moveClose", "start");

            if (!confirmSave())
            {
                return;
            }

            timerSend = new byte[] { (byte)'c', (byte)'c', ch };
            timerText = "Start closing";
            timerColor = System.Drawing.Color.LightYellow;

            brightness.Value = 0;

            log(DEBUG_VERBOSE, "moveClose", "finish");
        }

        private void moveAbort_Click(object sender, EventArgs e)
        {
            log(DEBUG_VERBOSE, "moveAbort", "start");

            if (!confirmSave())
            {
                return;
            }

            timerText = "Abort movement";
            timerSend = new byte[] { (byte)'c', (byte)'a' };

            brightness.Value = 0;

            log(DEBUG_VERBOSE, "moveAbort", "finish");
        }

        private void settingChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // todo другой адрес
                System.Diagnostics.Process.Start("http://astro.milantiev.com/shop");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void logo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // todo о, а что там? :)
                System.Diagnostics.Process.Start("http://astro.milantiev.com/product/skyhat/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialDisconnect();
            System.Environment.Exit(0);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();

            readConfig();
        }

        private void readConfig()
        {
            partLeft.Text = firstLeft.Text = reverseLeft.Text = labelLeft.Text = registry.GetValue("nameLeft", "Left").ToString();
            partRight.Text = firstRight.Text = reverseRight.Text = labelRight.Text = registry.GetValue("nameRight", "Right").ToString();

            telegramEnabled = registry.GetValue("telegramEnabled", "0").ToString() == "1";
            telegramUrl = registry.GetValue("telegramUrl", "").ToString();
            telegramHash = registry.GetValue("telegramHash", "").ToString();

            log(DEBUG_DEBUG, "readConfig");
        }

        #region Light
        private void brightness_Scroll(object sender, EventArgs e)
        {
            lightSet();
        }

        private void lightSet()
        {
            timerSend = new byte[] { (byte)'c', (byte)'l', (byte)brightness.Value };
            timerText = "Light is tuned to " + brightness.Value.ToString();
        }

        private void saveLightPreset(int no)
        {
            registry.SetValue("lightPreset" + no.ToString(), brightness.Value);
            lightPresetRefresh();
        }

        private void lightPresetRefresh()
        {
            lightPreset1.Text = registry.GetValue("lightPreset1", "[empty]").ToString();
            lightPreset1.Enabled = saveLightPreset1.Enabled && lightPreset1.Text != "[empty]";
            lightPreset2.Text = registry.GetValue("lightPreset2", "[empty]").ToString();
            lightPreset2.Enabled = saveLightPreset2.Enabled && lightPreset2.Text != "[empty]";
            lightPreset3.Text = registry.GetValue("lightPreset3", "[empty]").ToString();
            lightPreset3.Enabled = saveLightPreset3.Enabled && lightPreset3.Text != "[empty]";
            lightPreset4.Text = registry.GetValue("lightPreset4", "[empty]").ToString();
            lightPreset4.Enabled = saveLightPreset4.Enabled && lightPreset4.Text != "[empty]";
            lightPreset5.Text = registry.GetValue("lightPreset5", "[empty]").ToString();
            lightPreset5.Enabled = saveLightPreset5.Enabled && lightPreset5.Text != "[empty]";

            log(DEBUG_DEBUG, "lightPresetRefresh");
        }

        private void lightPreset(int no)
        {
            brightness.Value = (int)registry.GetValue("lightPreset"+ no.ToString(), 0);
            lightSet();
        }
        #endregion

        #region Serial Buttons
        private void moveOpen_Click(object sender, EventArgs e)
        {
            moveOpen((byte)'a');
        }

        private void moveClose_Click(object sender, EventArgs e)
        {
            moveClose((byte)'a');
        }

        private void saveLightPreset1_Click(object sender, EventArgs e)
        {
            saveLightPreset(1);
        }

        private void saveLightPreset2_Click(object sender, EventArgs e)
        {
            saveLightPreset(2);
        }

        private void saveLightPreset3_Click(object sender, EventArgs e)
        {
            saveLightPreset(3);
        }

        private void saveLightPreset4_Click(object sender, EventArgs e)
        {
            saveLightPreset(4);
        }

        private void saveLightPreset5_Click(object sender, EventArgs e)
        {
            saveLightPreset(5);
        }

        private void lightPreset1_Click(object sender, EventArgs e)
        {
            lightPreset(1);
        }

        private void lightPreset2_Click(object sender, EventArgs e)
        {
            lightPreset(2);
        }

        private void lightPreset3_Click(object sender, EventArgs e)
        {
            lightPreset(3);
        }

        private void lightPreset4_Click(object sender, EventArgs e)
        {
            lightPreset(4);
        }

        private void lightPreset5_Click(object sender, EventArgs e)
        {
            lightPreset(5);
        }

        private void moveOpenLeft_Click(object sender, EventArgs e)
        {
            moveOpen((byte)'l');
        }

        private void moveCloseLeft_Click(object sender, EventArgs e)
        {
            moveClose((byte)'l');
        }

        private void moveOpenRight_Click(object sender, EventArgs e)
        {
            moveOpen((byte)'r');
        }

        private void moveCloseRight_Click(object sender, EventArgs e)
        {
            moveClose((byte)'r');
        }

        private void moveOpenBoth_Click(object sender, EventArgs e)
        {
            moveOpen((byte)'b');
        }

        private void moveCloseBoth_Click(object sender, EventArgs e)
        {
            moveClose((byte)'b');
        }
        #endregion

        private int timerCountGet = 0;
        private byte[] timerSend;
        private string timerText;
        private System.Drawing.Color timerColor;

        private void timerSerial_Tick()
        {
//            log(DEBUG_DEBUG, "timerSerial_Tick", "uh..");

            if (!serial.IsOpen)
            {
                try
                {
                    Invoke((MethodInvoker)(() =>
                        status.Text = "Not connected"
                    ));
                    Invoke((MethodInvoker)(() =>
                        status.BackColor = System.Drawing.Color.LightPink
                    ));
                }
                catch (Exception)
                {
                    // ignore
                }

                return;
            }

            if (timerSend != null)
            {
                log(DEBUG_VERBOSE, "timerSerial_Tick", "timerSend is not null");

                if (serialSend(timerSend))
                {
                    log(DEBUG_VERBOSE, "timerSerial_Tick", "serialSend succesful");

                    Invoke((MethodInvoker)(() =>
                        status.Text = timerText
                    ));
                    Invoke((MethodInvoker)(() =>
                        status.BackColor = timerColor
                    ));
                }
                // todo else ошибка?

                timerSend = null;
            }

            // get раз в 1 сек в том же потоке, что и send (всё общение с портом в одном потоке последовательно)
            if (++timerCountGet == 10)
            {
                timerCountGet = 0;

                if (--connectingTimeout > 0)
                {
                    log(DEBUG_DEBUG, "timerSerial_Tick", "connection timeout - waiting: "+ connectingTimeout);

                    return;
                }

                if (connectingTimeout == 0)
                {
                    log(DEBUG_VERBOSE, "timerSerial_Tick", "connection timeout");

                    MessageBox.Show("No SkyHat at port " + serial.PortName + ". Please choose another", "Choose COM port", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    SerialDisconnect();

                    return;
                }

                if (!serialSend(new byte[] { (byte)'c', (byte)'g' }))
                {
                    log(DEBUG_VERBOSE, "timerSerial_Tick", "GET fail");

                    // todo а что делать?
                    return;
                }
            }

        }

        /*
        // todo как будет готово наверху, допишу обработку задач из телеги
        private void timerTelegram_Tick()
        {
            // todo websocket

            if (!telegramEnabled || (telegramUrl == "") || (telegramHash == "") || !serial.IsOpen)
            {
                return;
            }

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var webClient = new WebClient();

//            Telegram response = JsonConvert.DeserializeObject<Telegram>(
//                webClient.DownloadString(telegramUrl + "/" + telegramHash)
//                );

//            response.command = "a";

        }
        */
    }
}

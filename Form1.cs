using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Microsoft.Win32;

using ASCOM;
using ASCOM.Utilities;

namespace SkyHat
{
    public partial class Form1 : Form
    {

        private Serial serial = new Serial();
        private RegistryKey registry;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comPort.Items.Clear();
            comPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());      // use System.IO because it's static

            registry = Registry.CurrentUser.CreateSubKey("SOFTWARE\\mo\\SkyHat");

            string move = registry.GetValue("move", "").ToString();

            if (move != "")
            {
                moveLeft.Checked = (move == "l");
                moveRight.Checked = (move == "r");
                moveBoth.Checked = (move == "a");
            }

            if (registry.GetValue("comPort", "").ToString() != "")
            {
                comPort.SelectedItem = registry.GetValue("comPort", "").ToString();
            }

            moveLeft.Text = firstLeft.Text = registry.GetValue("nameLeft", "Left").ToString();
            moveRight.Text = firstRight.Text = registry.GetValue("nameRight", "Right").ToString();
        }

        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            registry.SetValue("comPort", comPort.SelectedItem.ToString());

            SerialConnect();
        }


        #region Serial

        /// <summary>
        /// Отсылает команду GET на устройство. Данные помещает в this.*
        /// </summary>
        private void SerialCommand_Get()
        {
            if (!serialSend(new byte[] { (byte)'c', (byte)'g' }))
                return;

            byte[] serialBuf = new byte[8];

            try
            {
                serialBuf = serial.ReceiveCountedBinary(8);
                
                light.BackColor = System.Drawing.Color.FromArgb(serialBuf[7], serialBuf[7], serialBuf[7]);
                statusLight.Text = (serialBuf[7] > 0) ? "On" : "Off";

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
                //- byte stop = 0x00

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

            }
            catch (Exception Ex)
            {
                SerialDisconnect();
            }
            
        }


        private bool SerialConnect()
        {
            if (serial.Connected)
            {
                SerialDisconnect();
            }

            serial = new Serial();

            try
            {
                serial.PortName = registry.GetValue("comPort", "").ToString();
                serial.Speed = SerialSpeed.ps115200;

                if (string.IsNullOrEmpty(serial.PortName))
                {
                    MessageBox.Show("Choose COM port", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }

                serial.DTREnable = true;
                serial.RTSEnable = true;

                serial.ReceiveTimeout = 5;
                serial.ReceiveTimeoutMs = 5000;

                serial.Connected = true;

                Thread.Sleep(2000);

                SerialCommand_Get();

                if (!serialSend(new byte[] { (byte)'c', (byte)'e' }))
                    return false;
                
                byte[] serialBuf = new byte[7];

                serialBuf = serial.ReceiveCountedBinary(8);

                //- byte start = 0xEE
                //1 byte, first: какая крышка едет первой при открытии (при закрытии наоборот). Параметр: 'l' (левая, по-умолчанию) или 'r' (правая).
                //2 byte, timeout: задание таймаута движения крышки в секундах. Параметр: число секунд (3, например)
                //3 byte, brightness: яркость EL Panel
                //4 byte, threshold: задание порога срабатывания датчика тока. Параметр: число порога (25, например)
                //5 byte, maxSpeed: задание максимальной скорости мотора в ШИМ 0..255. Параметр: число скорости (255, например)
                //6 byte, velocity: ускорение (скорость разгона). Параметр: число ускорения (5, например)
                //- byte stop = 0x00

                firstLeft.Checked = (char)serialBuf[1] == 'l';
                firstRight.Checked = (char)serialBuf[1] == 'r';
                timeout.Value    = serialBuf[2] > 254 ? 254 : serialBuf[2];
                brightness.Value = serialBuf[3] > 254 ? 254 : serialBuf[3];
                threshold.Value  = serialBuf[4] > 254 ? 254 : serialBuf[4];
                maxSpeed.Value   = serialBuf[5] > 254 ? 254 : serialBuf[5];
                velocity.Value   = serialBuf[6] > 254 ? 254 : serialBuf[6];

                firstLeft.Enabled  = true;
                firstRight.Enabled = true;

                moveLeft.Enabled  = true;
                moveRight.Enabled = true;
                moveBoth.Enabled  = true;

                timeout.Enabled    = true;
                brightness.Enabled = true;
                threshold.Enabled  = true;
                maxSpeed.Enabled   = true;
                velocity.Enabled   = true;

                lightOn.Enabled = true;
                lightOff.Enabled = true;

                moveOpen.Enabled = true;
                moveClose.Enabled = true;
                moveAbort.Enabled = true;

                status.Text = "Connected";
                status.BackColor = System.Drawing.Color.LightGreen;
                timer1.Enabled = true;

                settingsSave.Enabled = false;

                return true;
            }
            catch (UnauthorizedAccessException Ex)
            {
                serial.DTREnable = false;
                serial.RTSEnable = false;

                MessageBox.Show("Permission error opening COM port", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Unknown error opening COM port: " + Ex.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                serial.Connected = false;
                serial.DTREnable = false;
                serial.RTSEnable = false;

                return false;
            }

            MessageBox.Show("Error SkyHat link", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }

        
        private bool serialSend(byte[] package)
        {
            if (!serial.Connected)
                return false;

            try
            {
                serial.ClearBuffers();
            }
            catch (Exception Ex)
            {
                serial.Connected = false;
                MessageBox.Show("Error sending command via COM port", "Sendgin command error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                serial.TransmitBinary(package);

                return true;
            }
            catch (Exception Ex)
            {
                if (serial.Connected)
                {
                    serial.Connected = false;
                }

                MessageBox.Show("Error sending command via COM port", "Sendgin command error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        }
        
        
        private void SerialDisconnect()
        {
            if (serial.Connected)
            {
                serial.Connected = false;
            }

            serial.DTREnable = false;
            serial.RTSEnable = false;
            serial.Dispose();
            
            status.BackColor = System.Drawing.Color.LightPink;
            status.Text = "Disconnected";

            moveLeft.Enabled = false;
            moveRight.Enabled = false;
            moveBoth.Enabled = false;

            timeout.Enabled = false;
            brightness.Enabled = false;
            threshold.Enabled = false;
            maxSpeed.Enabled = false;
            velocity.Enabled = false;

            settingsSave.Enabled = false;

            lightOn.Enabled = false;
            lightOff.Enabled = false;

            moveOpen.Enabled = false;
            moveClose.Enabled = false;
            moveAbort.Enabled = false;

            timer1.Enabled = false;
        }
        #endregion

        private void settingsSave_Click(object sender, EventArgs e)
        {
            saveSettings();
        }


        private void saveSettings()
        {
            if (serialSend(new byte[] { (byte)'c', (byte)'s', 
                (byte)(firstLeft.Checked ? 'l' : 'r'),
                (byte)timeout.Value,
                (byte)brightness.Value,
                (byte)threshold.Value,
                (byte)maxSpeed.Value,
                (byte)velocity.Value,
            }))
            {
                status.Text = "Settings saved successfully";
            }

            registry.SetValue("move",
                moveLeft.Checked
                    ? "l"
                    : (moveRight.Checked
                        ? "r"
                        : "a"
                        )
            );

            settingsSave.Enabled = false;
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
                        SerialCommand_Get();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            return true;
        }

        private void lightOn_Click(object sender, EventArgs e)
        {
            if (!confirmSave())
            {
                return;
            }
            
            if (serialSend(new byte[] { (byte)'c', (byte)'l', (byte)'1'}))
            {
                status.Text = "Light is switched on";

                SerialCommand_Get();
            }
        }

        private void lightOff_Click(object sender, EventArgs e)
        {
            if (!confirmSave())
            {
                return;
            }
            
            if (serialSend(new byte[] { (byte)'c', (byte)'l', (byte)'0' }))
            {
                status.Text = "Light is switched off";

                SerialCommand_Get();
            }
        }

        private void gap_ValueChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void timeout_ValueChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void threshold_ValueChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void maxSpeed_ValueChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void velocity_ValueChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void firstLeft_CheckedChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void firstRight_CheckedChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void moveOpen_Click(object sender, EventArgs e)
        {
            if (!confirmSave())
            {
                return;
            }

            if (serialSend(new byte[] { (byte)'c', (byte)'o', (byte)(moveLeft.Checked ? 'l' : (moveRight.Checked ? 'r' : 'a')) }))
            {
                status.Text = "Start opening";
                status.BackColor = System.Drawing.Color.LightYellow;

                SerialCommand_Get();
            }
        }

        private void moveClose_Click(object sender, EventArgs e)
        {
            if (!confirmSave())
            {
                return;
            }
            
            if (serialSend(new byte[] { (byte)'c', (byte)'c', (byte)(moveLeft.Checked ? 'l' : (moveRight.Checked ? 'r' : 'a')) }))
            {
                status.Text = "Start closing";
                status.BackColor = System.Drawing.Color.LightYellow;

                SerialCommand_Get();
            }
        }

        private void moveAbort_Click(object sender, EventArgs e)
        {
            if (!confirmSave())
            {
                return;
            }
            
            if (serialSend(new byte[] { (byte)'c', (byte)'a' }))
            {
                SerialCommand_Get();

                status.Text = "Abort movement";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serial.Connected)
            {
                status.Text = "Not connected";
                status.BackColor = System.Drawing.Color.LightPink;
                return;
            }

            SerialCommand_Get();
        }

        private void moveLeft_CheckedChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void moveRight_CheckedChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void moveBoth_CheckedChanged(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void brightness_Scroll(object sender, EventArgs e)
        {
            settingsSave.Enabled = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
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

            moveLeft.Text = firstLeft.Text = registry.GetValue("nameLeft", "Left").ToString();
            moveRight.Text = firstRight.Text = registry.GetValue("nameRight", "Right").ToString();
        }

    }
}

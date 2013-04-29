using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace balanza_Calidad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfPuertocom opciones = new ConfPuertocom();
         
            if (opciones.ShowDialog() == DialogResult.OK)
            {
                                    serialPort1.PortName = opciones.port;
                    serialPort1.BaudRate = opciones.baudios;
                    serialPort1.DataBits = opciones.nbits;
                    if(opciones.bitstop==1)
                        serialPort1.StopBits = StopBits.One;
                    else if (opciones.bitstop == 2)
                        serialPort1.StopBits = StopBits.Two;
                    switch (opciones.paridad)
                    {
                        case 0:
                            serialPort1.Parity = Parity.None;
                            break;
                        case 1:
                            serialPort1.Parity = Parity.Even;
                            break;
                        case 2:
                            serialPort1.Parity = Parity.Odd;
                            break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(textBox1.Text.ToString());
            }
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (string PuertoCom in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                if (serialPort1.PortName == PuertoCom) 
                {
                    flag = true;
                }
            }
            if (flag == false) 
            {
                ConfPuertocom opciones = new ConfPuertocom();

                if (opciones.ShowDialog() == DialogResult.OK)
                {
                    serialPort1.PortName = opciones.port;
                    serialPort1.BaudRate = opciones.baudios;
                    serialPort1.DataBits = opciones.nbits;
                    if(opciones.bitstop==1)
                        serialPort1.StopBits = StopBits.One;
                    else if (opciones.bitstop == 2)
                        serialPort1.StopBits = StopBits.Two;
                    switch (opciones.paridad)
                    {
                        case 0:
                            serialPort1.Parity = Parity.None;
                            break;
                        case 1:
                            serialPort1.Parity = Parity.Even;
                            break;
                        case 2:
                            serialPort1.Parity = Parity.Odd;
                            break;
                    }
                    flag = true;
                }
            }
            if (flag == true)
            {
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex) { MessageBox.Show("Error al abrir el puerto serie. " + ex.Message, "Atencion!!"); }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            richTextBox1.AppendText(serialPort1.ReadLine());
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }
    }
}

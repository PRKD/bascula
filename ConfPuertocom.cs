using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace balanza_Calidad
{
    public partial class ConfPuertocom : Form
    {
        public ConfPuertocom()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 3;
            foreach (string PuertoCom in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                comboBox1.Items.Add(PuertoCom);

            }
            comboBox1.SelectedIndex = 0;
        }

        public string port { get; set; }
        public int baudios { get; set; }
        public int nbits { get; set; }
        public int bitstop { get; set; }
        public int paridad { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            port = comboBox1.SelectedItem.ToString();
            baudios = Convert.ToInt32(comboBox2.SelectedItem);
              if (radioButton1.Checked == true)
                  nbits = 7;
            if (radioButton2.Checked == true)
                nbits = 8;
             if (radioButton4.Checked == true)
                 bitstop = 1;
            if (radioButton3.Checked == true)
                bitstop = 2;
            if (radioButton6.Checked == true)
                paridad = 0;
            if (radioButton5.Checked == true)
                paridad = 1;//"Even";
            if (radioButton7.Checked == true)
                paridad = 2;// "Odd";
            this.DialogResult = DialogResult.OK;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
               
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                radioButton3.Checked = false;
                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton4.Checked = false;
               
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                radioButton7.Checked = false;
                radioButton5.Checked = false;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                radioButton7.Checked = false;
                radioButton6.Checked = false;
            }

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                radioButton6.Checked = false;
                radioButton5.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

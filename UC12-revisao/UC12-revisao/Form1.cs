using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC12_revisao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListaESTADOS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";


            if (radioButton1.Checked) 
            {
                MessageBox.Show("1"); 
            } 
            if (radioButton2.Checked)
            {
                MessageBox.Show("2");
            }
            if (radioButton3.Checked)
            {
                MessageBox.Show("3");
            }
            if (radioButton4.Checked)
            {
                MessageBox.Show("4");
            }
            if (radioButton5.Checked)
            {
                MessageBox.Show("5");
            }
            if(radioButton6.Checked)
            {
                MessageBox.Show("6");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "insira seu nome")
            {
                textBox1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "insira seu nome";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; 
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            { 
                radioButton1.Enabled = false;  
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;   
                radioButton6.Enabled = false;
            } else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
            }

        }

        private void ListaESTADOS()
        {
            comboBox1.Items.Add("AC");
            comboBox1.Items.Add("AL")
        }

       
    }

}

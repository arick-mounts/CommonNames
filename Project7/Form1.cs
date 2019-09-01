using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project7
{
    public partial class Form1 : Form
    {
        /*
         * This program prompts the user to enter a name, and checks the name against a list of common child names to see if it is a common name
         * C# @ TCC
         * Arick Mounts
         */

        string[] girlNames = new string[200];
        string[] boyNames = new string[200];

        public Form1()
        {
            InitializeComponent();
            readFile("../../BoyNames.txt" , boyNames);
            readFile("../../GirlNames.txt", girlNames);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            Boolean girl = false, boy = false;
            if (checkBox1.Checked)
            {
                for (int i = 0; i < 200; i++ )
                {
                    if (boyNames[i].ToLower() == input.ToLower())
                    {
                        boy = true;
                    }
                }
            }if (checkBox2.Checked)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (girlNames[i].ToLower() == input.ToLower())
                    {
                        girl = true;
                    }
                }
            }

            if (!boy || !girl)
            {
                textBox3.Text = input + " in not one of the two hundred most popular names for boys or girls.";
            }
            if (boy)
            {
                textBox3.Text = input + " is one of the two hundred most popular names for boys.  ";
            }
            if (girl)
            {
                textBox3.Text += input + " is one of the two hundred most popular names for girl.  ";
            }
        }
        public void readFile(string fileName, string[] arr)
        {
            try
            {
                int index = 0;
                StreamReader inputFile;
                inputFile = File.OpenText(fileName);

                while (index < 200 && !inputFile.EndOfStream)
                {
                    arr[index] = inputFile.ReadLine();
                    index++;
                }
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}

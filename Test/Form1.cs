using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            label1.Visible = false;
            label2.Visible = false;
            int x = Convert.ToInt32(numericUpDown1.Value);
            int[] poleN = new int[x];
            char[] poleznaku = new char[x];
            int prvnivyskyt = 0;
            int poslednivyskyt = 0;
            bool vyskyt = false;
            for (int i = 0; i < x; i++)
            {
                poleN[i] = rng.Next(32, 128);
                if (poleN[i] == 87)
                {
                    if (vyskyt == false)
                    {
                        prvnivyskyt = i + 1;
                    }
                    poslednivyskyt = i + 1;
                    vyskyt = true;
                }
            }
            foreach (int nahodne in poleN)
            {
                listBox1.Items.Add((char)nahodne);
            }
            for (int i = 0; i < x; i++)
            {
                if ((poleN[i] >= 48 && poleN[i] <= 57) || (poleN[i] >= 65 && poleN[i] <= 90) || (poleN[i] >= 97 && poleN[i] <= 122))
                {
                    poleznaku[i] = (char)poleN[i];
                }
            }
            foreach (char alfanumerik in poleznaku)
            {
                listBox3.Items.Add(alfanumerik);
            }
            if (vyskyt == true)
            {
                label1.Text = "První výskyt písmena W je na " + prvnivyskyt + ". řádku";
                label2.Text = "Poslední výskyt písmena W je na " + poslednivyskyt + ". řádku";
                label1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                label1.Text = "Písmeno W se nevygenerovalo";
                label1.Visible = true;
            }
            Array.Sort(poleN);
            Array.Reverse(poleN);
            foreach (int serazene in poleN)
            {
                listBox2.Items.Add((char)serazene);
            }
        }
}
}

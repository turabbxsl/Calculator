using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double eded1, eded2;
        string operatorr;
        bool waitinganswer = false;
        LastSet lastset = LastSet.None;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 828;
            txtscreen.Width = 783;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1086;
            txtscreen.Width = 914;
        }

        private void Numbers_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btnnum)
                {
                    if (lastset == LastSet.None)
                    {
                        lastset = LastSet.eded1;
                    }
                    else if (lastset == LastSet.operatorr)
                    {
                        txtscreen.Clear();
                        lastset = LastSet.eded2;
                    }
                    if (txtscreen.Text == "0")
                    {
                        txtscreen.Clear();
                    }
                    if (txtscreen.Text.Length == 10)
                    {
                        return;
                    }
                    txtscreen.Text += btnnum.Text;
                    if (lastset == LastSet.eded1)
                    {
                        eded1 = eded2 = double.Parse(txtscreen.Text);
                    }
                    else if (lastset == LastSet.eded2)
                    {
                        eded2 = double.Parse(txtscreen.Text);
                   
                    }
                }
            }
            catch (Exception ex)
            {

                Catchexception(ex);
            }
        }

        public double hesabla()
        {

            try
            {
                switch (operatorr)
                {
                    case "+": return eded1 = eded1 + eded2;
                    case "-": return eded1 = eded1 - eded2;
                    case "*": return eded1 = eded1 * eded2;
                    case "/": return eded1 = eded1 / eded2;

                    default: return 0;

                }
            }
            catch (Exception ex)
            {

                Catchexception(ex);
                return 0;
            }
        }
        public void Catchexception(Exception exception)
        {
            MessageBox.Show(exception.Message, "Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                   
                    case Keys.D0:
                    case Keys.NumPad0:
                        button0.PerformClick();
                        break;
                    case Keys.D1:
                    case Keys.NumPad1:
                        button1.PerformClick();
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        button2.PerformClick();
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        button3.PerformClick();
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        button4.PerformClick();
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                        button5.PerformClick();
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                        button6.PerformClick();
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        button7.PerformClick();
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                        button8.PerformClick();
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                         button9.PerformClick();
                        break;               
                }
            }

            catch (Exception ex)
            {

                Catchexception(ex);
            }
        }

        private void buttoCE_Click(object sender, EventArgs e)
        {
            txtscreen.Clear();
            txtscreen.Text = "0";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtscreen.Clear();
            eded1 = eded2 = 0;
            operatorr = null;
            lastset = LastSet.None;
            labelhistory.Text = "";
            txtscreen.Text = "0";
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            if (lastset == LastSet.eded1 || lastset == LastSet.eded2)
            {
               
                    txtscreen.Text = txtscreen.Text.Substring(0, txtscreen.Text.Length - 1);

                if (string.IsNullOrEmpty(txtscreen.Text))
                {
                    txtscreen.Text = "0";
                }
                if (lastset == LastSet.eded1)
                {
                    eded1 = eded2 = double.Parse(txtscreen.Text);
                }
                else if (lastset == LastSet.eded2)
                {
                    eded2 = double.Parse(txtscreen.Text);
                }
            }
        }

        private void buttonnoqte_Click(object sender, EventArgs e)
        {
            if (lastset == LastSet.operatorr)
            {
                button0.PerformClick();
            }
            string spr = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            if (!txtscreen.Text.Contains(spr))
            {
                txtscreen.Text += spr;
            }
           
        }

        private void buttonnetice_Click(object sender, EventArgs e)
        {
            txtscreen.Text = hesabla().ToString();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (sender is Button btnopr)
            {
                operatorr = btnopr.Text;
                labelhistory.Text += $"{eded2} {operatorr}";



                if (waitinganswer && lastset != LastSet.answer)
                {
                    txtscreen.Text = hesabla().ToString();
                }
                eded2 = eded1;
                operatorr = btnopr?.Text;
                lastset = LastSet.operatorr;
                waitinganswer = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double logg = Convert.ToDouble(txtscreen.Text);
            labelhistory.Text = $"Log({txtscreen.Text})";
            logg = Math.Log(logg);
            txtscreen.Text = logg.ToString();
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtscreen.Text = "3.14159";
        }

        private void buttonkvadrat_Click(object sender, EventArgs e)
        {
            double sq = Convert.ToDouble(txtscreen.Text);
            labelhistory.Text = $"{txtscreen.Text}";
            sq = Math.Sqrt(sq);
            txtscreen.Text = sq.ToString();
        }

        private void buttonkok_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(txtscreen.Text) * Convert.ToDouble(txtscreen.Text);
            txtscreen.Text = a.ToString();
        }

        private void buttonkub_Click(object sender, EventArgs e)
        {
            double b = Convert.ToDouble(txtscreen.Text) * Convert.ToDouble(txtscreen.Text) * Convert.ToDouble(txtscreen.Text);
            txtscreen.Text = b.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double c = 1 / Convert.ToDouble(txtscreen.Text);
            txtscreen.Text = c.ToString();
        }

        enum LastSet {None,eded1,eded2,operatorr,answer }
    }
}

     
    
    


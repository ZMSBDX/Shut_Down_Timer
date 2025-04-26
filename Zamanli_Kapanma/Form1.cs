using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zamanli_Kapanma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x;
        private void button1_Click(object sender, EventArgs e)
        {
            int dk = 0, saat = 0;
            dk = (int) numericUpDown1.Value;
            saat = (int) numericUpDown2.Value;
            
            x=dk*60+saat* 3600;

            string CmdCode;
            CmdCode = $"/Cshutdown -s -f -t {x}";
            System.Diagnostics.Process.Start("cmd.exe", CmdCode);
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.label4.Text = $"{dk} Dk VE {saat} Saat Sonra Bilgisayar Kapanacak!!!";
            numericUpDown3.Value = saat;
            numericUpDown4.Value = dk;
            numericUpDown5.Value = 0;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CmdCode;
            CmdCode = $"/Cshutdown -a";
            System.Diagnostics.Process.Start("cmd.exe", CmdCode);
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.label4.Text = $"Bilgisayar Kapanmasi Iptal Edildi.";
            timer1.Stop();
            numericUpDown1.Value = 0; numericUpDown2.Value = 0; numericUpDown3.Value=0; numericUpDown4.Value = 0; numericUpDown5.Value = 0; progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (numericUpDown5.Value != 0)
            {
                numericUpDown5.Value--;
            }
            else if (numericUpDown4.Value != 0)
            {
                numericUpDown4.Value--;
                numericUpDown5.Value = 60;
            }
            else if (numericUpDown3.Value != 0)
            {
                numericUpDown3.Value--;
                numericUpDown4.Value = 60;

            }

            progressBar1.Value += 1000 /x;
        }

        
    }
}

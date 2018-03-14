using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleforMetroFramwork
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();

            this.StyleManager = msmMain;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            msmMain.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
           Menuform RegF = new Menuform();
           RegF.Show();
           this.Hide();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

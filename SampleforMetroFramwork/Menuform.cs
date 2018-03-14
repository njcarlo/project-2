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
    public partial class Menuform : MetroFramework.Forms.MetroForm
    {
       

        public Menuform()
        {

            InitializeComponent();
            reset();
            


        }

        public void reset() {
            
            RegPanel.Visible = false;
            createPanel.Visible = false;
            UpdatePanel.Visible = false;
            BillingPanel.Visible = false;
            


        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            RegisterMenu Studinfo = new RegisterMenu();
            Studinfo.Show();
            this.Hide();
            StudNum1.Text = DateTime.Now.ToString("yyyy");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
           
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {

        }

        private void metroTile7_Click(object sender, EventArgs e)
        {

        }

        private void metroTile8_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            reset();
            RegPanel.Visible = true;
           

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel3_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            reset();
            createPanel.Visible = true;


            DateTime.Now.ToString("dd/MM/yyyy");
            metroTextBox55.Text = DateTime.Now.ToString("yyyy");
        }

        private void metroLabel26_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            reset();
            RegPanel.Visible = true;
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            reset();
            RegPanel.Visible = true;
        }

        private void metroButton10_Click_1(object sender, EventArgs e)
        {

        }

        private void RegPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            reset();
            BillingPanel.Visible = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            reset();
            UpdatePanel.Visible = true;
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            reset();
            RegPanel.Visible = true;
        }

        private void metroButton15_Click_1(object sender, EventArgs e)
        {
            reset();
            RegPanel.Visible = true;
        }

        private void metroPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}

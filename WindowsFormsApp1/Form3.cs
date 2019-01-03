using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(@"D:\UserInfo.csv "))
            {
                sw.WriteLine(txtCardNumber.Text + "," + txtFirstName.Text + ","+ txtLastName.Text + "," + txtEmail.Text + "," + txtContact.Text + "," + txtOccupation.Text + "," + txtInTime.Text + "," + txtOutTime.Text);
                clear();    
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txtCardNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtOccupation.Text = "";
            txtInTime.Text = "";
            txtOutTime.Text = "";
        }
    }
}

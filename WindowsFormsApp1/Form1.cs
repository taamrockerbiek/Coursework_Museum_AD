using System;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int selectedRow;

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDate = dataGridView1.Rows[selectedRow];
            newDate.Cells[7].Value = DateTime.Now.ToLongTimeString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtCardNumber.Text= row.Cells[0].Value.ToString();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Add(txtCardNumber.Text, "","","" ,"" ,"" , DateTime.Now.ToLongTimeString());
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRow);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dataGridView1.Rows[selectedRow];
            newData.Cells[0].Value = txtCardNumber.Text;
           
        }
        public void clear()
        {
            txtCardNumber.Text = "";
   
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtCardNumber.Text = row.Cells[0].Value.ToString();
            
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void importBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            importBox.Text = openFileDialog1.FileName;
            BindDataCSV(importBox.Text);           
        }
        private void BindDataCSV(string filepath)
        {
            DataTable dt = new DataTable(); 
            string[] lines = System.IO.File.ReadAllLines(filepath);
            if (lines.Length>0)
            {
                string firstLine = lines[0];
                string[] headerLables = firstLine.Split(',');
                foreach (string headerWord in headerLables)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }
                for(int r=1; r<lines.Length;r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLables)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }

                    dataGridView1.Rows.Add(dr[0],dr[1],dr[2],dr[3],dr[4],dr[5],dr[6],dr[7]);
                }
            }
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }
           
        }


        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }
    }

}

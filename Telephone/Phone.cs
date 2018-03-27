using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace Telephone
{
    public partial class Phone : Form
    {

        SqlConnection con = new SqlConnection("Data Source=BOGDAN;Initial Catalog=Telephone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Phone()
        {
            InitializeComponent();
        }

        private void Phone_Load(object sendder, EventArgs s)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Mobiles]
           ([First]
           ,[Last]
           ,[Mobil]
           ,[Email]
           ,[Category])
                VALUES ('" + textBox1.Text +"','" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text +"','" + comboBox1.Text + "') ",con);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("SuccesFully Saved...!");
            Display();
        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobiles",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

           textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Mobiles]
      WHERE (Mobil = '" + textBox3.Text + "')", con);


            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete SuccesFully ...!");
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Mobiles]
   SET [First] = '" + textBox1.Text + "',[Last] = '" + textBox2.Text + "' , [Mobil] = '" + textBox3.Text + "' ,[Email] = '" + textBox4.Text + "', + [Category] = '" + comboBox1.Text + "'WHERE (Mobil = '" + textBox3.Text + "')", con);


            

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Update SuccesFully ...!");
            Display();
        }
    }
}

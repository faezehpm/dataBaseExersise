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
using System.IO;
using System.Drawing;
namespace dataBaseExersise
{
    public partial class Form1 : Form
    {

      
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        
            string command = "INSERT INTO student  (s_fname, s_lname, s_phone)" +
                  "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text+  "')";
            ServerConnection serverConnection = new ServerConnection(command);

            string error = serverConnection.executeSql();
            if(error == "")
            
            {
                MessageBox.Show("saved");
                search();
                empty();
            }
            else
            {
                MessageBox.Show("unlnown error occured"+ error);
            }
          
        }
        /*public int count_record()
        {
            int count_row;
            SqlConnection sqlConnection = new SqlConnection(connection_string);

            sqlConnection.Open();
            string command = "SELECT COUNT(*) FROM dbo.student";
            SqlCommand sql_command = new SqlCommand(command, sqlConnection);
            count_row = ((Int32?)sql_command.ExecuteScalar()) ?? 0;

            sqlConnection.Close();
            sqlConnection.Dispose();
            return count_row + 1;
        }*/
        public void search()
        {
           
            string command = "SELECT s_num AS كد , " +
                "s_fname AS نام ," +
                "s_lname AS نامخانوادگي ," +
                "s_phone AS تلفن " + "FROM student where flag=1";
            DataTable dt = new DataTable();
            ServerConnection serverConnection = new ServerConnection(command);
            dt = serverConnection.search_info();
            string err = serverConnection.error_message;
            if (err == "")
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                   
                }
                else
                {
                    MessageBox.Show("not record matched please try another code");
                   
                }


            }
            else
            {
                MessageBox.Show("unknown error occured");
             
            }


        }


        private void button4_Click(object sender, EventArgs e)
        {
            searchById();
            empty();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (searchById())
            {
                string command = "Update student set s_fname ='" + textBox2.Text + "',s_lname='" +
                        textBox3.Text + "',s_phone='" + textBox4.Text + "' where s_num='" + textBox1.Text + "'";
                ServerConnection serverConnection = new ServerConnection(command);
                string error = serverConnection.executeSql();
                if (error == "")
                {
                    MessageBox.Show("edited sucessfully");
                    empty();
                    search();
                }
                else
                {
                    MessageBox.Show("unlnown error occured");
                }
            }
          /*  else
            {
                MessageBox.Show("no record matched");
            }*/
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string command = "update student set flag= 0 where s_num='" + textBox1.Text + "'";
            ServerConnection serverConnection = new ServerConnection(command);

            if (searchById())
            {
                string error = serverConnection.executeSql();
                if (error == "")
                {
                    MessageBox.Show("saved");
                    empty();
                }
                else
                {
                    MessageBox.Show("unlnown error occured");
                }
                search();
            }
           /* else
            {
                MessageBox.Show("code doesn't matched");
            }*/
            
        }
        public Boolean searchById()
        {
            string command = "SELECT s_num AS كد , " +
                "s_fname AS نام ," +
                "s_lname AS نامخانوادگي ," +
                "s_phone AS تلفن " + "FROM student Where s_num=" + textBox1.Text + "";
            DataTable dt = new DataTable();
            ServerConnection serverConnection = new ServerConnection(command);
            dt = serverConnection.search_info();
            string err = serverConnection.error_message;
            if(err == "")
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    return true;
                }
                else
                {
                    MessageBox.Show("not record matched please try another code");
                    return false;
                }


            }
            else
            {
                MessageBox.Show("unknown error occured");
                return false;
            }
           
        }
        public void empty()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

      
      
        
    }
}

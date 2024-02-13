using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_DataBase;

namespace ProgForAdmin
{
    public partial class Log_in : MetroFramework.Forms.MetroForm
    {
        DataBase DataBase = new DataBase();
        public Log_in()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Password_TextBox.PasswordChar = '*';
            Password_TextBox.MaxLength = 15;
            login_TextBox.MaxLength = 15;

        }

      

        private void log_button_Click(object sender, EventArgs e)
        {
            var loginUser = login_TextBox.Text;
            var passUser = Password_TextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select ID, Login, Password from AdminData where Login = '{loginUser}' and Password = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());



            DataBase.openConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {


                var userExist = reader.Read();

                if (userExist == false)
                {

                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                var ID = reader.GetInt32(0);


                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Application1 app = new Application1(ID);
                app.Show();

               
                




            }





        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)

            {

                Password_TextBox.UseSystemPasswordChar = true;

            }
            else
            {


                Password_TextBox.UseSystemPasswordChar = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

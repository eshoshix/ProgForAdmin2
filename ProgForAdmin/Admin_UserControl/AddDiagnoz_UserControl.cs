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
using System.Xml.Linq;
using test_DataBase;


namespace ProgForAdmin
{
    
    public partial class AddDiagnoz_UserControl : UserControl
    {
        DataBase DataBase = new DataBase(); 
        
        public AddDiagnoz_UserControl()
        {
            InitializeComponent();
        }

        private void AddDiagnoz_UserControl_Load(object sender, EventArgs e)
        {
          
            AddTable();
            dataGridView1.Columns["ID_Диагноза"].Visible = false;

        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            var name = name_TextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите наименование диагноза!", "Ошибка!");
                return;


            }




            string querystring = $"insert into Диагноз (Наименование) values('{name}')";


            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());

            DataBase.openConnection();
           

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Диагноз добавлен!", "Успех!");

                AddTable();


            }
            else
            {

                MessageBox.Show("Аккаунт не добавлен!");




            }
            DataBase.closeConnection();
        }

        private bool AddTable()
        {
      

            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select ID_Диагноза, Наименование from диагноз", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();

            
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                return true;
            
            


        }
        private void delete()
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить диагноз?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var ID = cell();
                string querystring = $"delete from Диагноз where ID_Диагноза = '{ID}'";
                SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());
                DataBase.openConnection();
                command.ExecuteNonQuery();
                AddTable();

                MessageBox.Show("Диагноз успешно удален!", "Успешно!");
                return;
            }
            

        }

        private int cell()
        {

            int idclient = 0;

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                idclient = Convert.ToInt32(selectedRow.Cells["ID_Диагноза"].Value);
            }
            return idclient;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cell();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

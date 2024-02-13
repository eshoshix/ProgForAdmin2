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
    public partial class SQL_UserControl : UserControl
    {
       
        public SQL_UserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SQL() == false)
            {
                return;

            }


        }

      
        private bool SQL()
        {
            string SqlQuery = richTextBox1.Text;

            SqlConnection con = new SqlConnection("Data Source=exPC; Initial Catalog=EbaTest2; Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(SqlQuery, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в запросе! " +  e.Message, "Ошибка");
                return false;
            }

           
        }
       
        private void SQL_UserControl_Load(object sender, EventArgs e)
        {
         
        }
    }
}

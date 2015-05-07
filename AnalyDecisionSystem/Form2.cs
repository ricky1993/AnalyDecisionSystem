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
using AnalyDecisionSystem;

namespace AnalyDecisionSystem
{
    public partial class Form2 : Form
    {
        #region //initialize data
        DB db = new DB();
        public int rcd;
        public Boolean bl = true;
        SqlDataAdapter MasterAdapter = new SqlDataAdapter();
        SqlCommand MasterCmd = new SqlCommand();
        DataTable MasterDt = new DataTable();
        SqlCommandBuilder MasterCbd;
        SqlTransaction Sqltran;
        DataRow DR;
        public int state;
        #endregion

        public Form2()
        {
            InitializeComponent();
            OpenMasterTable();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void OpenMasterTable()
        {
            string Sql = "select * from 产品返修率统计表";
            // create a command
            MasterCmd = new SqlCommand(Sql, db.thisSqlconnection);
            // create a adapter
            MasterAdapter = new SqlDataAdapter();
            // adapter using command method
            MasterAdapter.SelectCommand = MasterCmd;
            // create a datatable
            MasterDt = new DataTable();
            // fill the datatable with adapter's data
            MasterAdapter.Fill(MasterDt);
            MasterCbd = new SqlCommandBuilder(MasterAdapter);
            dataGridView1.AutoGenerateColumns = false;
            // connect data
            dataGridView1.DataSource = MasterDt;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DataPropertyName = "产品ID";
            dataGridView1.Columns[1].DataPropertyName = "销售总量";
            dataGridView1.Columns[2].DataPropertyName = "返修数量";
            dataGridView1.Columns[3].DataPropertyName = "返修率";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            LoadShow();            
        }


        private void LoadShow()
        {
            if (MasterDt.Rows.Count > 0)
            {
                textBox1.Text = MasterDt.Rows[rcd]["产品ID"].ToString();
                textBox2.Text = MasterDt.Rows[rcd]["销售总量"].ToString();
                textBox3.Text = MasterDt.Rows[rcd]["返修数量"].ToString();
                textBox4.Text = MasterDt.Rows[rcd]["返修率"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            double result;
            if (MasterDt.Rows[rcd]["销售总量"].ToString() != "0")
            {
                result = Convert.ToDouble(MasterDt.Rows[rcd]["返修数量"]) / Convert.ToDouble(MasterDt.Rows[rcd]["销售总量"]);             
            }
            else
            {
                result = 0;
            }
            DR = MasterDt.Rows[rcd];
            DR.BeginEdit();
            if (result <= 1)
            {
                textBox4.Text = result.ToString("P");
                DR["返修率"] = textBox4.Text;
            }
            else
            {
                textBox4.Text = "A error has happened.";
            }
            DR.EndEdit();
            MasterAdapter.Update(MasterDt);
            MasterDt.AcceptChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rcd = dataGridView1.CurrentRow.Index;
            textBox1.Text = MasterDt.Rows[rcd]["产品ID"].ToString();
            textBox2.Text = MasterDt.Rows[rcd]["销售总量"].ToString();
            textBox3.Text = MasterDt.Rows[rcd]["返修数量"].ToString();
            textBox4.Text = MasterDt.Rows[rcd]["返修率"].ToString();
        }
    }
}

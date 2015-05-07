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
    public partial class Form3 : Form
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

        public Form3()
        {
            InitializeComponent();
            OpenMasterTable();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }


        private void OpenMasterTable()
        {
            string Sql = "select * from 满意度统计表";
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
            dataGridView1.Columns[0].DataPropertyName = "订单ID";
            dataGridView1.Columns[1].DataPropertyName = "物流公司ID";
            dataGridView1.Columns[2].DataPropertyName = "服务态度得分";
            dataGridView1.Columns[3].DataPropertyName = "物流得分";
            dataGridView1.Columns[4].DataPropertyName = "售后服务得分";
            dataGridView1.Columns[5].DataPropertyName = "服务态度满意度权重α";
            dataGridView1.Columns[6].DataPropertyName = "物流满意度权重β";
            dataGridView1.Columns[7].DataPropertyName = "售后服务满意度权重γ";
            dataGridView1.Columns[8].DataPropertyName = "总体满意度";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            LoadShow();
        }


        private void LoadShow()
        {
            if (MasterDt.Rows.Count > 0)
            {
                textBox1.Text = MasterDt.Rows[rcd]["订单ID"].ToString();
                textBox2.Text = MasterDt.Rows[rcd]["服务态度得分"].ToString();
                textBox3.Text = MasterDt.Rows[rcd]["物流得分"].ToString();
                textBox4.Text = MasterDt.Rows[rcd]["售后服务得分"].ToString();
                textBox5.Text = MasterDt.Rows[rcd]["服务态度满意度权重α"].ToString();
                textBox6.Text = MasterDt.Rows[rcd]["物流满意度权重β"].ToString();
                textBox7.Text = MasterDt.Rows[rcd]["售后服务满意度权重γ"].ToString();
                textBox8.Text = MasterDt.Rows[rcd]["总体满意度"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double result;
            result = Convert.ToDouble(MasterDt.Rows[rcd]["服务态度得分"]) * Convert.ToDouble(textBox5.Text) + Convert.ToDouble(MasterDt.Rows[rcd]["物流得分"]) * Convert.ToDouble(textBox6.Text) + Convert.ToDouble(MasterDt.Rows[rcd]["售后服务得分"]) * Convert.ToDouble(textBox7.Text);           
            DR = MasterDt.Rows[rcd];
            DR.BeginEdit();
            DR["服务态度满意度权重α"] = textBox5.Text;
            DR["物流满意度权重β"] = textBox6.Text;
            DR["售后服务满意度权重γ"] = textBox7.Text;
            DR["总体满意度"] = textBox8.Text;
            DR.EndEdit();
            MasterAdapter.Update(MasterDt);
            MasterDt.AcceptChanges();
            textBox8.Text = result.ToString();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rcd = dataGridView1.CurrentRow.Index;
            textBox1.Text = MasterDt.Rows[rcd]["订单ID"].ToString();
            textBox2.Text = MasterDt.Rows[rcd]["服务态度得分"].ToString();
            textBox3.Text = MasterDt.Rows[rcd]["物流得分"].ToString();
            textBox4.Text = MasterDt.Rows[rcd]["售后服务得分"].ToString();
            textBox5.Text = MasterDt.Rows[rcd]["服务态度满意度权重α"].ToString();
            textBox6.Text = MasterDt.Rows[rcd]["物流满意度权重β"].ToString();
            textBox7.Text = MasterDt.Rows[rcd]["售后服务满意度权重γ"].ToString();
            textBox8.Text = MasterDt.Rows[rcd]["总体满意度"].ToString();
        }
    }
}

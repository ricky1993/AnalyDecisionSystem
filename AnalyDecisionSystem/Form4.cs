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
using System.IO;

namespace AnalyDecisionSystem
{
    public partial class Form4 : Form
    {
        #region //initialize data
        DB db = new DB();
        SqlDataAdapter MasterAdapter = new SqlDataAdapter();
        SqlCommand MasterCmd = new SqlCommand();
        DataTable MasterDt1 = new DataTable();
        DataTable MasterDt2 = new DataTable();
        DataTable MasterDt3 = new DataTable();
        DataTable MasterDt4 = new DataTable();
        SqlCommandBuilder MasterCbd;
        SqlTransaction Sqltran;
        DataRow DR;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        SaveFileDialog saveFileDialog2 = new SaveFileDialog();
        #endregion

        public Form4()
        {
            InitializeComponent();
            OpenMasterTable1();
            OpenMasterTable2();
            //OpenMasterTable3();
            OpenMasterTable4();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog2 = new SaveFileDialog();
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog2.Filter = "Text Files | *.txt";
                saveFileDialog2.DefaultExt = "txt";
                string fname = saveFileDialog2.FileName;
                StreamWriter sw = new StreamWriter(fname);
                sw.Write("订单号");
                sw.Write(" ");
                sw.Write("处理人ID");
                sw.Write("\r\n");
                foreach (DataRow row in MasterDt1.Rows)
                {
                    sw.Write(row["订单ID"]);
                    sw.Write("      ");
                    sw.Write(row["处理人ID"]);
                    sw.Write("\r\n");
                }
                sw.Write("订单号");
                sw.Write(" ");
                sw.Write("物流公司");
                sw.Write("\r\n");
                foreach (DataRow row in MasterDt1.Rows)
                {
                    sw.Write(row["订单ID"]);
                    sw.Write("      ");
                    sw.Write(row["物流公司ID"]);
                    sw.Write("\r\n");
                }
                sw.Flush();
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Filter = "Text Files | *.txt";
                saveFileDialog1.DefaultExt = "txt";
                string fname = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(fname);
                sw.Write("产品ID");
                sw.Write(" ");
                sw.Write("产品名称");
                sw.Write(" ");
                sw.Write("销售总量");
                sw.Write(" ");
                sw.Write("返修数量");
                sw.Write(" ");
                sw.Write("返修率");
                sw.Write("\r\n");
                foreach (DataRow row in MasterDt1.Rows)
                {
                    sw.Write(row["产品ID"]);
                    sw.Write("      ");
                    sw.Write(row["产品名称"]);
                    sw.Write("       ");
                    sw.Write(row["销售总量"]);
                    sw.Write("       ");
                    sw.Write(row["返修数量"]);
                    sw.Write("        ");
                    sw.Write(row["返修率"]);
                    sw.Write("\r\n");
                }
                sw.Flush();
                sw.Close();
            }
        }

        private void OpenMasterTable1()
        {
            string Sql = "select top 5 * from 产品返修率统计表 join 产品信息管理表 on 产品返修率统计表.产品ID=产品信息管理表.产品ID order by 返修率 DESC";
            // create a command
            MasterCmd = new SqlCommand(Sql, db.thisSqlconnection);
            // create a adapter
            MasterAdapter = new SqlDataAdapter();
            // adapter using command method
            MasterAdapter.SelectCommand = MasterCmd;
            // create a datatable
            MasterDt1 = new DataTable();
            // fill the datatable with adapter's data
            MasterAdapter.Fill(MasterDt1);
            MasterCbd = new SqlCommandBuilder(MasterAdapter);
            LoadShow1();
        }

        private void LoadShow1()
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox19.ReadOnly = true;
            textBox20.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox22.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox24.ReadOnly = true;
            textBox25.ReadOnly = true;
            if (MasterDt1.Rows.Count > 0)
            {
                textBox1.Text = MasterDt1.Rows[0]["产品ID"].ToString();
                textBox2.Text = MasterDt1.Rows[0]["产品名称"].ToString();
                textBox3.Text = MasterDt1.Rows[0]["销售总量"].ToString();
                textBox4.Text = MasterDt1.Rows[0]["返修数量"].ToString();
                textBox5.Text = MasterDt1.Rows[0]["返修率"].ToString();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            if (MasterDt1.Rows.Count > 1)
            {
                textBox6.Text = MasterDt1.Rows[1]["产品ID"].ToString();
                textBox7.Text = MasterDt1.Rows[1]["产品名称"].ToString();
                textBox8.Text = MasterDt1.Rows[1]["销售总量"].ToString();
                textBox9.Text = MasterDt1.Rows[1]["返修数量"].ToString();
                textBox10.Text = MasterDt1.Rows[1]["返修率"].ToString();
            }
            else
            {
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
            if (MasterDt1.Rows.Count > 2)
            {
                textBox11.Text = MasterDt1.Rows[2]["产品ID"].ToString();
                textBox12.Text = MasterDt1.Rows[2]["产品名称"].ToString();
                textBox13.Text = MasterDt1.Rows[2]["销售总量"].ToString();
                textBox14.Text = MasterDt1.Rows[2]["返修数量"].ToString();
                textBox15.Text = MasterDt1.Rows[2]["返修率"].ToString();
            }
            else
            {
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
            }
            if (MasterDt1.Rows.Count > 3)
            {
                textBox16.Text = MasterDt1.Rows[3]["产品ID"].ToString();
                textBox17.Text = MasterDt1.Rows[3]["产品名称"].ToString();
                textBox18.Text = MasterDt1.Rows[3]["销售总量"].ToString();
                textBox19.Text = MasterDt1.Rows[3]["返修数量"].ToString();
                textBox20.Text = MasterDt1.Rows[3]["返修率"].ToString();
            }
            else
            {
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
            }
            if (MasterDt1.Rows.Count > 4)
            {
                textBox21.Text = MasterDt1.Rows[4]["产品ID"].ToString();
                textBox22.Text = MasterDt1.Rows[4]["产品名称"].ToString();
                textBox23.Text = MasterDt1.Rows[4]["销售总量"].ToString();
                textBox24.Text = MasterDt1.Rows[4]["返修数量"].ToString();
                textBox25.Text = MasterDt1.Rows[4]["返修率"].ToString();
            }
            else
            {
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
                textBox25.Text = "";
            }
        }

        private void OpenMasterTable2()
        {
            string Sql = "select top 5 满意度统计表.订单ID,订单信息表.处理人ID from 满意度统计表 join 订单信息表 on 满意度统计表.订单ID=订单信息表.订单ID order by 服务态度得分";
            // create a command
            MasterCmd = new SqlCommand(Sql, db.thisSqlconnection);
            // create a adapter
            MasterAdapter = new SqlDataAdapter();
            // adapter using command method
            MasterAdapter.SelectCommand = MasterCmd;
            // create a datatable
            MasterDt2 = new DataTable();
            // fill the datatable with adapter's data
            MasterAdapter.Fill(MasterDt2);
            MasterCbd = new SqlCommandBuilder(MasterAdapter);
            LoadShow2();
        }
        
        private void LoadShow2()
        {
            textBox26.ReadOnly = true;
            textBox27.ReadOnly = true;
            textBox28.ReadOnly = true;
            textBox29.ReadOnly = true;
            textBox30.ReadOnly = true;
            textBox31.ReadOnly = true;
            textBox32.ReadOnly = true;
            textBox33.ReadOnly = true;
            textBox34.ReadOnly = true;
            textBox35.ReadOnly = true;
            if (MasterDt2.Rows.Count > 0)
            {
                textBox26.Text = MasterDt2.Rows[0]["订单ID"].ToString();
                textBox31.Text = MasterDt2.Rows[0]["处理人ID"].ToString();
            }
            else
            {
                textBox26.Text = "";
                textBox31.Text = "";
            }
            if (MasterDt2.Rows.Count > 1)
            {
                textBox27.Text = MasterDt2.Rows[1]["订单ID"].ToString();
                textBox32.Text = MasterDt2.Rows[1]["处理人ID"].ToString();
            }
            else
            {
                textBox27.Text = "";
                textBox32.Text = "";
            }
            if (MasterDt2.Rows.Count > 2)
            {
                textBox28.Text = MasterDt2.Rows[2]["订单ID"].ToString();
                textBox33.Text = MasterDt2.Rows[2]["处理人ID"].ToString();
            }
            else
            {
                textBox28.Text = "";
                textBox33.Text = "";
            }
            if (MasterDt2.Rows.Count > 3)
            {
                textBox29.Text = MasterDt2.Rows[3]["订单ID"].ToString();
                textBox34.Text = MasterDt2.Rows[3]["处理人ID"].ToString();
            }
            else
            {
                textBox29.Text = "";
                textBox34.Text = "";
            }
            if (MasterDt2.Rows.Count > 4)
            {
                textBox30.Text = MasterDt2.Rows[4]["订单ID"].ToString();
                textBox35.Text = MasterDt2.Rows[4]["处理人ID"].ToString();
            }
            else
            {
                textBox30.Text = "";
                textBox35.Text = "";
            }
        }

        private void OpenMasterTable3()
        {
            string Sql = "select top 5 订单ID,维修团队负责人 from 满意度统计表 join 维修订单管理表 on 满意度统计表.订单ID=维修订单管理表.订单ID order by 售后服务得分";
            // create a command
            MasterCmd = new SqlCommand(Sql, db.thisSqlconnection);
            // create a adapter
            MasterAdapter = new SqlDataAdapter();
            // adapter using command method
            MasterAdapter.SelectCommand = MasterCmd;
            // create a datatable
            MasterDt3 = new DataTable();
            // fill the datatable with adapter's data
            MasterAdapter.Fill(MasterDt3);
            MasterCbd = new SqlCommandBuilder(MasterAdapter);
            LoadShow3();
        }

        private void LoadShow3()
        {
            textBox36.ReadOnly = true;
            textBox37.ReadOnly = true;
            textBox38.ReadOnly = true;
            textBox39.ReadOnly = true;
            textBox40.ReadOnly = true;
            textBox41.ReadOnly = true;
            textBox42.ReadOnly = true;
            textBox43.ReadOnly = true;
            textBox44.ReadOnly = true;
            textBox45.ReadOnly = true;
            if (MasterDt3.Rows.Count > 0)
            {
                textBox36.Text = MasterDt3.Rows[0]["订单ID"].ToString();
                textBox41.Text = MasterDt3.Rows[0]["维修团队负责人"].ToString();
            }
            else
            {
                textBox36.Text = "";
                textBox41.Text = "";
            }
            if (MasterDt3.Rows.Count > 1)
            {
                textBox37.Text = MasterDt3.Rows[1]["订单ID"].ToString();
                textBox42.Text = MasterDt3.Rows[1]["维修团队负责人"].ToString();
            }
            else
            {
                textBox37.Text = "";
                textBox42.Text = "";
            }
            if (MasterDt3.Rows.Count > 2)
            {
                textBox38.Text = MasterDt3.Rows[2]["订单ID"].ToString();
                textBox43.Text = MasterDt3.Rows[2]["维修团队负责人"].ToString();
            }
            else
            {
                textBox38.Text = "";
                textBox43.Text = "";
            }
            if (MasterDt3.Rows.Count > 3)
            {
                textBox39.Text = MasterDt3.Rows[3]["订单ID"].ToString();
                textBox44.Text = MasterDt3.Rows[3]["维修团队负责人"].ToString();
            }
            else
            {
                textBox39.Text = "";
                textBox44.Text = "";
            }
            if (MasterDt3.Rows.Count > 4)
            {
                textBox40.Text = MasterDt3.Rows[4]["订单ID"].ToString();
                textBox45.Text = MasterDt3.Rows[4]["维修团队负责人"].ToString();
            }
            else
            {
                textBox40.Text = "";
                textBox45.Text = "";
            }
        }

        private void OpenMasterTable4()
        {
            string Sql = "select top 5 满意度统计表.订单ID,物流信息管理表.物流公司ID from 满意度统计表 join 物流信息管理表 on 满意度统计表.订单ID=物流信息管理表.订单ID order by 物流得分";
            // create a command
            MasterCmd = new SqlCommand(Sql, db.thisSqlconnection);
            // create a adapter
            MasterAdapter = new SqlDataAdapter();
            // adapter using command method
            MasterAdapter.SelectCommand = MasterCmd;
            // create a datatable
            MasterDt4 = new DataTable();
            // fill the datatable with adapter's data
            MasterAdapter.Fill(MasterDt4);
            MasterCbd = new SqlCommandBuilder(MasterAdapter);
            LoadShow4();
        }

        private void LoadShow4()
        {
            textBox46.ReadOnly = true;
            textBox47.ReadOnly = true;
            textBox48.ReadOnly = true;
            textBox49.ReadOnly = true;
            textBox50.ReadOnly = true;
            textBox51.ReadOnly = true;
            textBox52.ReadOnly = true;
            textBox53.ReadOnly = true;
            textBox54.ReadOnly = true;
            textBox55.ReadOnly = true;
            if (MasterDt4.Rows.Count > 0)
            {
                textBox46.Text = MasterDt4.Rows[0]["订单ID"].ToString();
                textBox51.Text = MasterDt4.Rows[0]["物流公司ID"].ToString();
            }
            else
            {
                textBox46.Text = "";
                textBox51.Text = "";
            }
            if (MasterDt4.Rows.Count > 1)
            {
                textBox47.Text = MasterDt4.Rows[1]["订单ID"].ToString();
                textBox52.Text = MasterDt4.Rows[1]["物流公司ID"].ToString();
            }
            else
            {
                textBox47.Text = "";
                textBox52.Text = "";
            }
            if (MasterDt4.Rows.Count > 2)
            {
                textBox48.Text = MasterDt4.Rows[2]["订单ID"].ToString();
                textBox53.Text = MasterDt4.Rows[2]["物流公司ID"].ToString();
            }
            else
            {
                textBox48.Text = "";
                textBox53.Text = "";
            }
            if (MasterDt4.Rows.Count > 3)
            {
                textBox49.Text = MasterDt4.Rows[3]["订单ID"].ToString();
                textBox54.Text = MasterDt4.Rows[3]["物流公司ID"].ToString();
            }
            else
            {
                textBox49.Text = "";
                textBox54.Text = "";
            }
            if (MasterDt4.Rows.Count > 4)
            {
                textBox50.Text = MasterDt4.Rows[4]["订单ID"].ToString();
                textBox55.Text = MasterDt4.Rows[4]["物流公司ID"].ToString();
            }
            else
            {
                textBox50.Text = "";
                textBox55.Text = "";
            }
        }




    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace chat
{

    public partial class Form1 : Form
    {
        //连接数据库
        public static String strConn = "server=localhost;User Id=root;password=19960904mnbv;Database=chat;";
        public static MySqlConnection conn = new MySqlConnection(strConn);
        public static Boolean flag = true;
        public static string phone_list;
        public static string name_list;
        public static string phone_listall;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //页面加载中直接出现联系人的信息
            string sql = "select id,name,phone,sum_price from chat_user"; 
            getInfo(sql);

        }

        //获取联系人的信息
        private void getInfo(string sql)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            try
            {
                this.listView1.Items.Clear();
                this.listView1.BeginUpdate();
                while (reader.Read())
                {
                    string[] subItems = new string[]
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDouble(3).ToString()
                    };
                    this.listView1.Items.Add(new ListViewItem(subItems));

                }
                listView1.EndUpdate();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");

            }
        }
        //验证用户（姓名、电话号码）是否存在
        private void getUserByName_Phone(string name,string phone)
        {
            
            string sql = "select * from chat_user where name='"+name+"' and phone='"+phone+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object rs=cmd.ExecuteScalar();
            if (rs!=null)
            {
                flag = true;
            }
            else{
                flag = false;
            }

        }
        //添加通讯录信息
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (text_name.Text=="")
            {
                MessageBox.Show("请输入要添加的姓名！");
                text_name.Clear();
            }else if (text_phone.Text=="")
            {
                MessageBox.Show("请输入要添加的电话号码！");
            }
            else
            {
                string name = text_name.Text;
                string phone = text_phone.Text;
                
                //验证手机号是否合法
                Regex rx = new Regex(@"^[1]+[3,5,7,8]+\d{9}");
                if (!rx.IsMatch(phone))
                {
                    text_phone.Clear();
                    MessageBox.Show("手机号格式不正确，请重新输入！");
                }
                else
                {
                    //验证费用是否为小数
                    Regex rx1 = new Regex(@"^\d+\.\d+$");
                    string price = text_price.Text;
                    if (!rx1.IsMatch(price))
                    {
                        text_price.Clear();
                        MessageBox.Show("费用请输入小数！");
                    }
                    else
                    {
                        conn.Open();
                        getUserByName_Phone(name, phone);
                       
                        if (flag == true)
                        {
                            double pay = Convert.ToDouble(price);
                            string sql_price = "select sum_price from chat_user where name='" + name + "' and phone='" + phone + "'";
                            MySqlCommand cmd_price = new MySqlCommand(sql_price, conn);
                            MySqlDataReader reader = cmd_price.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader.Read())
                            {
                                double count = Convert.ToDouble(reader[0]);
                                count = count + pay;
                                //如果用户存在就直接更改费用总额
                                string sql = "update chat_user set sum_price ='" + count + "' where name='" + name + "' and phone='" + phone + "'";
                                MySqlConnection conn1 = new MySqlConnection(strConn);
                                conn1.Open();
                                MySqlCommand cmd = new MySqlCommand(sql, conn1);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("通讯录添加成功");
                                conn1.Close();
                            }
                            reader.Close();
                           
                            //每次根据用户向子费用表添加费用信息
                            string sql_son = "insert into chat_pprice(name,phone,price)values('" + name + "','" + phone + "','" + price + "')";
                            MySqlConnection conn2 = new MySqlConnection(strConn);
                            conn2.Open();
                            MySqlCommand cmd_son = new MySqlCommand(sql_son, conn2);
                            cmd_son.ExecuteNonQuery();
                            conn2.Close();
                        }
                        else
                        {
                            //如果用户不存在直接添加总费用
                            string location = "无此地域";
                            string sql1 = "insert into chat_user(name,phone,sum_price,location)values('" + name + "','" + phone + "','" + price + "','"+location+"')";
                            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("通讯录添加成功");
                            //每次根据用户向子费用表添加费用信息
                            string sql_son1 = "insert into chat_pprice(name,phone,price)values('" + name + "','" + phone + "','" + price + "')";
                            MySqlCommand cmd_son1 = new MySqlCommand(sql_son1, conn);
                            cmd_son1.ExecuteNonQuery();

                        }
                        conn.Close();
                        string sql2 = "select id,name,phone,sum_price from chat_user";
                        //自动刷新listview列表
                        getInfo(sql2);
                        conn.Close();
                    }
                     
                }
                    
            }
             
        }
  
        //手机号码归属地的查询
        private void localbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("反应时间有些慢，请耐心等待！");
            conn.Open();
            string sql = "select * from chat_user";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
               
                this.listView1.Items.Clear();
                while (reader.Read())
                {
                    string name_all = reader.GetString(1);
                    string phone_all = reader.GetString(2);
                    phone_listall += phone_all + ",";
                    name_list += name_all + ",";
                    //MessageBox.Show(name_list);
                }
               // MessageBox.Show(name_list);
                reader.Close();
                conn.Close();
                phone_list = phone_listall.Trim();
                name_list = name_list.Trim();
               // string[] sArray = phone_list.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArray1 = name_list.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] sArray2 = phone_listall.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in sArray2)
                {
                    string person_phone = i.ToString().Substring(0,7);
                    string person_phoneall = i.ToString();
                    foreach(string j in sArray1)
                    {
                        
                        string person_name = j.ToString();
                       // MessageBox.Show(person_name);
                        //查询归属地
                        conn.Open();
                        string sql_local = "select location from phone_local where phone_org='" + person_phone + "'";
                        MySqlCommand cmd_local = new MySqlCommand(sql_local, conn);
                        MySqlDataReader reader_local = cmd_local.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader_local.Read())
                        {
                            //MessageBox.Show(person_phone);
                            //查询归属地
                            string location = Convert.ToString(reader_local[0]);
                            // MessageBox.Show(location);
                            string sql_local1 = "update chat_user set location='" + location + "'where phone='" + person_phoneall + "'and name='" + person_name + "'";
                            MySqlConnection conn1 = new MySqlConnection(strConn);
                            conn1.Open();
                            MySqlCommand cmd_local1 = new MySqlCommand(sql_local1, conn1);
                            cmd_local1.ExecuteNonQuery();
                            //MessageBox.Show("归属地添加成功");
                        }
                        reader_local.Close();
                        conn.Close();
                    }
                      
                }
                conn.Open();
                MySqlCommand cmd_listlocal = new MySqlCommand(sql, conn);
                MySqlDataReader reader_listlocal = cmd_listlocal.ExecuteReader(CommandBehavior.CloseConnection);

                try
                {
                    this.listView1.Items.Clear();
                    this.listView1.BeginUpdate();
                    while (reader_listlocal.Read())
                    {
                        string[] subitems = new string[]
                        {
                            reader_listlocal.GetInt32(0).ToString(),
                            reader_listlocal.GetString(1),
                            reader_listlocal.GetString(2),
                            reader_listlocal.GetDouble(3).ToString(),
                            reader_listlocal.GetString(4).ToString()
                        };
                        this.listView1.Items.Add(new ListViewItem(subitems));

                    }
                    listView1.EndUpdate();
                    reader_listlocal.Close();
                    conn.Close();
                    MessageBox.Show("归属地查询已完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString() + "打开数据库失败");

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");

            }


        }
        //删除通讯录信息
        private void deletebtn_Click(object sender, EventArgs e)
        {
           if(this.listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选中信息");
            }
            else
            {
                int infoID = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[0].Text);
                string name = this.listView1.SelectedItems[0].SubItems[1].Text;
                string phone = this.listView1.SelectedItems[0].SubItems[2].Text;
                string sql = "delete from chat_user where id='"+infoID+"'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除联系人成功");
                string sql_son = "delete from chat_pprice where name='" + name + "' and phone ='" + phone + "'";
                MySqlCommand cmd_son = new MySqlCommand(sql_son, conn);
                cmd_son.ExecuteNonQuery();
                conn.Close();
                string sql2 = "select id,name,phone,sum_price from chat_user";
                this.getInfo(sql2);
                conn.Close();
            }
        }
        //修改联系人信息
        private void modifybtn_Click(object sender, EventArgs e)
        {
            if (text_name.Text == "")
            {
                MessageBox.Show("请输入希望联系人更改使用的姓名！");
                text_name.Clear();
            }
            else if (text_phone.Text == "")
            {
                MessageBox.Show("请输入希望联系人更改使用的电话号码！");
            }
            else
            {
                string name = text_name.Text;
                string phone = text_phone.Text;

                //验证手机号是否合法
                Regex rx = new Regex(@"^[1]+[3,5,7,8]+\d{9}");
                if (!rx.IsMatch(phone))
                {
                    text_phone.Clear();
                    MessageBox.Show("手机号格式不正确，请重新输入！");
                }
                else
                {
                    //验证费用是否为小数
                    Regex rx1 = new Regex(@"^\d+\.\d+$");
                    string price = text_price.Text;
                    if (!rx1.IsMatch(price))
                    {
                        text_price.Clear();
                        MessageBox.Show("费用请输入小数！");
                    }
                    else
                    {
                        //先写需要修改的信息，然后在选中要修改的联系人
                        if (this.listView1.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("请点击选择需要修改的联系人");
                        }
                        else
                        {
                            int infoID = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[0].Text);
                            string orginal_name = this.listView1.SelectedItems[0].SubItems[1].Text;
                            string orginal_phone = this.listView1.SelectedItems[0].SubItems[2].Text;
                            conn.Open();
                            getUserByName_Phone(name, phone);
                            if (flag == true)
                            {
                                MessageBox.Show("修改的信息列表已有，重新填写");
                                text_name.Clear();
                                text_phone.Clear();
                                text_price.Clear();
                            }
                            else
                            {
                                string sql = "update chat_user set name='" + name + "',phone='" + phone + "',sum_price='" + price + "' where id='" + infoID + "'";
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("修改联系人信息成功");
                                string sql_son = "delete from chat_pprice where name='" + orginal_name + "'and phone ='"+orginal_phone+"'";
                                MySqlCommand cmd_son = new MySqlCommand(sql_son, conn);
                                cmd_son.ExecuteNonQuery();
                                string sql_son1 = "insert into chat_pprice(name,phone,price)values('" + name + "','" + phone + "','" + price + "')";
                                MySqlCommand cmd_son1 = new MySqlCommand(sql_son1, conn);
                                cmd_son1.ExecuteNonQuery();
                                conn.Close();
                                string sql2 = "select id,name,phone,sum_price from chat_user";
                                this.getInfo(sql2);
                                conn.Close();
                            }
                            
                        }
                    }
                }
             }

            
        }
        //根据查询列表关键字查询联系人信息
        private void selectbtn_Click(object sender, EventArgs e)
        {
            if (combo_choose.SelectedIndex == -1)
            {
                MessageBox.Show("请选择查询条件");
            }
            else
            {
                listView1.Items.Clear();
                string choose = combo_choose.SelectedItem.ToString();
                if (choose =="姓名")
                {
                    string chief = text_chief.Text;
                    string sql = "select * from chat_user where name like'%" + chief + "%'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object rs = cmd.ExecuteScalar();
                    if (rs == null)
                    {
                        MessageBox.Show("无查询结果");
                    }
                    else
                    {
                        conn.Close();
                        getInfo(sql);
                        conn.Close();
                    }
                }
                else
                {
                    string chief = text_chief.Text;
                    Regex rx = new Regex(@"^[1]+[3,5,7,8]+\d{9}");
                    if (!rx.IsMatch(chief))
                    {
                        text_chief.Clear();
                        MessageBox.Show("手机号格式不正确，请重新输入！");
                    }
                    else
                    {
                        string sql = "select * from chat_user where phone like'%" + chief + "%'";
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        object rs = cmd.ExecuteScalar();
                        if (rs == null)
                        {
                            MessageBox.Show("无查询结果");
                        }
                        else
                        {
                            conn.Close();
                            getInfo(sql);
                            conn.Close();
                        }
                    }

                }
            }
            
        }
        //重置
        private void retbtn_Click(object sender, EventArgs e)
        {
            text_name.Clear();
            text_phone.Clear();
            text_price.Clear();
            text_chief.Clear();
        }
        //根据输入的姓名和电话号码查询费用详情
        private void sum_pricebtn_Click(object sender, EventArgs e)
        {
            if (text_name.Text == "")
            {
                MessageBox.Show("请输入查询费用详情者的姓名！");
                text_name.Clear();
            }
            else if (text_phone.Text == "")
            {
                MessageBox.Show("请输入查询费用详情者的电话号码！");
            }
            else
            {
                string name = text_name.Text;
                string phone = text_phone.Text;

                //验证手机号是否合法
                Regex rx = new Regex(@"^[1]+[3,5,7,8]+\d{9}");
                if (!rx.IsMatch(phone))
                {
                    text_phone.Clear();
                    MessageBox.Show("手机号格式不正确，请重新输入！");
                }
                else
                {
                    listView1.Items.Clear();
                    conn.Open();
                    string sql = "select * from chat_pprice where name='" + name + "' and phone ='" + phone + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object rs =cmd.ExecuteScalar();
                    if (rs == null)
                    {
                        MessageBox.Show("无查询结果");
                    }
                    else
                    {
                        conn.Close();
                        getInfo(sql);
                        conn.Close();
                    }
                }
            }
        }

        //导出txt文件
        private void export_txtbtn_Click(object sender, EventArgs e)
        {
            //查出数据库中的信息
            conn.Open();
            string sql = "select id,name,phone,sum_price from chat_user";
            DataTable mydata = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            mydata.Load(dr);
            SaveFileDialog save_txt = new SaveFileDialog();
            save_txt.Filter = "文本文件|*.txt";
            if (save_txt.ShowDialog() == DialogResult.OK)
            {

                StreamWriter swriter_txt = File.AppendText(save_txt.FileName);
                for(int i = 0; i < mydata.Rows.Count; i++)
                {
                    for(int j = 0; j < mydata.Columns.Count; j++)
                    {
                        swriter_txt.Write(mydata.Rows[i][j].ToString().Trim()+"\t");
                    }

                    swriter_txt.WriteLine("\t");
                }
                ;
                swriter_txt.Flush();
                swriter_txt.Close();
            }
            conn.Close();
            MessageBox.Show(".txt文件导出成功");
        }
        //导出excel文件
        private void export_excelbtn_Click(object sender, EventArgs e)
        {
            //查出数据库中的信息
            conn.Open();
            string sql = "select id,name,phone,sum_price from chat_user";
            DataTable mydata = new DataTable();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            mydata.Load(dr);
            SaveFileDialog save_excel = new SaveFileDialog();
            save_excel.Filter = "Excel 工作簿(*.xls)|*.xls";
            
            if (save_excel.ShowDialog() == DialogResult.OK)
            {
                
                StreamWriter swriter_excel = new StreamWriter(save_excel.FileName,false, System.Text.Encoding.GetEncoding("UTF-8"));
                for (int i = 0; i < mydata.Rows.Count; i++)
                {
                    for (int j = 0; j < mydata.Columns.Count; j++)
                    {
                         swriter_excel.Write(mydata.Rows[i][j].ToString().Trim() + ",");
                        
                    }
                    
                    swriter_excel.WriteLine("\t");
                }
                ;
                swriter_excel.Flush();
                swriter_excel.Close();
                
            }
            conn.Close();
            MessageBox.Show(".xls文件导出成功");
        }
        //导入文件
        private void importbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_txt_excel = new OpenFileDialog();
            open_txt_excel.Filter = "文本文件|*.txt|Excel 工作簿(*.xls)|*.xls";
            if (open_txt_excel.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = File.OpenText(open_txt_excel.FileName);
                try
                {
                    while (reader.EndOfStream != true)
                    {
                        string readStr = reader.ReadLine();
                        string[] strs = readStr.Split(new char[] { '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string name = strs[1];
                        string phone = strs[2];
                        string sum_price = strs[3];
                        conn.Close();
                        conn.Open();
                        getUserByName_Phone(name, phone);
                        if (flag == false)
                        {
                            //联系人不存在
                            string location = "无区域";
                            //不存在直接添加
                            string sql = "insert into chat_user(name,phone,sum_price,location)values('" + name + "','" + phone + "','" + sum_price + "','" + location + "')";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            //子表不存在直接添加
                            string sql_son = "insert into chat_pprice(name,phone,price)values('" + name + "','" + phone + "','" + sum_price + "')";
                            MySqlCommand cmd_son = new MySqlCommand(sql_son, conn);
                            cmd_son.ExecuteNonQuery();
                        }
                        else
                        {
                            //联系人存在
                            double pay = Convert.ToDouble(sum_price);
                            string sql_price = "select sum_price from chat_user where name='" + name + "' and phone='" + phone + "'";
                            MySqlCommand cmd_price = new MySqlCommand(sql_price, conn);
                            MySqlDataReader reader1 = cmd_price.ExecuteReader(CommandBehavior.CloseConnection);
                            while (reader1.Read())
                            {
                                double count = Convert.ToDouble(reader1[0]);
                                count = count + pay;
                                //如果用户存在就直接更改费用总额
                                string sql = "update chat_user set sum_price ='" + count + "' where name='" + name + "' and phone='" + phone + "'";
                                MySqlConnection conn1 = new MySqlConnection(strConn);
                                conn1.Open();
                                MySqlCommand cmd = new MySqlCommand(sql, conn1);
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("通讯录添加成功");
                                conn1.Close();
                            }
                            reader1.Close();
                            //每次根据用户向子费用表添加费用信息
                            string sql_son = "insert into chat_pprice(name,phone,price)values('" + name + "','" + phone + "','" + pay + "')";
                            MySqlConnection conn2 = new MySqlConnection(strConn);
                            conn2.Open();
                            MySqlCommand cmd_son = new MySqlCommand(sql_son, conn2);
                            cmd_son.ExecuteNonQuery();
                            conn2.Close();

                        }

                    }
                    string sql_show = "select * from chat_user";
                    conn.Close();
                    getInfo(sql_show);
                    MessageBox.Show("导入成功");
                    conn.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show("文件中的内容不是UTF-8编码模式"+"\n"+"或者导入信息列表与显示的数据信息栏不匹配");
                }
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已退出通讯录");
            Application.Exit();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelHelper
{
    public partial class LIT_FRUIT : Form
    {
        List<NumericUpDown> ListNumUpDown = new List<NumericUpDown>();
        string txtInfo;

        public LIT_FRUIT()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            foreach (NumericUpDown n in ListNumUpDown)
            {
                n.Value = 0;
            }
            txt_Name.Text = "Unknow";
            txt_Dorm.Text = "Unknow";
            txt_remark.Text = "";
        }

        private void btn_CreTXT_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(txtInfo, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            try
            {
                OrderClasses.Order newOreder = new OrderClasses.Order();
                string cInfo = txt_Dorm.Text + "," + txt_Name.Text;
                newOreder = new OrderClasses.CustomerInfo(newOreder, cInfo);

                foreach (NumericUpDown n in ListNumUpDown)
                {
                    newOreder = new OrderClasses.FruitOrder(newOreder, double.Parse(n.Value.ToString()));
                }
                newOreder = new OrderClasses.Remark(newOreder, txt_remark.Text);

                sw.WriteLine(newOreder.getOrder());
                MessageBox.Show("Create Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
                Clear();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void LIT_FRUIT_Load(object sender, EventArgs e)
        {
            txtInfo = txt_filePath.Text + "\\" + txt_txtName.Text;

            //Please recorrect the function Mapping if the order of this part is modified
            ListNumUpDown.Add(numericUpDown1); //苹果
            ListNumUpDown.Add(numericUpDown2); //精品苹果
            ListNumUpDown.Add(numericUpDown3); //香梨
            ListNumUpDown.Add(numericUpDown4); //南果梨
            ListNumUpDown.Add(numericUpDown5); //香蕉
            ListNumUpDown.Add(numericUpDown6); //大橘子
            ListNumUpDown.Add(numericUpDown7); //小橘子
            ListNumUpDown.Add(numericUpDown8); //橙子
            ListNumUpDown.Add(numericUpDown9); //猕猴桃
            ListNumUpDown.Add(numericUpDown10); //火龙果
            ListNumUpDown.Add(numericUpDown11); //柚子
            ListNumUpDown.Add(numericUpDown12); //木瓜
            ListNumUpDown.Add(numericUpDown13); //草莓
            ListNumUpDown.Add(numericUpDown14); //杏仁
            ListNumUpDown.Add(numericUpDown15); //纸质核桃
            ListNumUpDown.Add(numericUpDown16); //冬枣
            ListNumUpDown.Add(numericUpDown17); //柿子
            ListNumUpDown.Add(numericUpDown18); //西瓜子
            ListNumUpDown.Add(numericUpDown19); //瓜子
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value == 0)
            {
                ((NumericUpDown)sender).BackColor = Color.White;
            }
            else
            {
                ((NumericUpDown)sender).BackColor = Color.CadetBlue;
            }
        }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            txtInfo = txt_filePath.Text + "\\" + txt_txtName.Text;
        }

        private NumericUpDown Mapping(string fruit)
        {
            string[] mapping_fruit = {"苹果", "精品苹果",	"香梨",	"南果梨", "香蕉", 
                                   "大橘子", "小橘子", "橙子", "猕猴桃", "火龙果", 
                                   "柚子", "木瓜", "草莓", "杏仁", "纸质核桃", 
                                   "冬枣", "柿子", "西瓜子", "瓜子"};

            int index = -1;
            for (int i = 0; i < mapping_fruit.Length; i++)
            {
                if (mapping_fruit[i] == fruit)
                {
                    index = i;
                    break;
                }
            }

            return ListNumUpDown[index];
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            string path_txtMsg = @"message.txt";
            string path_txtOrderList = @"orderlist.txt";
            //FileStream fs1 = new FileStream(path_txtMsg, FileMode.Append);
            //FileStream fs2 = new FileStream(path_txtOrderList, FileMode.OpenOrCreate);
            //StreamReader sr = new StreamReader(fs2, Encoding.UTF8);
            //StreamWriter sw = new StreamWriter(fs1, Encoding.UTF8);
            Process myProcess = new Process();

            try
            {             
                //sw.WriteLine(txt_msg.Text);

                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "grasper.exe";
                myProcess.Start();

                MessageBox.Show("Converting!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sr.Close();
                //sw.Close();
                //fs1.Close();
                //fs2.Close();
            }

        }
    }
}

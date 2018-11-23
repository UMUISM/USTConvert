using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USTConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var badstring = textBox1.Text;
            var hopefullyRecovered = Encoding.GetEncoding("gb2312").GetBytes(badstring);
            var oughtToBeJapanese = Encoding.GetEncoding(932).GetString(hopefullyRecovered);
            if (textBox2.Text != oughtToBeJapanese)
            {
                textBox2.Text = oughtToBeJapanese;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var jpstring = textBox2.Text;
            var hopefullyRecovered = Encoding.GetEncoding(932).GetBytes(jpstring);
            var str = Encoding.GetEncoding("gb2312").GetString(hopefullyRecovered);
            if (textBox1.Text != str)
            {
                textBox1.Text = str;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("开发中，敬请期待！");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择UST";
            dialog.Filter = "UST|*.ust";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                textBox2.Text = File.ReadAllText(path);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "请选择要保存的位置";
            sav.Filter = "UST|*.ust";
            sav.ShowDialog();
            string stt = sav.FileName;
            if (stt == "")
            {
                MessageBox.Show("请输入文件名");
                return;
            }
            using (FileStream fil = new FileStream(stt, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] byt = new byte[1024];
                string str = textBox1.Text;
                byt = Encoding.Default.GetBytes(str);
                fil.Write(byt, 0, byt.Length);
                fil.Flush();
                fil.Close();
            }
            MessageBox.Show("保存完毕");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Title = "请选择要保存的位置";
            sav.Filter = "UST|*.ust";
            sav.ShowDialog();
            string stt = sav.FileName;
            if (stt == "")
            {
                MessageBox.Show("请输入文件名");
                return;
            }
            using (FileStream fil = new FileStream(stt, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] byt = new byte[1024];
                string text = textBox2.Text;
                string str = text;
                byt = Encoding.Default.GetBytes(str);
                fil.Write(byt, 0, byt.Length);
                fil.Flush();
                fil.Close();
            }
            MessageBox.Show("保存完毕");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // MessageBox.Show("开发中，敬请期待！");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择UST";
            dialog.Filter = "UST|*.ust";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                textBox1.Text = File.ReadAllText(path);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form2 : Form
    {
        bool isEdit;
        int index;
        Form1 f;
        List<Human> lH;
        string photo = "";
        List<string> p = new List<string>();
        public Form2(List<Human> l, Form1 ff)
        {
            lH = l;
            f = ff;
            InitializeComponent();
        }
        public Form2(List<Human> l, Form1 ff, int i)
        {
            InitializeComponent();
            lH = l;
            f = ff;
            index = i;
            textBox1.Text = lH[i].Name;
            textBox2.Text = lH[i].Surame;
            textBox6.Text = lH[i].Address;
            textBox7.Text = lH[i].Email;
            textBox5.Text = lH[i].Info;
            textBox3.Text = lH[i].Patronymic;
            try
            {
                p = lH[i].Phones;
            }
            catch { p = new List<string>(); }
            isEdit = true;
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Phonebook";
            listBox1.DataSource = p;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {


                Human h = new Human()
                {
                    Name = textBox1.Text,
                    Surame = textBox2.Text,
                    Address = textBox6.Text,
                    Email = textBox7.Text,
                    Info = textBox5.Text,
                    Patronymic = textBox3.Text,
                    Phones = p,
                    Photo = photo
                };
                lH.Add(h);
                f.UpdateData();
                this.Close();
            }
            else
            {
                
                lH[index].Name = textBox1.Text;
                lH[index].Surame = textBox2.Text;
                lH[index].Address = textBox6.Text;
                lH[index].Email = textBox7.Text;
                lH[index].Info = textBox5.Text;
                lH[index].Patronymic = textBox3.Text;
                lH[index].Phones = p;
                
                f.UpdateDataEdit();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Png|*.png|Jpeg|*.jpeg";
            if (isEdit)
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    lH[index].Photo = dlg.FileName;
            }
            else
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    photo = dlg.FileName;
            }
        }
        public void RData()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = p;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (p.Count != 5)
            {
                Form3 f3 = new Form3(p, this);
                f3.Show();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                p.RemoveAt(listBox1.SelectedIndex);
                listBox1.DataSource = null;
                listBox1.DataSource = p;
            }
            catch { }
        }
    }
}

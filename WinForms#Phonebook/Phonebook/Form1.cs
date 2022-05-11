using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form1 : Form
    {
        public List<Human> lH;
        
        List<string> slH = new List<string>();
        public Form1()
        {
            lH = new List<Human>();
            InitializeComponent();
        }
        public void UpdateData()
        {
            slH.Add(lH[lH.Count - 1].Surame);
            listBox1.DataSource = null;
            listBox1.DataSource = slH;
        }
        public void UpdateDataEdit()
        {
            slH =null;
            slH =new List<string>();
            foreach (var i in lH)
                slH.Add(i.Surame);
            listBox1.DataSource = null;
            listBox1.DataSource = slH;
        }
        public void Fc(object sender, CancelEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lH, Formatting.Indented);
            File.WriteAllText("data.json", json);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += Fc;
            this.Text = "Phonebook";
            
            if(File.Exists(Environment.CurrentDirectory+"\\data.json"))
            {
                string json = File.ReadAllText("data.json");
                lH = JsonConvert.DeserializeObject<List<Human>>(json);
                foreach (var i in lH)
                    slH.Add(i.Surame);
            }
            listBox1.DataSource = slH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(lH,this);
            f.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                try
                {
                    pictureBox1.Image = new Bitmap(lH[listBox1.SelectedIndex].Photo);
                }
                catch { pictureBox1.Image = null; }
                label1.Text = lH[listBox1.SelectedIndex].Name;
                label2.Text = lH[listBox1.SelectedIndex].Surame;
                label3.Text = lH[listBox1.SelectedIndex].Patronymic;
                label4.Text = lH[listBox1.SelectedIndex].Address;
                label5.Text = lH[listBox1.SelectedIndex].Email;
                textBox2.Text = lH[listBox1.SelectedIndex].Info;
                label8.Text = lH[listBox1.SelectedIndex].Photo;
                try
                {
                    listBox2.DataSource = null;
                    listBox2.DataSource = lH[listBox1.SelectedIndex].Phones;
                }
                catch { }
               
            }
            catch
            {
                pictureBox1.Image = null;
                label1.Text ="-";
                label2.Text = "-";
                label3.Text = "-";
                label4.Text = "-";
                label5.Text = "-";
                textBox2.Text = "-";
                listBox2.DataSource = null;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            slH.RemoveAt(listBox1.SelectedIndex);
            lH.RemoveAt(listBox1.SelectedIndex);
            listBox1.DataSource = null;
            listBox1.DataSource = slH;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f = new Form2(lH, this, listBox1.SelectedIndex);
                f.Show();
                listBox1_SelectedIndexChanged(null, null);
            }
            catch { }

        }
    }
}

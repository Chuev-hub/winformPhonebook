using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form3 : Form
    {
        Form2 ff;
        List<string> s;
        public Form3(List<string> ss, Form2 f)
        {
            ff = f;
            s = ss;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Phonebook";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Add(textBox1.Text);
            ff.RData();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                listBox1.Items.Add(openFile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Attachment> attachments = new List<Attachment>();
            MailService service = new MailService(textBox5.Text, textBox4.Text);
            if (listBox1.Items.Count>0)
            {
                foreach (var item in listBox1.Items)
                {
                    attachments.Add(new Attachment(item.ToString()));
                }
            }
            service.SendMailMessage(textBox1.Text, textBox3.Text, $"<h1 style='color: red;text-shadow: 5px 5px 15px red;'>{textBox2.Text}</h1>", true, attachments.ToArray());
            MessageBox.Show("Success send!");
        }
    }
}

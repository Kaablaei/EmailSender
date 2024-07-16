using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Threading;

namespace EmailSender
{
    public partial class Form1 : Form
    {



        string tik = "✔️";
        string not = "❌";
        int ZeroEmail = 0;
        bool cansel = false;

        //
        //
        //"amirhoseyn2019@yahoo.com"//""

        private async Task SendEmail(string display, string to, string sub, string body, int port)
        {
            var fromAddress = new MailAddress(textBox104.Text.ToString(), display);
            var toAddress = new MailAddress(to);
            string fromPassword = textBox105.Text.ToString();
            string subject = sub;
            string emailBody = body;

            using (var smtp = new SmtpClient
            {
                Host = "smtp.mail.yahoo.com",
                // Port = 587,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = emailBody
                })
                {
                    await smtp.SendMailAsync(message);
                }
            }
        }








        public Form1()
        {
            InitializeComponent();




            this.MinimizeBox = true;
            this.MaximizeBox = true;
        }




        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = string.Empty;
        }
        bool boltime = false;

        private async void button1_Click(object sender, EventArgs e)
        {
            cansel = false;
            label12.Text = "";

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("لطفا دسترسی به اینترنت را چک کنید", " ", MessageBoxButtons.OK);
                return;
            }

            string[] emails = textBoxEmails.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (emails.Length == 0)
            {
                MessageBox.Show("لطفا حداقل یک ایمیل را وارد کنید", " ", MessageBoxButtons.OK);

                return;
            }



            int time;

            int port;

            if (!int.TryParse(textBox5.Text, out time) || time < 0)
            {
                MessageBox.Show("لطفاً فاصله ارسال را به درستی وارد کنید و مقدار مثبت باشد", "خطا", MessageBoxButtons.OK);
                boltime = false;
            }
            else
            {
                time *= 1000; // تبدیل به میلی‌ثانیه
                boltime = true;
            }





            if (boltime && int.TryParse(textBox4.Text, out port))
            {
                label4.Text = "Sending . . . . ";
                foreach (var email in emails)
                {

                    try
                    {
                        await SendEmail(textBox1.Text, email.Trim(), textBox2.Text, textBox3.Text,port);
                        textBoxOutput.AppendText($"{email}   ✔️\r\n");
                    }
                    catch (Exception ex)
                    {
                        ZeroEmail += 1;
                        textBoxOutput.AppendText($"{email}   ❌\r\n");
                    }
                    if (cansel)
                    {
                        MessageBox.Show("کنسل شد ", " موفق", MessageBoxButtons.OK);

                        label12.Text = "";
                        break;

                    }



                    await Task.Delay(time);



                }

                if (ZeroEmail == 0)
                {
                    MessageBox.Show("تمامی ایمیل ها با موفقیت ارسال شدند", " موفق", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show($"تعداد ایمیل های ارسال نشده : {ZeroEmail} ", " ارور", MessageBoxButtons.RetryCancel);
                }


                label4.Text = "";
                ZeroEmail = 0;
                cansel = false;
            }
            else
            {
                MessageBox.Show("پورت نا معتبر");
            }
            boltime = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox104_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox105_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            textBoxEmails.Text = string.Empty;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cansel = true;
            if (boltime)
            {
                label12.Text = "Canseling . . . . ";
            }
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}

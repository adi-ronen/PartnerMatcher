using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Mail;

namespace yad2
{
    /// <summary>
    /// Interaction logic for newUser.xaml
    /// </summary>
    public partial class newUser : Window
    {
        MainWindow window;
        Control.Controller m_c;
        public newUser(MainWindow win, Control.Controller c)
        {
            InitializeComponent();
            window = win;
            m_c = c;
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            Male.IsChecked = false;

        }
        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            Female.IsChecked = false;
        }
        
        private void Register(object sender, RoutedEventArgs e)
        {

            if (firstName.Text == "" || lastName.Text == "")
                MessageBox.Show("Please enter your name");
            else if (Age.Text == "")
                MessageBox.Show("Please enter your age");
            else if (Convert.ToInt32(Age.Text) < 0 || Convert.ToInt32(Age.Text) > 121)
                MessageBox.Show("invalied age (must be between 0 and 120)");
            else if (Male.IsChecked == false && Female.IsChecked == false)
                MessageBox.Show("Please select a gender");
            else if (email.Text == "")
                MessageBox.Show("Please enter your email");
            else if (pass.Password == "" || pass2.Password == "")
                MessageBox.Show("Please enter your password and password validation");
            else if (pass.Password != pass2.Password)
                MessageBox.Show("the validation does not match the password");
            else
            {
                if (m_c.UserExist(email.Text))
                    MessageBox.Show("This E-Mail allready registered");
                else
                {
                    try
                    {
                        MailAddress mail = new MailAddress(email.Text);
                        sendMail(mail, firstName.Text + " " + lastName.Text);
                        window.HelloUser.Text = "Hello " + firstName.Text + " " + lastName.Text;
                        window.My_Profile.IsEnabled = true;
                        window.m_userMail = email.Text;
                        bool isMale = false;
                        if (Female.IsChecked.Value) isMale = true;
                        try
                        {

                            m_c.addNewUser(email.Text, pass.Password.Trim(), firstName.Text.Trim(), lastName.Text.Trim(), Convert.ToInt32(Age.Text.Trim()), isMale);
                            MessageBox.Show("Registration completed!");
                            Profile p = new Profile(m_c, email.Text);
                            p.Show();
                            Close();
                        }
                        catch
                        {
                            MessageBox.Show("Error");
                        }
                        Close();


                    }
                    catch
                    {
                        MessageBox.Show("The given e-mail address is not in the form required for an e-mail address.");
                    }
                }
            }
                
        }

        
        private void sendMail(MailAddress userMail,string userName)
        {
            try
            {
                MailMessage mail = new MailMessage(new MailAddress("partnermatcheryad2@gmail.com"), userMail);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("partnermatcheryad2@gmail.com", "olla123456");
                client.EnableSsl = true;

                mail.Subject = "Registration for PartnersMatcher";
                mail.Body ="Hello "+ userName+ "! \nWelcome to PartnersMatcher, We're glad to have you aboard.";
                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Cencel(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

    }
}

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

namespace yad2.View
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private Control.Controller m_c;
        private string m_GroupID;
        private string m_email;
        private string m_text;

        public Chat(Control.Controller c, string GroupID, string email)
        {
            m_email = email;
            m_GroupID = GroupID;
            InitializeComponent();
            m_c = c;
            List<string> l_chat = m_c.GetChat(m_GroupID);
            ChatWindow.ItemsSource = l_chat;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            m_text = TextMessage.Text;
            List<string> l_chat = m_c.addMessageToChat(m_GroupID, m_email, m_text);
            ChatWindow.ItemsSource = l_chat;
            TextMessage.Text = "Enter Message Here";

        }
    }
}

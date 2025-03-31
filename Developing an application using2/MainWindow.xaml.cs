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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Developing_an_application_using2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            string plaintext = Text.Text;
            string ciphertext = CaesarCipherEncrypt(plaintext, 3);
            CipherText.Text = ciphertext;
        }

        private string CaesarCipherEncrypt(string text, int shift)
        {
            string result = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char start = char.IsUpper(c) ? 'A' : 'a';
                    result += (char)(((c - start + shift) % 26 + 26) % 26 + start);
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }
    }
}

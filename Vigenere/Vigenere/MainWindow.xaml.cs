using Microsoft.Win32;
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



namespace Vigenere
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VigenereText text = new VigenereText();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (dir.Text == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.DefaultExt = ".txt";
                ofd.Filter = "Text Document (.txt)|*.txt";
                if (ofd.ShowDialog() == true)
                {

                    string fileName = ofd.FileName;
                    text = VigenereText.OpenFile(fileName);

                }
            }
            else
            {
                text = VigenereText.OpenFile(dir.Text);
            }
            if (text == null)
            {
                MessageBox.Show("В файле нет текста или указан неверный путь");
            }
            else
            {
                
                string alltext = "";
                foreach (var item in text.AllText)
                {
                    alltext += item + "\n";
                }
                test.Text = alltext;
            }
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            string key = Key.Text; ;
            if (test.Text == "")
            {
                text = VigenereText.DecodeOrEncode(key, text, false);
                if (text == null)
                {
                    MessageBox.Show("Неверный формат ключа!");
                }
                else
                {
                    string alltext = "";
                    foreach (var item in text.AllText)
                    {
                        alltext += item + "\n";
                    }
                    test.Text = alltext;
                }
            }
            else
            {
                VigenereText textBoxText = new VigenereText();//экземпляр для текста, введенного пользователем
                textBoxText.AllText.Add(test.Text);
                textBoxText = VigenereText.DecodeOrEncode(key, textBoxText, false);
                if (text == null)
                {
                    MessageBox.Show("Неверный формат ключа!");
                }
                else
                {
                    string alltext = "";
                    foreach (var item in textBoxText.AllText)
                    {
                        alltext += item + "\n";
                    }
                    test.Text = alltext;
                }
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Text Document (.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {

                string fileName = ofd.FileName;
                dir.Text = fileName;

            }
            text.AllText.Clear();
            text.AllText.Add(test.Text);
            VigenereText.SaveText(text, dir.Text);
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            string key = Key.Text;
            if (test.Text == "")
            {
                text = VigenereText.DecodeOrEncode(key, text, true);
                if (text == null)
                {
                    MessageBox.Show("Неверный формат ключа");
                }
                else
                {
                    string alltext = "";
                    foreach (var item in text.AllText)
                    {
                        alltext += item + "\n";
                    }
                    test.Text = alltext;
                }
            }
            else
            {
                VigenereText textBoxText = new VigenereText();//экземпляр для текста, введенного пользователем
                textBoxText.AllText.Add(test.Text);
                textBoxText = VigenereText.DecodeOrEncode(key, textBoxText, true);
                if (text == null)
                {
                    MessageBox.Show("Неверный формат ключа!");
                }
                else
                {
                    string alltext = "";
                    foreach (var item in textBoxText.AllText)
                    {
                        alltext += item + "\n";
                    }
                    test.Text = alltext;
                }
            }
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ключ: должен состоять из символов русского алфавита без пробелов\n" +
                "Путь: можно указать вручную или выбрать по нажатию\n" +
                "Cохранить - сохраняет текуший текст в окне в формате .txt\n" +
                "Открыть - открывает .txt файл\n" +
                "Зашифровать - кодирует сообщение по ключу\n" +
                "Расшифровать - декодирует сообщение по ключу");
        }
    }
}

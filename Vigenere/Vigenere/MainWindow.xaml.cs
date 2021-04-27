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
//using System.Windows.Forms;
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

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Text Document (.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {

                string fileName = ofd.FileName;
                text = VigenereText.OpenFile(fileName);

            }
            string alltext = "";
            foreach (var item in text.AllText)
            {
                alltext += item + "\n";
            }
            test.Text = alltext;
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            string key = Key.Text;
            text = VigenereText.DecodeOrEncode(key, text,false);
            string alltext = "";
            foreach (var item in text.AllText)
            {
                alltext += item + "\n";
            }
            //MessageBox.Show(alltext);
            test.Text = alltext;
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
            VigenereText.SaveText(text, dir.Text);
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            string key = Key.Text;
            text = VigenereText.DecodeOrEncode(key, text,true);
            string alltext = "";
            foreach (var item in text.AllText)
            {
                alltext += item + "\n";
            }
            test.Text = alltext;
        }
    }
}

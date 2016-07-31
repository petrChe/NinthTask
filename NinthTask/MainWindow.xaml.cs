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
using System.IO;
using Microsoft.Win32;

namespace NinthTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
                openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select the file";
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                StreamReader sr = null;
          try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    sr = new StreamReader(openFileDialog.FileName);
                    StringBuilder sb = new StringBuilder();
                    while (sr.Peek() != -1)
                    {
                        sb.Append((char)sr.Read());
                    }
                    string resultString = sb.ToString();
                    textBox.Text = resultString;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(openFileDialog.FileName);
                string newText = textBox.Text;
                sw.Write(newText);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Operation is successfully completed");
                sw.Close();
            }
        }
    }
}

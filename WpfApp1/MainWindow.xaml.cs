using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            using TextFieldParser parser = new TextFieldParser(@"c:\temp\test.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                //Processing row
                string[] fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    //TODO: Process field
                }
            }
            */
        }

        void OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Working");
            //MessageBox.Show("Hey");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Database files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog1.FileName;
                MessageBox.Show(selectedFileName);
                System.Diagnostics.Debug.WriteLine(selectedFileName);
                Console.WriteLine(selectedFileName);
                Console.WriteLine("Comentarioooooooooooooooooooooooo");
                System.Diagnostics.Debug.WriteLine("Comentarioooooooooo");

                using (var reader = new StreamReader(selectedFileName))
                {
                    List<string> listA = new List<string>();
                    List<string> listB = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        listA.Add(values[0]);
                        listB.Add(values[1]);
                    }
                }
                //...
            }
            else
            {
                MessageBox.Show("Ingrese un archivo valido");
            }
            //Console.WriteLine("2Comentarioooooooooooooooooooooooo");
            System.Diagnostics.Debug.WriteLine("2Comentarioooooooooo");
        }

        
    }
}

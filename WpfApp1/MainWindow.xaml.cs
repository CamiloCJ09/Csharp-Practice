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
            ///openFileDialog1.FilterIndex = 0;
            ///openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                List<Elements> listE = new List<Elements>();
                foreach (string line in lines) 
                {
                    string[] vls = line.Split(',');
                    Elements element = new Elements() { CdDepartamento = vls[0] , CdMunicipio = vls[1], Departamento = vls[2], Municipio = vls[3], Tipo = vls[4]};
                    listE.Add(element);
                }
                listE.RemoveAt(0);
                List<DataGraph> data = new List<DataGraph>();
                data.Add(new DataGraph { tipo = "Municipio", cantidad = 0 });
                data.Add(new DataGraph { tipo = "Isla", cantidad = 0 });
                data.Add(new DataGraph { tipo = "Área no municipalizada", cantidad = 0 });
                foreach (Elements element in listE)
                {
                    switch (element.Tipo)
                    {
                        case "Municipio":
                            data.ElementAt(0).cantidad += 1; break;
                        case "Isla":
                            data.ElementAt(1).cantidad += 1; break;
                        default:
                            data.ElementAt(2).cantidad += 1; break;
                    }
                }
                Dg.ItemsSource = listE;
                BarGraph.ItemsSource = data;
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

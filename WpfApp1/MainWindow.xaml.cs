using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class ListElements
    {
        public string codeDep { get; set; }
        public string codeMun { get; set; }
        public string nameDep { get; set; }
        public string nameMun { get; set; }
        public string type { get; set; }

        public ListElements(string codeDep, string codeMun, string nameDep, string nameMun, string type)
        {
            this.codeDep = codeDep;
            this.codeMun = codeMun;
            this.nameDep = nameDep;
            this.nameMun = nameMun;
            this.type = type;
        }

    }
    public partial class MainWindow : Window
    {
        List<Elements> list = new List<Elements>();
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
                this.list = listE;
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

            List<string> letters = new List<string>();
            for(int i = 1; i < 27; i++)
            {
                CbLetters.Items.Add(Char.ConvertFromUtf32(64+i).ToString());
            }

            DataTable table = new DataTable();

            table.Columns.Add("codeDep", typeof(string));
            table.Columns.Add("codeMun", typeof(string));
            table.Columns.Add("nameDep", typeof(string));
            table.Columns.Add("nameMun", typeof(string));
            table.Columns.Add("type", typeof(string));




            //Console.WriteLine("2Comentarioooooooooooooooooooooooo");
            //System.Diagnostics.Debug.WriteLine("2Comentarioooooooooo");
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Elements> filteredElemnts = new List<Elements>();
            if(list != null)
            {
                foreach(Elements el in list)
                {
                    if (el.Municipio.ElementAt(0).ToString().Equals(CbLetters.SelectedItem.ToString()))
                    {
                        //MessageBox.Show(list.ElementAt(0).Municipio);
                        filteredElemnts.Add(el);
                    }
                }
                Dg.ItemsSource = filteredElemnts;
                
            }
            //MessageBox.Show(list.ElementAt(0).Municipio.ElementAt(0).ToString());
        }

    }
}

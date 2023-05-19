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

using SzeleromuClass;
using System.IO;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StreamReader sr = new StreamReader("szeleromu.txt");
        StreamWriter sw = new StreamWriter("jelentes.txt", append : true);

        List<Szeleromu> Szeleromuvek = new List<Szeleromu>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betoltes(object sender, RoutedEventArgs e)
        {
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(";");
                Szeleromu ujEromu = new Szeleromu(sor[0], Convert.ToInt32(sor[1]), Convert.ToInt32(sor[2]), Convert.ToInt32(sor[3]));
                Szeleromuvek.Add(ujEromu);
            }
            dgAdatok.ItemsSource = Szeleromuvek;
            sr.Close();

            //Jelentés készitése:
            for (int i = 0; i < Szeleromuvek.Count(); i++)
                sw.WriteLine($"{Szeleromuvek[i].Telepules},{Szeleromuvek[i].EgysegekSzama},{Szeleromuvek[i].Teljesitmeny},{Szeleromu.TeljesitmenySzamolas(Szeleromuvek[i].Teljesitmeny)}");
            sw.Close();
        }

        private void Hanydarab(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{Szeleromuvek.Count()} db szélerőmü van a listában");
        }

        private void Listaz(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Szeleromuvek.Count(); i++)
            {
                string listaElem;
                if (Szeleromuvek[i].Telepules == txtTelepules.Text)
                {
                    listaElem = Szeleromuvek[i].Teljesitmeny.ToString() + " " + Szeleromuvek[i].EgysegekSzama;
                    lbListbox.Items.Add(listaElem);
                }
            }
            lblListabanSzeleromuvekSzama.Content = lbListbox.Items.Count.ToString();
        }

        private void Atlag(object sender, RoutedEventArgs e)
        {
            double osszeg = 0;
            double darab = 0;

            for (int i = 0; i < Szeleromuvek.Count(); i++)
            {
                if (Szeleromuvek[i].KezdetiEv == 2010)
                {
                    osszeg += Szeleromuvek[i].Teljesitmeny;
                    darab++;
                }
            }
            MessageBox.Show($"A 2010-ben telepített erőművek átlaga: {Math.Round(osszeg / darab, 2)} W ");
        }

        private void LegnagyobbTelj(object sender, RoutedEventArgs e)
        {
            int legnagyobbIndex = 0;
            for (int i = 1; i < Szeleromuvek.Count(); i++)
            {
                if (Szeleromuvek[i].Teljesitmeny > Szeleromuvek[legnagyobbIndex].Teljesitmeny)
                    legnagyobbIndex = i;
            }
            MessageBox.Show($"{Szeleromuvek[legnagyobbIndex].Telepules}, {Szeleromuvek[legnagyobbIndex].Teljesitmeny} W, {Szeleromuvek[legnagyobbIndex].KezdetiEv}");
        }
    }
}

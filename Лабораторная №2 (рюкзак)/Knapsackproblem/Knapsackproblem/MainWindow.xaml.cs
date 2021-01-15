using litemsss;
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

namespace Knapsackproblem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;
        int[] healthinessofproduct;
        int[] priceofproduct;
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<litems> ListofFood = new List<litems>(); // List with products
        public List<int> RecommendedToBuy = new List<int>(); //List that contains the healthiest products from the list above

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opfidialog = new OpenFileDialog(); //choose and open the list of products
                opfidialog.ShowDialog();
                List<string> ListofDifferentProducts = new List<string>(); //list with products
                string productsfromtxtfile; //string type
                if (opfidialog.FileName != "")
                {
                    productsfromtxtfile = File.ReadAllText(opfidialog.FileName); //Read the file with the list of products
                    ListofDifferentProducts.AddRange(productsfromtxtfile.Split('\n')); // AddRange--> Adds elements of the specified collection to list<>.
                }

                healthinessofproduct = new int[ListofDifferentProducts.Count]; 
                priceofproduct = new int[ListofDifferentProducts.Count];


                ListofFood.Clear();
                ListofProducts.ItemsSource = null;

                for (int i = 0; i < ListofDifferentProducts.Count; i++)
                {
                    string[] arr = new string[4]; // string array of 4 elements
                    arr = ListofDifferentProducts[i].Split(':'); // the elements must be splitted with :
                    ListofFood.Add(item: new Catalog()
                    {
                        category = arr[0],
                        name = arr[1],
                        priceofproduct = Convert.ToInt32(arr[2]),
                        healthinessofproduct = Convert.ToInt32(arr[3])
                    }
                    ); 
                    priceofproduct[i] = Convert.ToInt32(arr[2]);
                    healthinessofproduct[i] = Convert.ToInt32(arr[3]);
                }
                ListofProducts.ItemsSource = ListofFood; // ItemsSource returns or creates the string array of elements
            }
            catch (Exception)
            {
                MessageBox.Show("Check the path to the file, plz "); // if the path to the file is not correct-> Message
            }

        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = 0;
                KnapsackWithTheHealthiestProducts.Items.Clear();
                int cash = Math.Abs(Convert.ToInt32(SumOfMoney.Text)); //enter the summ of money
                RecommendedToBuy = Knapsackpr.knapsack(priceofproduct, healthinessofproduct, cash);
                for (k = 0; k < (RecommendedToBuy.Count - 1); k++)
                KnapsackWithTheHealthiestProducts.Items.Add(ListofFood[RecommendedToBuy[k]].name); //Choose the healthiest products from the list 
                KnapsackWithTheHealthiestProducts.Items.Add("Полезность(выбранных на определенную сумму денег продуктов): " + RecommendedToBuy[k]);

            }
            catch (Exception)
            {
                MessageBox.Show("Enter the sum of money correctly,plz"); //mistake-->message
                Close();
            }
        }
    }
}

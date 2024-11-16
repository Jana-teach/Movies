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

namespace movie
{
    /// <summary>
    /// Interaction logic for Allmovies.xaml
    /// </summary>
    public partial class Allmovies : Page
    {
            MoviesEntities db = new MoviesEntities();
        public Allmovies()
        {
            InitializeComponent();
            DataGrid.ItemsSource = db.Movies.Select(x => new
            {
                x.M_ID,
                x.M_Name,
                x.Category,
                x.M_describtion,
                x.M_Year
            }).ToList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Filter_Click_1(object sender, RoutedEventArgs e)
        {
            var selecteditem = combo.Text.ToString();
            var Movie = db.Movies.Where(x => x.Category == selecteditem);
            if (selecteditem == "All")
            {
                DataGrid.ItemsSource = db.Movies.Select(x => new
                {
                    x.M_ID,
                    x.M_Name,
                    x.Category,
                    x.M_describtion,
                    x.M_Year
                }).ToList();
            }
            else
            {
                DataGrid.ItemsSource = Movie.Select(x => new
                {
                    x.M_ID,
                    x.M_Name,
                    x.Category,
                    x.M_describtion,
                    x.M_Year
                }).ToList();
            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = new Movie();
            int id = int.Parse(idtxt.Text);

            movie = db.Movies.Where(X => X.M_ID == id).FirstOrDefault();
            if (movie != null) 
            {
            Details details = new Details(movie);
                NavigationService.Navigate(details);
            }
        }
    }
}

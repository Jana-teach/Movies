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
using System.Data.Entity;

namespace movie
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        MoviesEntities db = new MoviesEntities();
        public Admin()
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

        private void refresh()
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = new Movie();
            movie.M_Name = nametxt.Text;
            movie.M_describtion = Destxt.Text;
            movie.Category = Categorytxt.Text;
            movie.M_Year = int.Parse(Yeartxt.Text);

            db.Movies.Add(movie);
            db.SaveChanges();

            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = new Movie();
            //int id = int.Parse(idtxt.Text);
            //movie = db.Movies.Where(x => x.M_ID == id).FirstOrDefault();
            //if (movie != null) { 
            
            //db.Movies.Remove(movie);
            //}

            movie = db.Movies.Where(x=> x.M_Name == nametxt.Text).FirstOrDefault();
            if (movie != null)
            {
                db.Movies.Remove(movie);
            }
            db.SaveChanges();
            refresh();
        }
    }
}

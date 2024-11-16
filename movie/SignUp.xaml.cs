using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        MoviesEntities db = new MoviesEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            u_User user = new u_User();
            

            if (nametxt.Text == "" || emailtxt.Text =="" || passtxt.Text==""|| conpasstxt.Text=="")
            {
                MessageBox.Show("Data is required");
                return;
            }

            if (passtxt.Text!= conpasstxt.Text)
            {
                MessageBox.Show("Password didn't match");
                return;
            }

            if (!( Regex.IsMatch(passtxt.Text , "[a-z]" )) && (Regex.IsMatch(passtxt.Text, "[A-Z]")) && (Regex.IsMatch(passtxt.Text, "[\\d]")))
            {
                MessageBox.Show("Password weak");
                return;
            }
           

            user.U_Name = nametxt.Text;
            user.U_Email = emailtxt.Text;
            user.U_Password = passtxt.Text;

            db.u_User.Add(user);
            db.SaveChanges();

            Allmovies allmovies = new Allmovies();
            NavigationService.Navigate(allmovies);   
           
        }
    }
}

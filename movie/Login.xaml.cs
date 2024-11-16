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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MoviesEntities db = new MoviesEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (usernametxt.Text=="1" && passtxt.Text=="1")
            {
                Admin admin = new Admin();
                NavigationService.Navigate(admin);
            }
            u_User user = new u_User();
            Allmovies allmovies = new Allmovies();
            if (usernametxt.Text=="" || passtxt.Text == "")
            {
                MessageBox.Show("Please enter data");
                return;
            }

            user = db.u_User.Where(x=> x.U_Email==usernametxt.Text && x.U_Password==passtxt.Text).FirstOrDefault();
            if (user != null)
            {
                NavigationService.Navigate(allmovies);
            }
            else 
            {
                MessageBox.Show("User not found");
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();

            NavigationService.Navigate(signUp);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ForgetPass forgetPass = new ForgetPass();
            NavigationService.Navigate(forgetPass);
        }
    }
}

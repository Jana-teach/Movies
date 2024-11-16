using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for ForgetPass.xaml
    /// </summary>
    public partial class ForgetPass : Page
    {
        MoviesEntities db = new MoviesEntities();
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            u_User user = new u_User();

            user = db.u_User.Where(x=> x.U_Email==emailtxt.Text).FirstOrDefault();

            if (user != null) 
            {
                user.U_Password = newpasstxt.Text;
                db.u_User.AddOrUpdate(user);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("User not found");
            }

            Login login = new Login();
            NavigationService.Navigate(login);

            MessageBox.Show("Password updated succeesfully");

        }
    }
}

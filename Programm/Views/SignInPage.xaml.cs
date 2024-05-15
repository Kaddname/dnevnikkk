using Programm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Programm.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            Loaded += This_Loaded;
        }
        private void This_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 450;
            Window.GetWindow(this).Width = 800;
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.db.Users.FirstOrDefault(u => u.login.Equals(TxbLogin.Text) && u.password.Equals(TxbPassword.Text));

            if (currentUser != null)
            {

                AppData.currentUser = currentUser;

                NavigationService.Navigate(new UserCabinet());
            }
            else
            {
               

                    var currentTeacher = (from teacher in AppData.db.Teachers
                                          join pin in AppData.db.TeachersPin on teacher.pin equals pin.pin
                                          where teacher.login.Equals(TxbLogin.Text)
                                          select teacher).FirstOrDefault();

                    if (currentTeacher != null)
                    {
                        AppData.currentTeacher = currentTeacher;
                        NavigationService.Navigate(new DataPage());
                    }
                    else
                    {
                        MessageBox.Show("Данного пользователя не существует", "Ошибка");
                    }
                
               


                    
            }
        }


    }

}

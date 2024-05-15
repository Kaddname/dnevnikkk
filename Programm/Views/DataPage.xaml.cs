using Programm.Model;
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

namespace Programm.Views
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
            Loaded += This_Loaded;
        }

        private void This_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 720;
            Window.GetWindow(this).Width = 1080;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            UsersGrid.ItemsSource = AppData.db.Users.ToList();
        }

     
        private void RemoveBtn_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить пользователя", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UsersGrid.SelectedItem as Users;
                AppData.db.Users.Remove(CurrentUser);
                AppData.db.SaveChanges();
                UsersGrid.ItemsSource = AppData.db.Users.ToList();
                MessageBox.Show("Success");
            }

        }

        private void AddBtn_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }

        private void ChangeBtn_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите изменить пользователя?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.db.SaveChanges();
                UsersGrid.ItemsSource = AppData.db.Users.ToList();
                MessageBox.Show("Изменено!");
            }
            AppData.db.SaveChanges();
        }

        private void BtnDiary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiaryPage());
        }



        //private void ChangeBtn_click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var CurrentClient = UsersGrid.SelectedItem as Client;
        //        NavigationService.Navigate(new EditUserPage(CurrentClient));
        //   }
        //    catch (Exception ex)
        //    {
        //     MessageBox.Show(ex.ToString(),"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}

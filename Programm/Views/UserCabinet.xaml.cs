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
    /// Логика взаимодействия для UserCabinet.xaml
    /// </summary>
    public partial class UserCabinet : Page
    {
       
        public UserCabinet()
        {
          
         

            InitializeComponent();

                // Получение информации о клиенте текущего пользователя
                var User = AppData.db.Users.FirstOrDefault(c => c.login.Equals(AppData.currentUser.login));

            if (User != null)
            {
                // Проверяем каждое поле на null перед заполнением текстовых полей
                if (User.imya != null)
                    Imya.Text = User.imya;

                if (User.familya != null)
                    Familya.Text = User.familya;

                if (User.otchestvo != null)
                    Otchestvo.Text = User.otchestvo;

                if (User.Avatar1 != null && User.Avatar1.Gender != null)
                    Gender.Text = User.Avatar1.Gender;

                if (User.phoneNumber != null)
                    Number.Text = User.phoneNumber;

                if (User.Lvl1 != null && User.Lvl1.name != null && User.Lvl1.name != null)
                    Lvl.Text = User.Lvl1.name;

                if (User.Role1 != null && User.Role1.name != null && User.Role1.name != null)
                    Role.Text = User.Role1.name;

                if (User.Teachers.imya != null && User.Teachers.familya != null && User.Teachers.otchestvo != null)

                    Teacher.Text = String.Concat("Учитель: ", User.Teachers.imya, " ", User.Teachers.familya, " ", User.Teachers.otchestvo);

                if (User.Score1 != null && User.score != null && User.score != null)

                    Score.Text = String.Concat(User.Score1.score1.ToString(), " баллов");
                if (User.Score1 != null && User.Score1.score1 != null && User.Score1.achievement != null)
                    Achievment.Text = User.Score1.achievement;
            }
            else
            {
                // В случае, если объект client равен null, выводим сообщение об ошибке
                MessageBox.Show("Информация о клиенте не найдена.");
            }
            //Управление видимостью изображений
            if (User != null)
            {
                if (User.avatar == 1)
                {
                    MaleAvatar.Visibility = Visibility.Visible;
                    FemaleAvatar.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MaleAvatar.Visibility = Visibility.Collapsed;
                    FemaleAvatar.Visibility = Visibility.Visible;
                }
            }


            Loaded += This_Loaded;
        }

        private void This_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 450;
            Window.GetWindow(this).Width = 800;
        }
        private void BtnLeave_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
        }
    }

}

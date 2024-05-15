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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
                Loaded += This_Loaded;
        }

        private void This_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 900;
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new dnevnikBDEntities())
            {
                string username = usernameBox.Text;
                string password = passwordBox.Password;
                string firstName = firstNameBox.Text;
                string secondName = secondNameBox.Text;
                string lastName = lastNameBox.Text;
                string phoneNumbers = phoneNumberBox.Text;

                string Genders = GenderBox.Text;
                string lvls = LvlBox.Text;
                string languages = LanguageBox.Text;
               
                int GenderId;
                int languageID;

                int lvlId;

             
                    if (!int.TryParse(Genders, out GenderId))
                    {
                        // Если преобразование не удалось, выводим сообщение об ошибке
                        MessageBox.Show("Используйте для укзания пола 1 - Мужской пол, 2 - Женский");


                     }
                    else

                    {
                    if (!int.TryParse(languages, out languageID))
                    {
                        // Если преобразование не удалось, выводим сообщение об ошибке
                        MessageBox.Show("1 - Английский, 2 - Французский, 3 - Немецкий");
                    }
                    else
                    {

                    }
                    var languageTeacher = context.Teachers.FirstOrDefault(t => t.language == languageID);
                    if (languageTeacher == null)
                    {
                        // Если не найден подходящий teacher, выводим сообщение об ошибке
                        MessageBox.Show("Не удалось найти teacher с соответствующим языком.");
                        return; // Выходим из метода
                    }
                    if (!int.TryParse(lvls, out lvlId))
                    {
                        // Если преобразование не удалось, выводим сообщение об ошибке
                        MessageBox.Show("1 - Basic, 2 - independent, 3 - Proficient");
                    }

                    //context.Users.Add(new Users
                    //    {

                    //        login = username,
                    //        password = password,
                    //        imya = firstName,
                    //        familya = secondName,
                    //        otchestvo = lastName,
                    //        phoneNumber = phoneNumbers,
                    //        language = languageID,
                    //        avatar = GenderId,
                    //        lvl = lvlId,
                    //        role = 1,
                    //        teacher = languageID,



                    //    });
                    var newUser = new Users
                    {
                        login = username,
                        password = password,
                        imya = firstName,
                        familya = secondName,
                        otchestvo = lastName,
                        phoneNumber = phoneNumbers,
                        language = languageID,
                        avatar = GenderId,
                        lvl = lvlId,
                        role = 1,
                        teacher = languageTeacher.id,



                    };


                    context.Users.Add(newUser); // Добавляем пользователя в контекст базы данных




                }
      
                
               


                int result = context.SaveChanges();

                var maxId = context.Users.Max(u => (int?)u.id);
                var user = context.Users.FirstOrDefault(u => u.id == maxId);
                int ScoreID = (int)maxId;
                var newScore = new Score
                {
                    id = ScoreID,
                    score1 = 0,
                    achievement = " "




                };


                context.Score.Add(newScore);
                context.SaveChanges();

                if (user != null)
                {
                    // Изменяем значение поля score на 1
                    user.score = maxId;

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();

                    MessageBox.Show("Значение score успешно присуждено.");
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
                }

                if (result > 0)
                {
                    MessageBox.Show("Вы успешно добавили пользователя!");
                }

                int results = context.SaveChanges();


                if (results > 0)
                {
                    MessageBox.Show("Вы успешно провели соединение!");
                }

            }
        }

        private void BtnToDataPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DataPage());
        }
    }
}

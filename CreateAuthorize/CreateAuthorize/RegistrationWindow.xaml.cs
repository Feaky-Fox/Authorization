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
using System.Windows.Shapes;

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DBContainer db = new DBContainer();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == " " || password.Password == " " || lastName.Text== " " || middleName.Text== " ")
            {
                MessageBox.Show("Пустые поля");
                return;
            }
            if(db.TablSet.Select(Item => Item.Login).Contains(login.Text))
            {
                MessageBox.Show("Такой логин существует в системе");
                return;
            }
            Tabl newTabl = new Tabl()
            {
                Login = login.Text,
                Password = password.Password,
                LastName = lastName.Text,
                FirstName = firstName.Text,
                MiddleName = middleName.Text
            };

            db.TablSet.Add(newTabl);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
        private void CancelClick(object sende, RoutedEventArgs e)
        {
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }






    }
}

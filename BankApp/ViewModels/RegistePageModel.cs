using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp
{
    class RegistePageModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Confirm { protected set; get; }

        public RegistePageModel()
        {

            Confirm = new Command(confirm);
        }
        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string phone { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }


        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        private void confirm()
        {
            try
            {
                List<User> Users = App.database.GetItems().ToList();
                int is_user = Users.Where(x => x.Username == Username).Count();
                if (is_user > 0)
                {
                    MessagingCenter.Send(this, "Юзернейм занят!");
                }
                User user = new User();
                user.Name = Name;
                user.Surname = Surname;
                user.Phone = Phone;
                user.Password = Password;
                App.database.SaveItem(user);
            }
            catch
            {
                MessagingCenter.Send(this, "Произошла ошибка!\n Проверьте правильность введеных данных!");
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

}

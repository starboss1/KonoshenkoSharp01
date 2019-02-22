using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2019.KonoshenkoLab01
{
    internal class BirthDateViewModel: INotifyPropertyChanged
    {
        public Visibility LoaderVisibility { get; set; }
        private bool _isControlEnabled = true;
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        private readonly BirthDateModel _birthDateModel = new BirthDateModel();

        public BirthDateViewModel()
        {
            LoaderVisibility = Visibility.Hidden;
            OnPropertyChanged("LoaderVisibility");

        }

        public DateTime BirthDate
        {
            get { return _birthDateModel.BirthDate; }

            set
            {
                ChangeVisibility();
                _birthDateModel.BirthDate = value;
                if (!_birthDateModel.Valid)
                {
                    MessageBox.Show("Wrong date!!!");
                }
                else if (_birthDateModel.IsBirthday)
                {
                    MessageBox.Show("Happy birthday!!! Vy staly na rik starishym =)(Za smailik sorri)");
                }
                OnPropertyChanged();
                OnPropertyChanged("Age");
                OnPropertyChanged("ChineseZodiac");
                OnPropertyChanged("WesternZodiac");
                
            }
        }

        private async void ChangeVisibility()
        {
            
            LoaderVisibility = Visibility.Visible;
            OnPropertyChanged("LoaderVisibility");
            IsControlEnabled = false;
            OnPropertyChanged("IsControlEnabled");
            await Task.Run(() => Thread.Sleep(3000));
            IsControlEnabled = true;
            OnPropertyChanged("IsControlEnabled");
            LoaderVisibility = Visibility.Hidden;
            OnPropertyChanged("LoaderVisibility");
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Age
        {
            get { return $"Your age is {_birthDateModel.Age}"; }

        }

        public string ChineseZodiac
        {
            get { return $"Your Chinese Zodiac is {_birthDateModel.ChineseZodiac}"; }
        }

        public string WesternZodiac
        {
            get { return $"Your Western Zodiac is {_birthDateModel.WesternZodiac}"; }
        }
    }
}

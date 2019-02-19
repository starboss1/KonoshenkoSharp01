using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.KonoshenkoLab01
{
    internal class BirthDateViewModel: INotifyPropertyChanged
    {
        private readonly BirthDateModel _birthDateModel = new BirthDateModel();

        public DateTime BirthDate
        {
            get { return _birthDateModel.BirthDate; }

            set
            {
                _birthDateModel.BirthDate = value;
                if (!_birthDateModel.Valid)
                {
                    MessageBox.Show("Wrong date!!!");
                }
                else if (_birthDateModel.IsBirthday)
                {
                    MessageBox.Show("Happy birthday!!! Vy staly na rik starishym =)(Za zhart sorri)");
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(ChineseZodiac));
                OnPropertyChanged(nameof(WesternZodiac));
            }
        }


        //[NotifyPropertyChangedInvocator]
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

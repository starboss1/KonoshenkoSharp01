

using System;

namespace KMA.ProgrammingInCSharp2019.KonoshenkoLab01
{
    internal class BirthDateModel
    {

        private static readonly string[] ChineseZodiaсList = {"Rat","Ox","Tiger","Rabbit",
            "Dragon","Snake","Horse","Goat","Monkey","Rooster","Dog","Pig"
        };

        private static readonly string[] WesternZodiaсList = {"Ram","Bull","Twins","Crab",
            "Lion","Virgin","Scales","Scorpion","Archer","Mountain Sea-Goat","Water Bearer","Fish"
        };

        private DateTime _birthDate;
        internal bool Valid { get; private set; }
        internal string Age { get; private set; }
        internal string WesternZodiac { get; private set; }
        internal string ChineseZodiac { get; private set; }

        internal BirthDateModel()
        {
            _birthDate = DateTime.Today;
        }

        internal DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                var today = DateTime.Today;
                var diffDateTime = today - value;
                var diffYears = (today.Year - value.Year) - (today.DayOfYear >= _birthDate.DayOfYear ? 0 : 1);
                Valid = diffDateTime.Days >= 0 && diffYears <= 135 ;
                if (Valid)
                {
                    Age = diffYears > 0 ? $"{diffYears} years" : $"{diffDateTime} days";
                    ChineseZodiac = ChineseZodiaсList[(_birthDate.Year + 8) % 12];
                }
            }
        }
    }
}

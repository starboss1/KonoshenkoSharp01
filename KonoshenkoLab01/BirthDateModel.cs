
using System;

namespace KMA.ProgrammingInCSharp2019.KonoshenkoLab01
{
    internal class BirthDateModel
    {

        private static readonly string[] ChineseZodiaсList = {"Rat","Ox","Tiger","Rabbit",
            "Dragon","Snake","Horse","Goat","Monkey","Rooster","Dog","Pig"
        };

        private static readonly string[] WesternZodiaсList = {"Aries","Taurus","Gemini","Cancer",
            "Leo","Virgo","Libra","Scorpio","Sagittarius","Capricorn","Aquarius","Pisces"
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
                    Age = diffYears > 0 ? $"{diffYears} years" : $"{diffDateTime.ToString().Substring(0,diffDateTime.ToString().IndexOf("."))} days";
                    ChineseZodiac = ChineseZodiaсList[(_birthDate.Year + 8) % 12];

                    var month = _birthDate.Month;
                    var day = _birthDate.Day;
                    int numberWesterZodiac;

                    switch (month)
                    {
                        case 1: // Jan
                            numberWesterZodiac = day <= 20 ? 9 : 10;
                            break;
                        case 2: //Feb
                            numberWesterZodiac = day <= 19 ? 10 : 11;
                            break;
                        case 3: //March
                            numberWesterZodiac = day <= 20 ? 11 : 0;
                            break;
                        case 4: //Apr
                            numberWesterZodiac = day <= 20 ? 0 : 1;
                            break;
                        case 5: //May
                            numberWesterZodiac = day <= 20 ? 1 : 2;
                            break;
                        case 6: //June
                            numberWesterZodiac = day <= 20 ? 2 : 3;
                            break;
                        case 7: //Jule
                            numberWesterZodiac = day <= 21 ? 3 : 4;
                            break;
                        case 8: //August
                            numberWesterZodiac = day <= 22 ? 4 : 5;
                            break;
                        case 9: //Sep
                            numberWesterZodiac = day <= 21 ? 5 : 6;
                            break;
                        case 10: //Oct
                            numberWesterZodiac = day <= 21 ? 6 : 7;
                            break;
                        case 11: //Nov
                            numberWesterZodiac = day <= 21 ? 7 : 8;
                            break;
                        case 12: //Dec
                            numberWesterZodiac = day <= 21 ? 8 : 9;
                            break;
                        default: // no way to be here
                            numberWesterZodiac = 0;
                            break;
                    }

                    WesternZodiac = WesternZodiaсList[numberWesterZodiac];
                }
                else
                {
                    Age = "";
                    ChineseZodiac = "";
                    WesternZodiac = "";
                }
            }
        }

        public bool IsBirthday
        {
            get
            {
                var today = DateTime.Today;
                return today.Month == _birthDate.Month && today.Day == _birthDate.Day;
            }
        }
    }
}

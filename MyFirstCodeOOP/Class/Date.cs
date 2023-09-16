﻿using System;
using System.Reflection.Metadata.Ecma335;

namespace MyFirstCodeOOP.Class
{
    public class Date
    {
        #region Fields
        public int _year;
        public int _month;
        public int _day;
        #endregion

        #region Constructor

        public Date(int year, int month, int day)
        {
            _year = ValidateYear(year);
            _month = ValidateMonth(month);
            _day = ValidateDay(year, month, day);
        }

        #endregion

        #region Methods

        private int ValidateYear(int year)
        {
            if (year >= 1900)
            {
                return year;
            }

            throw new YearException(string.Format("The year {0} is invalid.", year));
        }

        private int ValidateDay(int year, int month, int day)
        {
            // Valido si el día pertenece a un año bisiesto
            if (month == 2 && day == 29 && IsLeapYear(year))
            {
                return day;
            }

            int[] daysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day >= 1 && day <= daysPerMonth[month])
            {
                return day;
            }

            throw new DayException(string.Format("The day {0} doesn't exist for month {1}.", day, month));
        }

        private int ValidateMonth(int month)
        {
            if (month >= 1 && month <= 12)
            {
                return month;
            }

            throw new MonthException(string.Format("The month {0} is invalid.", month));
        }

        public override string ToString()
            
        {
            var dateConcatenated = string.Format("{0:00}/{1:00}/{2:00}", _year, _month, _day);


            return dateConcatenated;
        }

        private bool IsLeapYear(int year)
        {
            return year % 400 == 0 || year % 4 == 0 && year % 100 != 0;
        }
        #endregion
    }
}

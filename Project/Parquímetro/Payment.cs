using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquímetro
{
    public class Payment
    {
        private readonly int WEEK_DAY_MINUTES = 660;
        private readonly int SATURDAY_MINUTES = 300;

        public double credits { get; set; }
        public double change = 0;
        public Area area { get; set; }

        public DateTime GetExitTime()
        {
            int paidMinutes = (int)Math.Ceiling((this.credits * 60) / this.area.hourPrice);

            switch (this.area.id)
            {
                case 1:
                case 2:
                    return Case1Or2(paidMinutes);

                // case 3:
                default:
                    return Case3(paidMinutes);
            }
        }

        private DateTime Case1Or2(int paidMinutes)
        {
            DateTime dateNow = DateTime.Now;
            DateTime exitTime = DateTime.Now;

            if (paidMinutes > this.area.maxTime)
            {
                int changeInMinutes = paidMinutes - (int)this.area.maxTime;
                this.change = GetChangeInEuros(changeInMinutes);
                paidMinutes -= changeInMinutes;
            }

            DateTime mondayAt9;
            DateTime weekDayAt9;

            switch (dateNow.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    mondayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.AddDays(1).Day, 9, 0, 0);
                    return mondayAt9.AddMinutes(paidMinutes);

                case DayOfWeek.Saturday:
                    if (exitTime.Hour < 9)
                    {
                        DateTime saturdayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 9, 0, 0);
                        return saturdayAt9.AddMinutes(paidMinutes);
                    }
                    else if (exitTime.Hour >= 14)
                    {
                        mondayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.AddDays(2).Day, 9, 0, 0);
                        return mondayAt9.AddMinutes(paidMinutes);
                    }
                    else
                    {
                        DateTime saturdayAt14 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 14, 0, 0);
                        int minutesUntil14 = (int)(saturdayAt14 - dateNow).TotalMinutes;

                        if (paidMinutes > minutesUntil14)
                        {
                            mondayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.AddDays(2).Day, 9, 0, 0);
                            return mondayAt9.AddMinutes(paidMinutes - minutesUntil14);
                        }
                        return exitTime.AddMinutes(paidMinutes);
                    }

                default:
                    if (exitTime.Hour < 9)
                    {
                        weekDayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 9, 0, 0);
                        return weekDayAt9.AddMinutes(paidMinutes);
                    }
                    else if (exitTime.Hour >= 20)
                    {
                        weekDayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.AddDays(1).Day, 9, 0, 0);
                        return weekDayAt9.AddMinutes(paidMinutes);
                    }
                    else
                    {
                        DateTime weekDayAt20 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 20, 0, 0);
                        int minutesUntil20 = (int)(weekDayAt20 - dateNow).TotalMinutes;

                        if (paidMinutes > minutesUntil20)
                        {
                            DateTime nextWeekDayAt9 = new DateTime(dateNow.Year, dateNow.Month, dateNow.AddDays(1).Day, 9, 0, 0);
                            return nextWeekDayAt9.AddMinutes(paidMinutes - minutesUntil20);
                        }
                        return exitTime.AddMinutes(paidMinutes);
                    }
            }
        }

        private DateTime Case3(int paidMinutes)
        {
            DateTime dateNow = DateTime.Now;
            DateTime exitTime = DateTime.Now;

            while (true)
            {
                switch (exitTime.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                        if (paidMinutes > WEEK_DAY_MINUTES)
                        {
                            paidMinutes -= WEEK_DAY_MINUTES;
                            exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                            continue;
                        }
                        return exitTime.AddMinutes(paidMinutes);

                    case DayOfWeek.Saturday:
                        if (exitTime.Hour < 9)
                        {
                            if (paidMinutes > SATURDAY_MINUTES)
                            {
                                paidMinutes -= SATURDAY_MINUTES;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(2).Day, 9, 0, 0);
                                continue;
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }
                        else if (exitTime.Hour >= 14)
                        {
                            exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(2).Day, 9, 0, 0);
                            if (paidMinutes > WEEK_DAY_MINUTES)
                            {
                                paidMinutes -= WEEK_DAY_MINUTES;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                                continue;
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }
                        else
                        {
                            DateTime saturdayAt14 = new DateTime(exitTime.Year, exitTime.Month, exitTime.Day, 14, 0, 0);
                            int minutesUntil14 = (int)(saturdayAt14 - exitTime).TotalMinutes;
                            if (paidMinutes > minutesUntil14)
                            {
                                paidMinutes -= minutesUntil14;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(2).Day, 9, 0, 0);
                                if (paidMinutes > WEEK_DAY_MINUTES)
                                {
                                    paidMinutes -= WEEK_DAY_MINUTES;
                                    exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                                    continue;
                                }
                                return exitTime.AddMinutes(paidMinutes);
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }

                    default:
                        if (exitTime.Hour < 9)
                        {
                            if (paidMinutes > WEEK_DAY_MINUTES)
                            {
                                paidMinutes -= WEEK_DAY_MINUTES;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                                continue;
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }
                        else if (exitTime.Hour >= 20)
                        {
                            exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                            if (exitTime.DayOfWeek == DayOfWeek.Saturday)
                            {
                                continue;
                            }
                            if (paidMinutes > WEEK_DAY_MINUTES)
                            {
                                paidMinutes -= WEEK_DAY_MINUTES;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                                continue;
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }
                        else
                        {
                            DateTime weekDayAt20 = new DateTime(exitTime.Year, exitTime.Month, exitTime.Day, 20, 0, 0);
                            int minutesUntil20 = (int)(weekDayAt20 - exitTime).TotalMinutes;

                            if (paidMinutes > minutesUntil20)
                            {
                                paidMinutes -= minutesUntil20;
                                exitTime = new DateTime(exitTime.Year, exitTime.Month, exitTime.AddDays(1).Day, 9, 0, 0);
                                continue;
                            }
                            return exitTime.AddMinutes(paidMinutes);
                        }
                }

            }
        }

        private double GetChangeInEuros(int changeInMinutes)
        {
            return Math.Round((changeInMinutes * this.area.hourPrice) / 60, 2);
        }
    }
}
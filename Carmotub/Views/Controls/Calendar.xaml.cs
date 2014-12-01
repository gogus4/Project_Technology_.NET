using Carmotub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfScheduler;

namespace Carmotub.Views.Controls
{
    public partial class Calendar : UserControl
    {
        private static Calendar _instance = null;
        public static Calendar Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Calendar();
                return _instance;
            }
        }

        public DateTime CurrentDate { get; set; }
        public Calendar()
        {
            InitializeComponent();

            _instance = this;
        }

        private void scheduler1_OnEventDoubleClick(object sender, Event ev)
        {

        }

        private void scheduler1_OnScheduleDoubleClick(object sender, DateTime ev)
        {
            // Add intervention with calendar
        }

        public void SelectMonth(int month)
        {
            switch (month)
            {
                case 1:
                    CurrentMonthAndYear.Text = "Janvier " + CurrentDate.Year;
                    break;

                case 2:
                    CurrentMonthAndYear.Text = "Février " + CurrentDate.Year;
                    break;

                case 3:
                    CurrentMonthAndYear.Text = "Mars " + CurrentDate.Year;
                    break;

                case 4:
                    CurrentMonthAndYear.Text = "Avril " + CurrentDate.Year;
                    break;

                case 5:
                    CurrentMonthAndYear.Text = "Mai " + CurrentDate.Year;
                    break;

                case 6:
                    CurrentMonthAndYear.Text = "Juin " + CurrentDate.Year;
                    break;

                case 7:
                    CurrentMonthAndYear.Text = "Juillet " + CurrentDate.Year;
                    break;

                case 8:
                    CurrentMonthAndYear.Text = "Août " + CurrentDate.Year;
                    break;

                case 9:
                    CurrentMonthAndYear.Text = "Septembre " + CurrentDate.Year;
                    break;

                case 10:
                    CurrentMonthAndYear.Text = "Octobre " + CurrentDate.Year;
                    break;

                case 11:
                    CurrentMonthAndYear.Text = "Novembre " + CurrentDate.Year;
                    break;

                case 12:
                    CurrentMonthAndYear.Text = "Décembre " + CurrentDate.Year;
                    break;
            }
        }

        private async void AddMonth_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);
            scheduler1.SelectedDate = CurrentDate;
            SelectMonth(CurrentDate.Month);

            await refreshCalendar();
        }

        private async void RemoveMonth_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            scheduler1.SelectedDate = CurrentDate;
            SelectMonth(CurrentDate.Month);

            await refreshCalendar();
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            CurrentDate = DateTime.Now;
            await InterventionVM.Instance.GetAllIntervention();

            await refreshCalendar();
        }

        public async Task refreshCalendar()
        {
            List<Dictionary<string, string>> interventions = new List<Dictionary<string, string>>();
            scheduler1.SelectedDate = CurrentDate;
            SelectMonth(CurrentDate.Month);

            await InterventionVM.Instance.GetAllIntervention();

            // LINQ
            foreach (Dictionary<string, string> d in InterventionVM.Instance.Interventions)
            {
                foreach (KeyValuePair<string, string> keyValue in d)
                {
                    try
                    {
                        if (keyValue.Key == "date_intervention" && keyValue.Value.ToString().Substring(3, 2) == CurrentDate.Month.ToString() && keyValue.Value.ToString().Substring(6, 4) == CurrentDate.Year.ToString())
                        {
                            interventions.Add(d);
                        }
                    }
                    catch (Exception E) { }
                }
            }

            Dictionary<string, string> customer = new Dictionary<string, string>();

            foreach (var inter in interventions)
            {
                // LINQ
                foreach (Dictionary<string, string> d in CustomerVM.Instance.Customers)
                {
                    foreach (KeyValuePair<string, string> keyValue in d)
                    {
                        try
                        {
                            if (keyValue.Key == "identifiant" && keyValue.Value.ToString() == inter["identifiant_client"])
                            {
                                customer = d;
                                continue;
                            }
                        }
                        catch (Exception E) { }
                    }
                }

                var year = int.Parse(inter["date_intervention"].ToString().Substring(6, 4));
                var month = int.Parse(inter["date_intervention"].ToString().Substring(3, 2));
                var day = int.Parse(inter["date_intervention"].ToString().Substring(0, 2));

                DateTime date = new DateTime(year, month, day);
                Event evenement = new Event() { Start = date, End = date, Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = customer["nom"] + " " + customer["adresse"] };

                if (scheduler1.Events.Where(x => x.Subject == customer["nom"] + " " + customer["adresse"] && x.Start == evenement.Start).FirstOrDefault() == null)
                    scheduler1.Events.Add(evenement);
            }
        }

        private async void RefreshCalendar_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);
            scheduler1.SelectedDate = CurrentDate;

            CurrentDate = CurrentDate.AddMonths(-1);
            scheduler1.SelectedDate = CurrentDate;
            SelectMonth(CurrentDate.Month);

            await refreshCalendar();
        }
    }
}
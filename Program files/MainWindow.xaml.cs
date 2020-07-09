using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Web.Script.Serialization;

namespace StudentsTeachers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton Rbtn;
        public List<Student> StudList { get; set; }
        public List<Teacher> TeachList { get; set; }
        private int ageCalc { get; set; }
        private int day, month, year, sex, egnSum, validSum;
        private string birthdayYear;
        private int[] egn_weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public MainWindow()
        {
            InitializeComponent();
            StudentChoice.IsChecked = true;
            StudList = new List<Student>();
            TeachList = new List<Teacher>();
        }

        private void StudentChoice_Checked(object sender, RoutedEventArgs e)
        {
            Rbtn = (RadioButton)sender;
            if (Rbtn.IsChecked == true)
            {
                if (Rbtn.Content.Equals("Student"))
                {
                    differentF.Content = "Faculty number";
                }
                if (Rbtn.Content.Equals("Teacher"))
                {
                    differentF.Content = "Subject";
                }
            }
        }

        private void signup_btn(object sender, RoutedEventArgs e)
        {
            if (Rbtn.Content.Equals("Student"))
            {
                Student stud = new Student(name.Text, surname.Text, Convert.ToInt32(age.Text), egn.Text, gender.Text, birthday.SelectedDate.Value.Date, extraField.Text);
                this.DataContext = stud;
                StudList.Add(stud);
                string json = JsonConvert.SerializeObject(StudList.ToArray(), Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Users\atanaska\source\repos\StudentsTeachers\students_json.txt", json);
                MessageBox.Show(json);
            }
            else if (Rbtn.Content.Equals("Teacher"))
            {
                Teacher teach = new Teacher(name.Text, surname.Text, Convert.ToInt32(age.Text), egn.Text, gender.Text, birthday.SelectedDate.Value.Date, extraField.Text);
                this.DataContext = teach;
                TeachList.Add(teach);
                string json = JsonConvert.SerializeObject(TeachList.ToArray(), Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Users\atanaska\source\repos\StudentsTeachers\teachers_json.txt", json);
                MessageBox.Show(json);
            }
            MessageBox.Show("Successful log");
        }

        private void View_All(object sender, RoutedEventArgs e)
        {
            ViewTeachersStudents report = new ViewTeachersStudents();
            report.Show();
            Close();
        }

        private void ClearForm(object sender, RoutedEventArgs e)
        {
                name.Text = "";
                surname.Text = "";
                age.Text = "";
                egn.Text = "";
                extraField.Text = "";
                gender.SelectedValue = null;
                //birthday.SelectedDate = null;
        }

        private void DateEntered(object sender, RoutedEventArgs e)
        {
            ageCalc = DateTime.Now.Year - birthday.SelectedDate.Value.Year;
            if (ageCalc > 7 && ageCalc < 100)
            {
                age.Text = ageCalc.ToString();
                age.BorderBrush = Brushes.LightSlateGray;
            }
            else
            {
                age.Text = ageCalc.ToString();
                age.BorderBrush = Brushes.Red;
            }
        }

        private void EgnValidator(object sender, RoutedEventArgs e)
        {
             if (egn.Text.Length == 10)
             {
                 year = Convert.ToInt32(egn.Text.Substring(0, 2));
                 month = Convert.ToInt32(egn.Text.Substring(2, 2));
                 day = Convert.ToInt32(egn.Text.Substring(4, 2));
                 sex = Convert.ToInt32(egn.Text.Substring(8, 1));
                 birthdayYear = birthday.SelectedDate.Value.Year.ToString().Substring(2,2);

                 if (day == Convert.ToInt32(birthday.SelectedDate.Value.Day) && month == Convert.ToInt32(birthday.SelectedDate.Value.Month) && year == Convert.ToInt32(birthdayYear))
                 {
                     if ((gender.Text.Equals("Female") && (sex%2 !=0)) || (gender.Text.Equals("Male") && (sex % 2 == 0)))
                     {
                         for(int i = 0; i < 9; i++)
                         {
                             egnSum += Convert.ToInt32(egn.Text.Substring(i, 1)) * egn_weights[i];
                         }
                         validSum = egnSum % 11;
                         if((validSum == 10)&&(Convert.ToInt32(egn.Text.Substring(9, 1))==0) || (validSum < 10) && (Convert.ToInt32(egn.Text.Substring(9, 1)) == validSum))
                         {
                             egn.BorderBrush = Brushes.LightSlateGray;
                         }
                     }
                 }
             }
             else
             {
                 egn.BorderBrush = Brushes.Red;
             }
         }
    }
}

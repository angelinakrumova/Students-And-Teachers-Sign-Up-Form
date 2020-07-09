using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Newtonsoft.Json;
using StudentsTeachers;

namespace StudentsTeachers
{
    /// <summary>
    /// Interaction logic for ViewTeachersStudents.xaml
    /// </summary>
    public partial class ViewTeachersStudents : Window
    {
       

        public ViewTeachersStudents()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            List<Student> StudJson = new List<Student>();
            List<Teacher> TeachJson = new List<Teacher>();

            LoadJson<Student>("C:\\Users\\atanaska\\source\\repos\\StudentsTeachers\\students_json.txt", ref StudJson);
            LoadJson<Teacher>("C:\\Users\\atanaska\\source\\repos\\StudentsTeachers\\teachers_json.txt", ref TeachJson);

            for (int i=0;i < StudJson.Count; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = StudJson[i].toString();
                studentsList.Items.Add(itm);
            }
            for (int i = 0; i < TeachJson.Count; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = TeachJson[i].toString();
                teachersList.Items.Add(itm);
            }
        }

        private void LoadJson<T>(string filename, ref List<T> items)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace Day04GridView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> peopleList = new List<Person>();
        private Person selectedPerson;

        public MainWindow()
        {
            InitializeComponent();
            lvPeople.ItemsSource = peopleList;
            lvPeople.Items.Refresh();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if (null == selectedPerson)
            {
                MessageBox.Show(this, "You must select one person to delete", "Operation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show(this, $"Do you want to delete the person <{selectedPerson}> ?", "Operation Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBoxResult.Yes == messageBoxResult)
            {
                tbName.Text = "";
                tbAge.Text = "";
                peopleList.Remove(selectedPerson);
                lvPeople.Items.Refresh();
            }
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (null == selectedPerson)
            {
                MessageBox.Show(this, "You must select a person to edit", "Operation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string name = tbName.Text;
            if (0 == name.Trim().Length)
            {
                MessageBox.Show(this, "Name must be 1-150 characters", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be 1-150", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbAge.Text = "";
            tbName.Text = "";
            try
            {
                selectedPerson.Name = name;
                selectedPerson.Age = age;
                lvPeople.Items.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(this, ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            if (0 == name.Trim().Length)
            {
                MessageBox.Show(this, "Name must be 1-150 characters", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show(this, "Age must be 1-150", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbAge.Text = "";
            tbName.Text = "";
            try
            {
                peopleList.Add(new Person(name, age));
                lvPeople.Items.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(this, ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Internal Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPerson = (Person)lvPeople.SelectedItem;
            if (null != selectedPerson)
            {
                tbName.Text = selectedPerson.Name;
                tbAge.Text = selectedPerson.Age.ToString();
            }
        }
    }
}
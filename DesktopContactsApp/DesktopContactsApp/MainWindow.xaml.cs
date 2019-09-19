using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // access to contacts in all methods
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            // newContactWindow.Show();
            // ShowDialog does not allow the user to navigate back to the first window
            // until the new window is closed
            newContactWindow.ShowDialog();

            // reads database after possible addition of new contact
            ReadDatabase();
        }

        // Language Integrated Query, allows queries in C#
        // Simple, and very useful
        // OrderBy and Where are added by Linq
        // It defines extension methods,
        // extending the functionality of a type,
        // sush as a list in this case

        void ReadDatabase()
        {

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                // make sure a contact table exists before we actually try to read from it
                // if one already exists nothing happens

                conn.CreateTable<Contact>();
                
                // return the query results as a list 

                contacts = (conn.Table<Contact>().ToList()).OrderBy(con => con.Name).ToList();

               /*
                var variable = from c2 in contacts
                               orderby c2.Name;
                               select c2;

                all this stuff is encapsulated in the above stuff
                => lambda used to tell how to order, such as by name etc.
                */ 
             }

            if (contacts != null)
            {
                // foreach(var person in contacts)
                // {
                //    contactsListView.Items.Add(new ListViewItem() {
                //        // properties of the ListViewItem
                //        Content = person
                //    });
                // }

                // pretty much does the same as above, but don't
                // have to worry about adding elements already displayed again
                // uses the list of contacts directly, will only ever display how many elements in the list there are

                // Data Binding
                contactsListView.ItemsSource = contacts;
            }
        }

        // filtering for searching

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            // Where filters results
            var filteredList = contacts.Where(con => con.Name.ToLower().Contains(searchTextBox.Text)).ToList();

            /*
             * 
             * This stuff all encapsulated above
             * Structured like SQL queries
             * Can create complex queries
             
            var filteredList2 = (from c3 in contacts
                                where c3.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                orderby c3.Email
                                select c3).ToList();

            */

            contactsListView.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // cast selected item to Contact because we know the object contained in the LV are Contacts
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();
            }
        }
    }
}

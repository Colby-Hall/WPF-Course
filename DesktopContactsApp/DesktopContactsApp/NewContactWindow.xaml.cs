using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO Save contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };

            // create database path
            // three lines were moved from here to App.xaml.cs, since it didn't make sense to leave all
            // the database path stuff here in an event handler method


            // create database connection
            // can only have one connection open at a time
            // *using* statement allows one to define one element that only exists within a certain context, such as the body below
            // *using* keyword requires the object to implement the IDisposable interface
            // Dispose disposes of an object one the code execution exits the context
            // reduces the risk of forgetting to explicitly close a connection

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {

                // create table
                // generic parameters; table will only accept contact types
                // line ignored if table already exists

                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            
            
            
            // Dispose method closes connection after code execution leaves the above body
            // Obviously connection can only be used inside that bosy

           // connection.Close(); 
           // inelegant solution

            // close the connection so the next time the window is opened, a new contact can be entered

            

            // closes window after contact is saved
            // this.Close(); not necessary, knows it refers to current window
            Close();
        }
    }
}

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

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl

        //propdp snippet
    {
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContactProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() { Name = "Name", Phone = "Number", Email = "Email" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // allows access to all of the text blocks in the contact control
            ContactControl control = d as ContactControl;

            if (control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        // A callback is a method that is executed every time the property changes




        /* Replacing with a dependency property
    
        private Contact contact;

        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                nameTextBlock.Text = contact.Name;
                emailTextBlock.Text = contact.Email;
                phoneTextBlock.Text = contact.Phone;
            }
        }
        */


        public ContactControl()
        {
            InitializeComponent();
        }
    }
}

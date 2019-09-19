using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {

        // prop code snippet smaller than propfull
        // private field etc. stuff going on in the background, C# compiler understands
        // makes code more concise

        // a primary key is a unique identifier for each element in the table
        // marks the Id key as the PrimaryKey for the contact class
        // AutoIncrement increments the Id of each contact added to the table

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // override so ListView doesn't just display the object identifier
        // irrelevant after other changes
        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}

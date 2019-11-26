using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Models
{
    public class Contact
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_initial { get; set; }
        public string Home_phone { get; set; }
        public string Cell_phone { get; set; }
        public string Office_ext { get; set; }
        public int IRD { get; set; }
        public bool active { get; set; }

        public static List<Contact> ListOfContacts()
        {
            List<Contact> contacts = new List<Contact> {
                new Contact() { First_name = "Steve", Last_name = "Jones", Middle_initial = "T", Home_phone = "1243", Cell_phone = "1243", Office_ext = "1243", IRD = 1243, active = false },
                new Contact() { First_name = "Bob", Last_name = "Jeff", Middle_initial = "T", Home_phone = "1243", Cell_phone = "1243", Office_ext = "1243", IRD = 1243, active = false },
                new Contact() { First_name = "Blake", Last_name = "Jones", Middle_initial = "T", Home_phone = "1243", Cell_phone = "1243", Office_ext = "1243", IRD = 1243, active = false }
            };
            return contacts;
           
        }
        

    }


}

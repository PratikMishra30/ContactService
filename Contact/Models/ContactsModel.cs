using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact.Models
{
    public class ContactsModel
    {
        public int ContactID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

    }
}
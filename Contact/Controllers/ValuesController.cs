using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Contact.Models;

using ContactBAL.Factory;
using ContactBAL.Interface;
using ContactDTO;

namespace Contact.Controllers
{
/// <summary>
/// Controller for get,set,update and delete contact details 
/// </summary>
    public class ValuesController : ApiController
    {
        //declaring interface object
        private IContactBusinessObject _contactBusinessObject = null;
        
        /// <summary>
        /// Method to get all the contacts  
        /// </summary>
        /// <returns>List of Contacts</returns>        
        [HttpGet]
        public IEnumerable<ContactsModel> GetAllContacts()
        {
            //Invoking instance of ContactBusinessObject and referencing to interface  object
            _contactBusinessObject = ContactBusinessObjectFactory.Create();

            //Calling Business Access Layer ContactBusinessObject class method GetAllContact with interface reference
            var allContactList = _contactBusinessObject.GetAllContact();

            //Assigning contact details to json object
            var contactList = allContactList.Select(l => new ContactsModel
                {
                    ContactID = l.ID,
                    ContactFirstName = l.FirstName,
                    ContactLastName = l.LastName,
                    Email = l.EmailID,
                    PhoneNumber =l.PhoneNumber,
                    Status =l.Status
                });


            return contactList;    
        }
        /// <summary>
        /// Method to get single contact
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns>Single Contact</returns>
        [HttpGet]
        public ContactsModel GetContact(int contactID)
        {
            //Invoking instance of ContactBusinessObject and referencing to interface  object
            _contactBusinessObject = ContactBusinessObjectFactory.Create();

            //Calling Business Access Layer ContactBusinessObject class method GetContact with interface reference
            var contact = _contactBusinessObject.GetContact(contactID);

            //Assigning contact details to json object
            ContactsModel obj = new ContactsModel();
          
            obj.ContactID = contact.ID;
            obj.ContactFirstName = contact.FirstName;
            obj.ContactLastName = contact.LastName;
            obj.Email = contact.EmailID;
            obj.PhoneNumber = contact.PhoneNumber;
            obj.Status = contact.Status;           

         return obj;
        }

        /// <summary>
        /// Method to Save and Update Contact
        /// For save pass cont.ContactID=0
        /// For update pass cont.ContactID=(Find ContactID of ContactFirstName whose details to be updated(on clientSide))
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        [HttpPost]
        public bool SaveContact([FromBody] ContactsModel cont)
        {
            //Invoking instance of ContactBusinessObject and referencing to interface  object
            _contactBusinessObject = ContactBusinessObjectFactory.Create();

            //Assigning json data to Data Transfer Object(DTO)
            var contact = new ContactObj
            {
                ID = cont.ContactID,
                FirstName = cont.ContactFirstName,
                LastName = cont.ContactLastName,
                EmailID = cont.Email,
                PhoneNumber = cont.PhoneNumber,
                Status = cont.Status
            };

            //Calling Business Access Layer(BAL) ContactBusinessObject class method SaveContact with interface reference
            var res = _contactBusinessObject.SaveContact(contact);

            //if res>=1,save or update successful
            if (res >= 1)
            {
               return true;
            }

            //else returns 
            return false;
        }

        /// <summary>
        /// Method to delete contact
        /// ID=(Find ContactID of ContactFirstName whose details to be deleted(on clientSide))
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool DeleteContact(int ID)
        {
            //Invoking instance of ContactBusinessObject and referencing to interface  object
            _contactBusinessObject = ContactBusinessObjectFactory.Create();

            //Calling Business Access Layer(BAL) ContactBusinessObject class method DeleteContact with interface reference
            var res = _contactBusinessObject.DeleteContact(ID);

            //if res>=1,save or update successfull
            if (res >= 1)
            {
                return true;
            }

            //else returns 
            return false;
        }
    }
}

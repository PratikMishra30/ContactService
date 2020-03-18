using System;
using System.Collections.Generic;
using ContactBAL.Interface;
using ContactDAL.Factory;
using ContactDAL.Interface;
using ContactDTO;


namespace ContactBAL.Base
{
    public class ContactBusinessObject:IContactBusinessObject
    {
        #region DataMember
        private IContactRepository _contactRepository;
        #endregion

        #region Constructor
        public ContactBusinessObject()
        {
            _contactRepository = ContactRepositoryFactory.Create();
        }
              
        #endregion

        #region PublicRepository

        
        public int DeleteContact(int contactID)
        {
            try
            {
                return _contactRepository.Delete(contactID);
            }
            catch (Exception ex)
            {

                throw new Exception("UNABLE TO DELETE CONTACT", ex);
            }
             
        }
        public List<ContactObj> GetAllContact()
        {
            try
            {
                return _contactRepository.GetAllContacts();
            }
            catch (Exception ex)
            {
                throw new Exception("UNABLE TO GET ALL CONTACT", ex);
            }
        }
        public ContactObj GetContact(int contactID)
        {
            try
            {
                return _contactRepository.GetContact(contactID);
            }
            catch (Exception ex)
            {
                throw new Exception("UNABLE TO GET CONTACT", ex);
            }
        }
        public int SaveContact(ContactObj contact)
        {
            try
            {
                return _contactRepository.Save(contact);
            }
            catch (Exception ex)
            {
                throw new Exception("UNABLE TO SAVE CONTACT", ex);
            }
        }
        #endregion
    }
}

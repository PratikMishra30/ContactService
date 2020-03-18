using System.Collections.Generic;
using ContactDTO;

namespace ContactDAL.Interface
{
    public interface IContactRepository
    {
        int Delete(int contactID);
        List<ContactObj> GetAllContacts();
        int Save(ContactObj contacts);
        ContactObj GetContact(int contactID);
    }
}

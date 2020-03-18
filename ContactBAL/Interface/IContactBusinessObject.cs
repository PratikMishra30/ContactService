using System.Collections.Generic;
using ContactDTO;

namespace ContactBAL.Interface
{
    public interface IContactBusinessObject
    {
        int DeleteContact(int contactID);
        List<ContactObj> GetAllContact();
        ContactObj GetContact(int contactID);
        int SaveContact(ContactObj contact);
    }
}

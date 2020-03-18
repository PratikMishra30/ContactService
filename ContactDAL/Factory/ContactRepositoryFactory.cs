using ContactDAL.Interface;
using ContactDAL.Base;

namespace ContactDAL.Factory
{
    public static class ContactRepositoryFactory
    {
        public static IContactRepository Create()
        {
            return new ContactRepository();
        }
    }
}

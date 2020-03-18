using ContactBAL.Interface;
using ContactBAL.Base;

namespace ContactBAL.Factory
{
   public static class ContactBusinessObjectFactory
    {
        public static IContactBusinessObject Create()
        {
            return new ContactBusinessObject();
        }
    }
}

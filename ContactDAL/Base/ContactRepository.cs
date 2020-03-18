using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ContactDTO;
using ContactCAL;
using System.Data;
using ContactDAL.Interface;


namespace ContactDAL.Base
{
    public class ContactRepository:BaseRepository,IContactRepository
    {
        public int Delete(int contactID)
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = SPConstants.ID, Value=contactID, SqlDbType = SqlDbType.Int }               
            };
            
            int result = ExecuteNonQuery(SPConstants.SP_DELETE_CONTACT, sqlParameters);
            return result;
        }

        public List<ContactObj> GetAllContacts()
        {
            DataSet dsContacts;
            var contactList = new List<ContactObj>();   
            
            dsContacts = ExecuteDataSet(SPConstants.SP_GET_ALL_CONTACT);
         

            contactList = dsContacts.Tables[0].AsEnumerable().Select(l => new ContactObj
            {
                ID = Convert.ToInt32(l.Field<int>(SPConstants.ID).ToString()),
                FirstName = l.Field<string>(SPConstants.FIRST_NAME).ToString(),
                LastName = l.Field<string>(SPConstants.LAST_NAME),
                EmailID = l.Field<string>(SPConstants.EMAIL_ID),
                PhoneNumber =(l.Field<string>(SPConstants.PHONE_NUMBER).ToString()),
                Status = Convert.ToBoolean(l.Field<bool>(SPConstants.STATUS).ToString()),
            }).ToList();

            return contactList;
        }

        public ContactObj GetContact(int contactID)
        {
            DataSet dsContacts;
                    
                var sqlParameter = new List<SqlParameter>{new SqlParameter
                { ParameterName = SPConstants.ID,
                  Value = contactID,
                  SqlDbType = SqlDbType.Int }};

                dsContacts = ExecuteDataSet(SPConstants.SP_GET_CONTACT, sqlParameter);

            ContactObj contact = new ContactObj();
            var obj=dsContacts.Tables[0].Rows[0];

                contact.ID = Convert.ToInt32(obj.Field<int>(SPConstants.ID).ToString());
                contact.FirstName = obj.Field<string>(SPConstants.FIRST_NAME).ToString();
                contact.LastName = obj.Field<string>(SPConstants.LAST_NAME);
                contact.EmailID = obj.Field<string>(SPConstants.EMAIL_ID);
                contact.PhoneNumber = (obj.Field<string>(SPConstants.PHONE_NUMBER).ToString());
                contact.Status = Convert.ToBoolean(obj.Field<bool>(SPConstants.STATUS).ToString());
           
            return contact;
        }
        public int Save(ContactObj contacts)
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter {ParameterName = SPConstants.ID, Value=contacts.ID, SqlDbType = SqlDbType.Int },
                new SqlParameter {ParameterName=SPConstants.FIRST_NAME, Value=contacts.FirstName, SqlDbType= SqlDbType.NVarChar },
                new SqlParameter {ParameterName=SPConstants.LAST_NAME, Value=contacts.LastName,SqlDbType=SqlDbType.NVarChar},
                new SqlParameter {ParameterName = SPConstants.EMAIL_ID, Value=contacts.EmailID, SqlDbType = SqlDbType.NVarChar },
                new SqlParameter {ParameterName=SPConstants.PHONE_NUMBER, Value=contacts.PhoneNumber, SqlDbType=SqlDbType.NVarChar },
                new SqlParameter {ParameterName=SPConstants.STATUS, Value=contacts.Status, SqlDbType=SqlDbType.Bit },

            };
            int result = ExecuteNonQuery(SPConstants.SP_SAVE_CONTACT, sqlParameters);
            return result;
        }
    }
}

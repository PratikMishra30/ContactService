# ContactService
Git hub repository for Contact Service
Pre-requisite -MS SQL Server
Create DB with name Contact
Run the DB Scripts(Create table and SP's)
For Save and Update same SP is used(for save pass ContactID=0,for update pass ContactID of the Contact which is to be updated)
The value of ContactID for updating record can be easily extracted from ContactList ContactFirstName field  on Client side and passed to api.
In Contact Service web config please change connection string data source
Contact Service uses layered architecture to get,put and delete data
Layered architecture contains Data Access Layer(DAL),Business Access Layer(BAL),Data Transfer Objects(DTO)


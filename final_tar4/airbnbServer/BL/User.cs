using Microsoft.AspNetCore.Mvc;

namespace tar2.BL
{
    public class User
    {
        string email;
        string firstName;
        string familyName;
        string password;
        bool isActive;
        bool isAdmin;

        public User()
        {
        }

        public string Email { get => email; set => email = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Password { get => password; set => password = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public User(string email, string firstName, string familyName, string password, bool isActive, bool isAdmin)
        {
            Email = email;
            FirstName = firstName;
            FamilyName = familyName;
            Password = password;
            IsActive = isActive;
            IsAdmin = isAdmin;
        }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertUser(this);
        }

        //public User Login()
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.LoginUser(this);
        //}

        public int Update(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateUser(this, email);
        }

        public List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }

        public int Delete(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteUser(email);
        }
    }
}

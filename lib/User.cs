using System;

namespace lib
{
    public class User
    {
        public User()
        {
        }

        public User(int user_id, string user_firstname, string user_lastname, string user_email, string user_password, int user_mobile, int account_status_id)
        {
            User_id = user_id;
            User_firstname = user_firstname;
            User_lastname = user_lastname;
            User_email = user_email;
            User_password = user_password;
            User_mobile = user_mobile;
            Account_status_id = account_status_id;
        }

        public int User_id { get; set; }
        public string User_firstname { get; set; }
        public string User_lastname { get; set; }
        public string User_email { get; set; }
        public string User_password { get; set; }
        public int User_mobile { get; set; }
        public int Account_status_id { get; set; }
    }
}

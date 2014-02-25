using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace billing_system.Classes
{
    //---------------2/9/2014....KasunEW----------------

    class User:DBConnection
    {
       
        private string Username;
        private string Password;
        private string DBUsername;
        private string DBPassword;
        private string Catagory;
        private string Quary;
        private MySqlCommand command;
        private MySqlDataReader reader;

        
        public User() 
        {
            DBUsername = null;
            DBPassword = null;
        }

       
        public string GetUsername 
        {
            get { return Username; }
            set { Username = value; }
        }

        
        public string GetPassword
        {
            get { return Password; }
            set { Password = value; }
        }

        
        public bool UsernameAuthenticaion() 
        {
            OpenConnection();

            Quary = "SELECT User_Name FROM users WHERE User_Name = '"+Username+"'";
            command = new MySqlCommand(Quary,connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DBUsername = reader.GetString(0);
            }
            reader.Close();
            CloseConnection();
            if (DBUsername == null)
            {
                
                return false;
            }
                return true;
        }

        
        public bool PasswordAuthenticaion()
        {
            OpenConnection();

            Quary = "SELECT Password FROM users WHERE Password = '" + Password + "'";
            command = new MySqlCommand(Quary, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                DBPassword = reader.GetString(0);
            }
            reader.Close();
            if (Password == null)
            {
               
                return false;
            }
            else
            {
              
                Quary = "SELECT Password FROM users WHERE User_Name = '" + Username + "'";
                command = new MySqlCommand(Quary, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DBPassword = reader.GetString(0);
                }
                reader.Close();
                CloseConnection();

                if (DBPassword == Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //---------------2/9/2014....KasunEW----------------

  
        public string UserCatagory() 
        {
            OpenConnection();

            Quary = "SELECT Catagory FROM users WHERE User_Name = '"+Username+"' AND Password = '"+Password+"'";
            command = new MySqlCommand(Quary, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Catagory = reader.GetString(0);
            }
            reader.Close();
            CloseConnection();

            return Catagory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace billing_system.Classes
{
    class ReorderForm
    {

        public void reorderLevel(object obj)
        {
            DBConnection db = new DBConnection();
            int billno = 0; 
            try
            {
                string query = "SELECT COUNT(Item_Code) FROM alert";
                int count = 0; //initialize count variable



                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString()); //check for existing bills



                    if (count < 1)
                        billno = 000001;    //first billno
                }
            }
            catch (Exception e)
            {


            }

        }
    }
}

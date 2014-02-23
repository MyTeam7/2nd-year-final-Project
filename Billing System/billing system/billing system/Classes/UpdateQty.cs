using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace billing_system.Classes
{
    class UpdateQty : DBConnection
    {
        private MySqlCommand command;
        private MySqlDataReader reader;
        private String Quary;
        private String Quary1;
        private String Qty_level;
        private int addQty;
        private int sum;
        private int checkReorder;
        private String checkLevel; 

        public void UserCatagory(int item_code,int new_Qty)
        {
            try
            {
                OpenConnection();

                Quary = "Select Quantity from items where Item_Code  ='" + item_code + "'";
                // Quary1 = "update items set Quantity = '" + sum + "' where Item_Code = '" + item_code + "'";
                command = new MySqlCommand(Quary, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Qty_level = reader.GetString(0);
                }
                reader.Close();
                addQty = int.Parse(Qty_level);//convert integer

                sum = new_Qty + addQty;

                Quary1 = "update items set Quantity = '" + sum + "' where Item_Code = '" + item_code + "'";
                MySqlCommand cmd = new MySqlCommand(Quary1, connection);
                cmd.ExecuteNonQuery();

                if (sum != null)
                {

                    string Quary2 = "Select Reorder_Level from items where Item_Code  ='" + item_code + "'";
                    MySqlCommand cmd2 = new MySqlCommand(Quary2, connection);
                    MySqlDataReader reader1 = command.ExecuteReader();
                    while (reader1.Read())
                    {
                        checkLevel = reader.GetString(0);
                    }
                    reader.Close();
                    checkReorder = int.Parse(checkLevel);

                    if (checkReorder < sum)
                    {

                        string Quary3 = "Delete from alert where Item_Code = '" + item_code + "'";
                        MySqlCommand cmd3 = new MySqlCommand(Quary3, connection);
                        cmd.ExecuteNonQuery();

                    }
                }

                CloseConnection();
            }
            catch (Exception ex) {

                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;          //Add MySql Library
using System.Data;
using System.Windows.Forms;

namespace billing_system.Classes
{
    // Aruna Udayanga--2/5/2014

    /// <summary>
    /// class for insert/update/delete
    /// </summary>
    class ItemDBConnection : DBConnection
    {

        public void Insert(int textboxCode, string txtboxDescription, decimal txtboxDiscount, decimal lowestPrice, decimal price, int textBox111, int textBox10)
        {

            string query = "INSERT items(Item_Code,Description,Discount,Lowest_Price,price,Quantity,Reorder_Level) VALUES('" + textboxCode + "','" + txtboxDescription + "','" + txtboxDiscount + "','" + lowestPrice + "','" + price + "','" + textBox10 + "','" + textBox111 + "')";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully .Item No : " + textboxCode + " , Item Name : " + txtboxDescription + "");

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update statement
        public void Update(int textboxCode, string txtboxDescription, decimal txtboxDiscount, decimal lowestPrice, decimal price, int textBox111, int textBox10)
        {

            string query = "UPDATE items SET Item_Code='" + textboxCode + "', Description='" + txtboxDescription + "',Discount='" + txtboxDiscount + "',Lowest_Price='" + lowestPrice + "',price='" + price + "',Reorder_Level='" + textBox111 + "',Quantity='" + textBox10 + "' WHERE Item_Code= '" + textboxCode + "'";

            DialogResult dialogResult = MessageBox.Show("Are you sure want to Update?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    //Open connection
                    if (this.OpenConnection() == true)
                    {
                        //create mysql command
                        MySqlCommand cmd = new MySqlCommand();
                        //Assign the query using CommandText
                        cmd.CommandText = query;


                        //Assign the connection using Connection
                        cmd.Connection = connection;

                        //Execute query
                        cmd.ExecuteNonQuery();

                        //close connection
                        this.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        //Delete statement

        public void Delete(int textboxCode)
        {
            string query = "Delete from items where Item_Code = '" + textboxCode + "'";

            DialogResult dialogResult = MessageBox.Show("Are you sure want to Delete?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                try
                {
                    if (this.OpenConnection() == true)
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        this.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }





        //-------------------startOfreorderFunction---------------------------------------------------------------------------------------------------------------------------------------------
        // RavishaHeshan(ravisha_weerasekara@yahoo.com)--2/21/2014

        public void reorder(string code, int qty)
        {
            DBConnection db = new DBConnection();
            try
            {
                if (db.OpenConnection() == true)
                {
                    int quantity = 0;
                    int reorder_level = 0;
                    string query = "SELECT Quantity, Reorder_Level FROM items WHERE Item_Code=" + code + "";
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    quantity = int.Parse(table.Rows[0].ItemArray[0].ToString());
                    reorder_level = int.Parse(table.Rows[0].ItemArray[1].ToString());

                    if (quantity <= reorder_level)
                    {

                        int result;
                        string query1 = "SELECT COUNT(Quantity) FROM alert WHERE Item_Code=" + code + "";
                        MySqlCommand cmd1 = new MySqlCommand(query1, db.connection);
                        result = int.Parse(cmd1.ExecuteScalar().ToString());



                        if (result == 0)
                        {
                            string query2 = "INSERT INTO alert(Item_Code,Quantity,Date,Time) VALUES('" + code + "','" + qty.ToString() + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss tt") + "')";
                            MySqlCommand cmd2 = new MySqlCommand(query2, db.connection);
                            cmd2.ExecuteNonQuery();
                        }


                    }





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }


        //-------------------endOfreorderFunction---------------------------------------------------------------------------------------------------------------------------------------------



    }
}

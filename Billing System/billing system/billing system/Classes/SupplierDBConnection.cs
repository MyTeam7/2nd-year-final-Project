using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace billing_system.Classes
{
    // Aruna Udayanga--2/21/2014

    /// <summary>
    /// class for supplier insert/update/delete
    /// </summary>
    class SupplierDBConnection : DBConnection
    {
        public void Insert(int textBox12, string textBox13, string textBox16, int textBox15, string textBox19, string textBox17)
        {

            string query = "INSERT suppliers(Supplier_ID,Supplier_Name,Supplier_Address,Supplier_Tp,Email,Company_Name) VALUES('" + textBox12 + "','" + textBox13 + "','" + textBox17 + "','" + textBox15 + "','" + textBox19 + "','" + textBox16 + "')";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add new supplier");

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
        public void Update(int textBox12, string textBox13, string textBox16, int textBox15, string textBox19, string textBox17)
        {

            string query = "UPDATE suppliers SET Supplier_ID='" + textBox12 + "', Supplier_Name='" + textBox13 + "',Company_Name='" + textBox16 + "',Supplier_Tp='" + textBox15 + "',Email='" + textBox19 + "',Supplier_Address='" + textBox17 + "' WHERE Supplier_ID= '" + textBox12 + "'";

            DialogResult dialogResult = MessageBox.Show("Are you sure want to Update?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    //Open connection
                    if (this.OpenConnection() == true)
                    {
                        //create mysql commandSupplier_Address
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
        public void Delete(int textBox12)
        {
            string query = "Delete from suppliers where Supplier_ID = '" + textBox12 + "'";

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
        //search supplier
        public void search(DataGridView dataGrid)
        {

            try
            {
                string query;

                if (OpenConnection() == true)
                {
                    query = "SELECT * From suppliers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);


                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = table;
                    dataGrid.DataSource = table;
                    adapter.Update(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bool a = CloseConnection();
            }
        }


        public void keyPress_SupplierSearch(TextBox textbox, DataGridView dataGrid) 
        {

            string querystring;

            if (textbox.Text == "")
            {
                querystring = "SELECT * From suppliers";
            }
            else
            {
                querystring = "SELECT * From suppliers WHERE Supplier_Name LIKE CONCAT('" + textbox.Text + "','%')";
            }

            try
            {
                if (OpenConnection() == true)
                {
                    //populate data gridview from result
                    MySqlCommand cmd = new MySqlCommand(querystring, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = table;
                    dataGrid.DataSource = bs;
                    dataGrid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);


                    if (dataGrid.RowCount > 0)
                    {

                        dataGrid.Rows[0].Selected = true; //auto select first record of datagridview if there is any record
                    }
                }

                else
                {
                    MessageBox.Show("DB Connection Error, Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
               CloseConnection();

            }
        }
    }
}

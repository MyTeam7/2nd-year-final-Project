using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace billing_system.Classes
{

    // Aruna Udayanga--2/5/2014

    /// <summary>
    /// class for Reorder Level
    /// </summary>
    class ReorderForm : DBConnection
    {
        //Adminpage alert message
        public void reorderLevel(object obj,Button Reorder)
        {
           
 
            try
            {
                string query = "SELECT COUNT(Item_Code) FROM alert GROUP BY Send_Info ";
                int count = 0;        //initialize count variable


                if (OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query,connection);
                    count = int.Parse(cmd.ExecuteScalar().ToString());     //check for existing bills


                    if (count < 1)
                    {
                        Reorder.Visible = false;
                    }
                    else
                    {
                        Reorder.Visible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errror Occured, Please Try Again, " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Reorder Form_load
        public void search(Object obj,DataGridView dataGrid)
        {
            string query = null;
             query = "SELECT * From alert ";
            
            try
            {
                
                if (OpenConnection() == true)
                {

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
                //add pic datagridview
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                dataGrid.Columns.Add(img);
                dataGrid.Columns[5].Visible = false;              
              
                for (int i = 0; i < dataGrid.RowCount; i++)
                {


                    if (dataGrid.Rows[i].Cells[5].Value.ToString() == "yes")
                    {

                        dataGrid.Rows[i].Cells["Status"].Value = Properties.Resources.green;

                    }
                    else
                    {
                        dataGrid.Rows[i].Cells["Status"].Value = Properties.Resources.red;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        //send supplier message
        public void sendSupplier(int AlertID, int sid,string name,string company_name,string sms,Object obj)
        {          

            string value = "YES";
            string query = "UPDATE alert SET Send_Info = '" + value + "' where Alert_ID= '" + AlertID + "' ";
            string query1 = "INSERT note(Note,Supplier_ID,Alert_ID,Date,Time) VALUES('" + sms + "','" + sid + "','" + AlertID + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm:ss tt") + "')";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query, connection);
                    MySqlCommand cmd2 = new MySqlCommand(query1, connection);
                    //Execute command
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Send Maseesage for supplier");
                    //close connection
                    this.CloseConnection();
                }
                //clear textbox
                Form5 fm5 = (Form5)obj;
                fm5.textBox12.Text = "";
                fm5.textBox13.Text = "";
                fm5.richTextBox1.Text = "";
                fm5.textBox16.Text = "";
                fm5.textBox19.Text = "";
                fm5.textBox15.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        //add textBox supplier Details
        public void clicButton(Object obj,string code) {

            string query1 = "SELECT suppliers.* FROM suppliers ,items as it where suppliers.Supplier_ID=it.Supplier_ID and it.Item_Code=" + code + "";

            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query1,connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                    Form5 Rf = (Form5)obj;
                    Rf.textBox12.Text = table.Rows[0].ItemArray[0].ToString();
                    Rf.textBox13.Text = table.Rows[0].ItemArray[1].ToString();
                    Rf.textBox19.Text = table.Rows[0].ItemArray[5].ToString();
                    Rf.textBox16.Text = table.Rows[0].ItemArray[4].ToString();
                    Rf.textBox15.Text = table.Rows[0].ItemArray[3].ToString();
                    


            }
        
        }


      


    }
}

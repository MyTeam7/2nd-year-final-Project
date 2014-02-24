using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;
using MySql.Data.MySqlClient;

namespace billing_system
{
    public partial class Admin : Form
    {
        public Login log;
        public String storekeeper_name;
        public Admin()
        {
            InitializeComponent();
        }

        public Admin(Login log) 
        {
            this.log = log;
            InitializeComponent();
        }
        public Admin(Login log,String storekeeper_name)
        {
            this.storekeeper_name = storekeeper_name;
            this.log = log;
            InitializeComponent();

        }

        //DataTable dbtable;
        private void button10_Click(object sender, EventArgs e)
        {

            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (textBox11.Text == "") || (textBox10.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);
                string txtboxDescription = txtBoxDescription.Text;
                decimal txtboxDiscount = decimal.Parse(txtBoxDiscount.Text);
                decimal lowestPrice = decimal.Parse(textBox2.Text);
                decimal price = decimal.Parse(textBox8.Text);
                int textBox111 = int.Parse(textBox11.Text);
                int textBox100 = int.Parse(textBox10.Text);

                

                ItemDBConnection adminDb = new ItemDBConnection();


                adminDb.Insert(textboxCode, txtboxDescription, txtboxDiscount, lowestPrice, price, textBox111,textBox100);
                clearItem();

            }

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            //-------------------Danusha Tharanga--------------------------------2/19/2014---------------------------
            if (storekeeper_name == "Storekeeper")
            {
                adminTabPg.TabPages.Remove(Items);
                adminTabPg.TabPages.Remove(Users);
                adminTabPg.TabPages.Remove(Report);
                adminTabPg.TabPages.Remove(Supplier);

            }
            //-------------------------------------------------------------------------------------------------------
            //-------------------Dilanka Rathnayaka------------------------------2/9/2014----------------------------
            Reports rep = new Reports();
            //set dates
            rep.FormLoadDateTimePicker(dateTimePicker1, dateTimePicker2);
            //Set Cashier names to combo box
            rep.FormLoadComboBox(comboBox1, comboBox2);
            //-------------------------------------------------------------------------------------------------------

            //-------------------Ravisha Weerasekara------------------------------2/7/2014----------------------------
            KeyPressEvent kpe = new KeyPressEvent();
           
            kpe.manualBilling("admin", "", this,"itm");
            
            kpe.manualBilling("admin", "", this,"qty");

            this.KeyPreview = true;
            this.textBox6.KeyDown += new KeyEventHandler(textBox6_KeyDown);
            this.textBox24.KeyDown += new KeyEventHandler(textBox24_KeyDown);
            //-------------------------------------------------------------------------------------------------------

            //---------------------------Aruna Udayana - supplier tab form_Load   ----------------------------------
            SupplierDBConnection supp = new SupplierDBConnection();
            supp.search(dataGridView4);
            //---------------------------------------------------------------------------

            ReorderForm reorder = new ReorderForm();
            reorder.reorderLevel(this,Reorder);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (textBox11.Text == "") || (textBox10.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);
                string txtboxDescription = txtBoxDescription.Text;
                decimal txtboxDiscount = decimal.Parse(txtBoxDiscount.Text);
                decimal lowestPrice = decimal.Parse(textBox2.Text);
                decimal price = decimal.Parse(textBox8.Text);
                int textBox111 = int.Parse(textBox11.Text);
                int textBox100 = int.Parse(textBox10.Text);

                ItemDBConnection itemupda = new ItemDBConnection();

                itemupda.Update(textboxCode, txtboxDescription, txtboxDiscount, lowestPrice, price, textBox111,textBox100); 
                clearItem();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if ((txtBoxCode.Text == "") || (txtBoxDescription.Text == "") || (txtBoxDiscount.Text == "") || (textBox2.Text == "") || (textBox8.Text == "") || (textBox11.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textboxCode = int.Parse(txtBoxCode.Text);

                ItemDBConnection itemdel = new ItemDBConnection();

                itemdel.Delete(textboxCode);
                clearItem();
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            KeyPressEvent kpe = new KeyPressEvent();
            kpe.manualBilling("admin", textBox6.Text, this);
          

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtBoxCode.Text = row.Cells["Item_Code"].Value.ToString();
                txtBoxDescription.Text = row.Cells["Description"].Value.ToString();
                txtBoxDiscount.Text = row.Cells["Discount"].Value.ToString();
                textBox2.Text = row.Cells["Lowest_Price"].Value.ToString();
                textBox8.Text = row.Cells["price"].Value.ToString();
                textBox11.Text = row.Cells["Reorder_Level"].Value.ToString();
                textBox10.Text = row.Cells["Quantity"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int User_ID = int.Parse(textBox7.Text);
                string Name = textBox1.Text;
                string Address = textBox3.Text;
                int Phone = int.Parse(textBox4.Text);
                string User_Name = textBox14.Text;
                string Password = textBox9.Text;
                string Catagory = comboBox3.Text;
                string Others = textBox5.Text;

                UserDbConnection userDB = new UserDbConnection();
                userDB.Insert(User_ID, Name, Address, Phone, User_Name, Password, Catagory, Others);
                clearUser();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int User_ID = int.Parse(textBox7.Text);
                string Name = textBox1.Text;
                string Address = textBox3.Text;
                int Phone = int.Parse(textBox4.Text);
                string User_Name = textBox14.Text;
                string Password = textBox9.Text;
                string Catagory = comboBox3.Text;
                string Others = textBox5.Text;

                UserDbConnection userDB = new UserDbConnection();
                userDB.Update(User_ID, Name, Address, Phone, User_Name, Password, Catagory, Others);
                clearUser();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox1.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox14.Text == "") || (textBox9.Text == "") || (comboBox3.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {

                int User_ID = int.Parse(textBox7.Text);
                UserDbConnection userDB = new UserDbConnection();

                userDB.Delete(User_ID);
                clearUser();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            //Admin item = new Admin();
            try
            {
                string query;

                if (db.OpenConnection() == true)
                {
                    query = "SELECT * From users";
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);


                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = table;
                    dataGridView2.DataSource = table;
                    adapter.Update(table);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured," + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bool a = db.CloseConnection();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                textBox7.Text = row.Cells["User_ID"].Value.ToString();
                textBox1.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Address"].Value.ToString();
                textBox4.Text = row.Cells["Phone"].Value.ToString();
                textBox14.Text = row.Cells["User_Name"].Value.ToString();
                textBox9.Text = row.Cells["Password"].Value.ToString();
                comboBox3.Text = row.Cells["Catagory"].Value.ToString();
                textBox5.Text = row.Cells["Others"].Value.ToString();
            }
        }
        public void clearItem()
        {
            txtBoxCode.Text = "";
            txtBoxDescription.Text = "";
            txtBoxDiscount.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
        }
        public void clearUser()
        {
            textBox7.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox14.Text = "";
            textBox9.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
        }


        private void textBoxValidation_KeyPress(object sender, KeyPressEventArgs e)
        {

            ValidationText tx = new ValidationText();
            tx.textBoxValidation_KeyPress(sender, e);


        }

        //-------------------Ravisha Weerasekara------------------------------2/7/2014----------------------------
        public void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                string keyVal;
                string keyCd;
                string searchKey;



                keyVal = e.KeyValue.ToString(); //keycode value
                keyCd = e.KeyCode.ToString().ToLower(); //character


                KeyPressEvent kpe = new KeyPressEvent();

                searchKey = kpe.manualSearchkey(keyVal, keyCd, "admin", "search", this);



                if (searchKey == "exit")
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        //---------------------------------------------------------------------------

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                string cmbText = comboBox4.Text;
                //comboBox4.Items.Clear();
                Reports rep = new Reports();
                rep.ComboBoxTextchange(comboBox4, cmbText);
            }
            else
                comboBox4.Items.Clear();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            /* if (comboBox1.SelectedIndex == 0)
             {
                 MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                 comboBox2.SelectedIndex = 0;
             }
             if (comboBox2.SelectedItem.ToString() == "NON")
             {
                 if (comboBox1.SelectedItem.ToString() == "NON")
                 {
                     comboBox4.Enabled = true;
                 }
                
             }
             else
                 comboBox4.Enabled = false;*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "NON")
            {
                comboBox4.Enabled = true;

            }
            else
            {

                comboBox4.Enabled = false;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "NON")
            {
                comboBox4.Enabled = true;

            }
            else
            {

                comboBox4.Enabled = false;
            }  
        }

        private void comboBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                comboBox2.SelectedIndex = 0;
            }
        }

        private void comboBox2_SelectedValueChanged_1(object sender, EventArgs e)
        {
            /* if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You Cant Sellect Any.Because No cashier Selected");
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox2.SelectedItem.ToString() == "NON")
            {
                if (comboBox1.SelectedItem.ToString() == "NON")
                {
                    comboBox4.Enabled = true;
                }
                
            }
            else
                comboBox4.Enabled = false;*/
        }

        private void comboBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        //Report tab DONE button click event
        private void button12_Click_1(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.DoneButtonClick(comboBox1, comboBox2, comboBox4, dateTimePicker1, dateTimePicker2, dataGridView3);
        }

        //Admin Form CLOSE event
        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message =
        "Are you sure that you would like to close the form?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ... 
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                e.Cancel = true;
            }
            else
            {
                log.Show();
                log.ActiveControl = log.UserName;
                log.UserName.Text = "UserName";
                log.maskedTextBox1.PasswordChar = '\0';
                log.maskedTextBox1.Text = "Password";
                log.UserName.ForeColor = Color.Gray;
                log.maskedTextBox1.ForeColor = Color.Gray;
            }
          
        }

        private void Supplier_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox13.Text == "") || (textBox16.Text == "") || (textBox15.Text == "") || (textBox19.Text == "") || (textBox17.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textBox122 = int.Parse(textBox12.Text);
                string textBox133 = textBox13.Text;
                string textBox166 = textBox16.Text;
                int textBox155 = int.Parse(textBox15.Text);
                string textBox199 = textBox19.Text;
                string textBox177 = textBox17.Text;

                SupplierDBConnection suppDb = new SupplierDBConnection();


                suppDb.Insert(textBox122, textBox133, textBox166, textBox155, textBox199, textBox177);
                clearItem();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox13.Text == "") || (textBox16.Text == "") || (textBox15.Text == "") || (textBox19.Text == "") || (textBox17.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textBox122 = int.Parse(textBox12.Text);
                string textBox133 = textBox13.Text;
                string textBox166 = textBox16.Text;
                int textBox155 = int.Parse(textBox15.Text);
                string textBox199 = textBox19.Text;
                string textBox177 = textBox17.Text;

                SupplierDBConnection suppDb = new SupplierDBConnection();


                suppDb.Update(textBox122, textBox133, textBox166, textBox155, textBox199, textBox177);
                clearItem();

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox13.Text == "") || (textBox16.Text == "") || (textBox15.Text == "") || (textBox19.Text == "") || (textBox17.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int textBox122 = int.Parse(textBox12.Text);

                SupplierDBConnection suppDb = new SupplierDBConnection();

                suppDb.Delete(textBox122);
                clearItem();

            }

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e) //keypress supplier search
        {
            
            SupplierDBConnection supp = new SupplierDBConnection();
            supp.keyPress_SupplierSearch(textBox18, dataGridView4);

        }

        private void button8_Click(object sender, EventArgs e) // search supplier
        {
            SupplierDBConnection supp = new SupplierDBConnection();
            supp.search(dataGridView4);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];

                textBox12.Text = row.Cells["Supplier_ID"].Value.ToString();
                textBox13.Text = row.Cells["Supplier_Name"].Value.ToString();
                textBox16.Text = row.Cells["Company_Name"].Value.ToString();
                textBox15.Text = row.Cells["Supplier_Tp"].Value.ToString();
                textBox19.Text = row.Cells["Email"].Value.ToString();
                textBox17.Text = row.Cells["Supplier_Address"].Value.ToString();

            }
        }


        private void Qty_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Reorder_Click(object sender, EventArgs e)
        {
            Form5 reorder = new Form5();
            reorder.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if ((textBox20.Text == "") || (textBox21.Text == "") || (textBox23.Text == "") || (textBox22.Text == ""))
            {
                MessageBox.Show("All the fields must be Filled");
            }
            else
            {
                int Code = int.Parse(textBox20.Text);
                int Qty = int.Parse(textBox23.Text);
                UpdateQty upQty = new UpdateQty();
                upQty.UserCatagory(Code, Qty);
            }
        }


        //-------------------Ravisha Weerasekara------------------------------2/24/2014----------------------------
        public void textBox24_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                string keyVal;
                string keyCd;
                string searchKey;



                keyVal = e.KeyValue.ToString(); //keycode value
                keyCd = e.KeyCode.ToString().ToLower(); //character


                KeyPressEvent kpe = new KeyPressEvent();

                searchKey = kpe.manualSearchkey(keyVal, keyCd, "admin", "search", this);



                if (searchKey == "exit")
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error Occured, Please Try Again, " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        //---------------------------------------------------------------------------





    }
}

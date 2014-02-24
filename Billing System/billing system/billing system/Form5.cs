using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using billing_system.Classes;

namespace billing_system
{
    // Aruna Udayanga--2/5/2014

    /// <summary>
    /// class for Reorder Level
    /// </summary>


    public partial class Form5 : Form
    {
        public string code;
        public string alert_id;
        public Form5()
        {
            InitializeComponent();
        }

     

        public void Form5_Load(object sender, EventArgs e)
        {
            ReorderForm re= new ReorderForm();
            re.search(this,dataGridView1);


        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             code = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
             alert_id = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

            ReorderForm rdform = new ReorderForm();
            rdform.clicButton(this, code);
           

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox13.Text == "") || (richTextBox1.Text == "") || (textBox16.Text == "") || (textBox19.Text == "") || (textBox15.Text == ""))
            {
                richTextBox1.Text = "";
                MessageBox.Show("All the fields must be Filled");
                
            }
            else
            {

                //int Alert_ID = int.Parse(code);
                int alert = int.Parse(alert_id);
                int sid = int.Parse(textBox12.Text);
                string name = textBox13.Text;
                string company_name = textBox16.Text;

                string sms = richTextBox1.Text;

                ReorderForm rdform = new ReorderForm();
                rdform.sendSupplier(alert, sid, name, company_name, sms, this);

                Form5 reload = new Form5();
                reload.Show();
                this.Close();
 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        //validation textbox
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidationText tx = new ValidationText();
            tx.textBoxValidation_KeyPress(sender, e);
        }
       

    }
}

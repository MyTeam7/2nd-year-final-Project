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
    public partial class Form6 : Form
    {
       
        public object frm;


        public Form6(object obj )
        {
            InitializeComponent();
            frm = obj;
            Billingform bf = (Billingform)frm;
        }

       


        


        private void Form6_Load(object sender, EventArgs e)
        {

            Billingform bf = (Billingform)frm;

            txtBoxCode.Text = bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();             //load code to form6 from dgv

            txtBoxDescription.Text = bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();      //description

            textBox10.Text = bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();              //quantity

            textBox8.Text = bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();                 //rate


        }



        private void button5_Click(object sender, EventArgs e)                             
        {

            
           

            decimal total;

        
            decimal quantity;

            Decimal.TryParse(textBox10.Text, out quantity);
            



            Billingform bf = (Billingform)frm;


            try
            {


                if (txtBoxDiscount.Text != "")
                {




                    decimal discount_Price;

                    Decimal.TryParse(txtBoxDiscount.Text + ".00", out discount_Price);
                    




                    total = (quantity * discount_Price);                  //calculate total when discount price is entered





                    bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[6].Value = total; //total





                    //...........................update total,qty & discount

                    decimal sum = 0;

                    int qty = 0;

                    decimal discount = 0;




                    for (int i = 0; i < bf.dataGridView1.Rows.Count; i++)
                    {

                        sum += Convert.ToDecimal(bf.dataGridView1.Rows[i].Cells[6].Value);

                        qty += Convert.ToInt32(bf.dataGridView1.Rows[i].Cells[3].Value);

                        discount += Convert.ToDecimal(bf.dataGridView1.Rows[i].Cells[4].Value);



                    }

                    bf.label7.Text = sum.ToString();

                    bf.label2.Text = qty.ToString();

                    bf.label4.Text = discount.ToString();




                    this.Close();

                    


                }



                else if (textBox1.Text != " ")
                {



                    decimal presentage;

                    Decimal.TryParse(textBox1.Text, out presentage);
                    




                    if ((presentage > 0 && presentage <= 100))
                    {

                        decimal price;

                        Decimal.TryParse(textBox8.Text, out price);


                        decimal discount;


                        discount = (price * (presentage /100));                  //calculate discount when presentage is entered


                        total = (quantity * (price - discount));                             //calculate total








                        bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[4].Value = discount;          //discount


                        bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[6].Value = total;               //total



                        // ..............................................................update labels



                        decimal sum = 0;

                        int qty = 0;

                        decimal discount1 = 0;


                        for (int i = 0; i < bf.dataGridView1.Rows.Count; i++)
                        {

                            sum += Convert.ToDecimal(bf.dataGridView1.Rows[i].Cells[6].Value);

                            qty += Convert.ToInt32(bf.dataGridView1.Rows[i].Cells[3].Value);

                            discount1 += Convert.ToDecimal(bf.dataGridView1.Rows[i].Cells[4].Value);



                        }

                        bf.label7.Text = sum.ToString();

                        bf.label2.Text = qty.ToString();

                        bf.label4.Text = discount1.ToString();





                        this.Close();




                    }


                    else
                    {
                        MessageBox.Show("Precentage is out of Range");
                    }


                }







                else if (textBox1.Text != " " && txtBoxDiscount.Text != "")
                {
                    MessageBox.Show("Both Discount Presentage and Discount Price can't be filled");

                }




                else
                {
                    MessageBox.Show("Discount Presentage or Discount Price Must be Enter");

                }




                


            }

            catch (Exception ex)
            {

                MessageBox.Show("Please Try Again" +ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

            finally
            {
                BillGeneration bill = new BillGeneration();
                bill.total(frm);
            }



        }



       
    


        private void button6_Click(object sender, EventArgs e)
        {

            this.Close();

        }



    }
}
      

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
           

            double total;

            double price;

            price = double.Parse(textBox8.Text);


            int quantity;

            quantity = int.Parse(textBox10.Text);



         





            try
            {


                if (txtBoxDiscount.Text != "")
                {


                   

                    Billingform bf = (Billingform)frm;


                    double discount_Price;

                    double Tot_Discount_price;
                   


                    discount_Price = double.Parse(txtBoxDiscount.Text);

                    price = double.Parse(textBox8.Text);


                    Tot_Discount_price = (quantity * discount_Price);                  //total discount price

                    total = ( (quantity * price) - Tot_Discount_price);                  //calculate total when discount price is entered





                    bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[5].Value = textBox8.Text;     //update rate in dgv


                    bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[4].Value = Tot_Discount_price;    //discount


                    bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[6].Value = total; //total



                    //...........................update total,qty & discount

                    double sum = 0;

                    int qty = 0;

                    double discount = 0;

                   // discount = (quantity * discount_Price);


                    for (int i = 0; i < bf.dataGridView1.Rows.Count ; i++)
                    {

                        sum += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[6].Value);

                        qty += Convert.ToInt32(bf.dataGridView1.Rows[i].Cells[3].Value);

                        discount += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[4].Value);



                    }

                    bf.label7.Text = sum.ToString();

                   bf.label2.Text = qty.ToString();

                    bf.label4.Text = discount.ToString();   
         



                    this.Close();

                }



                else if (textBox1.Text != " ")
                {



                    int presentage;

                    presentage = int.Parse(textBox1.Text);




                    if ((presentage > 0 && presentage <= 100))
                    {


                        Billingform bf = (Billingform)frm;

                        double discount;


                        discount = (price - (price * (presentage * 0.01)));                  //calculate discount when presentage is entered


                        total = (quantity * (price - discount));                             //calculate total








                        bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[5].Value = textBox8.Text;    //update rate


                        bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[4].Value = discount;          //discount


                        bf.dataGridView1.Rows[bf.dataGridView1.CurrentCell.RowIndex].Cells[6].Value = total;               //total



   // ..............................................................update labels
                        double sum = 0;

                        int qty = 0;

                        double discount1 = 0;


                        for (int i = 0; i < bf.dataGridView1.Rows.Count; i++)
                        {

                            sum += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[6].Value);

                            qty += Convert.ToInt32(bf.dataGridView1.Rows[i].Cells[3].Value);

                            discount1 += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[4].Value);



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

            catch (Exception)
            {

                MessageBox.Show("Unexpected Error Occured");

            }



        }



        
             
       

    


        private void button6_Click(object sender, EventArgs e)
        {

            this.Close();

        }



    }
}
      

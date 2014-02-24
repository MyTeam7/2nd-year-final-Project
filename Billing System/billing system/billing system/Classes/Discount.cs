using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace billing_system.Classes
{
    class Discount
    {
        public object frm;
        public void Abc(object obj)
        {
            frm = obj;
            Billingform bf = (Billingform)frm;
            double sum = 0;

            int qty = 0;

            double discount = 0;


            for (int i = 0; i < bf.dataGridView1.Rows.Count; i++)
            {

                sum += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[6].Value);

                qty += Convert.ToInt32(bf.dataGridView1.Rows[i].Cells[3].Value);

                discount += Convert.ToDouble(bf.dataGridView1.Rows[i].Cells[4].Value);



            }

            bf.label7.Text = sum.ToString();

            bf.label2.Text = qty.ToString();

            bf.label4.Text = discount.ToString();
        }
    }
}

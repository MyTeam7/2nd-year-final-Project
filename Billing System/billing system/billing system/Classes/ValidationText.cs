using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace billing_system.Classes
{
    //---------------2/9/2014....KasunEW----------------


    class ValidationText
    {

        public void textBoxValidation_KeyPress(object sender, KeyPressEventArgs e) 
        {


            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                SystemSounds.Hand.Play();

            }


        }


        public void UserName_KeyPress(object sender, KeyPressEventArgs e) 
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsNumber(e.KeyChar) ? false : true;
        }


        
    }
}

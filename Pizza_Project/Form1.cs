using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1: Form
    {
        private void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked == true)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rbMedium.Checked == true)
            {
                lblSize.Text = "Medium";
                return;
            }
            if (rbLarge.Checked == true)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        private void UpdateCrustType()
        {
            UpdateTotalPrice();

            if (rbThinCrust.Checked)
            {
                lbCrustType.Text = "Thin"; return;
            }
            else if (rbThickCrust.Checked)
            {
                lbCrustType.Text = "Thick"; return;
            }
        }

        private void UpdateSelectedToppings()
        {
            UpdateTotalPrice();
            string st = "";

            if (cbOnion.Checked) st += ", Onion";
            if (cbTomatoes.Checked) st += ", Tomatoes";
            if (cbExtraCheese.Checked) st += ", Extra Cheese";
            if (cbGreenPeppers.Checked) st += ", Green Peppers";
            if (cbMushrooms.Checked) st += ", Mushrooms";
            if (cbOlives.Checked) st += ", Olives";

            if (st.StartsWith(","))
                st = st.Substring(1, st.Length - 1).Trim();

            if (st == "") st = "No Toppings";

            lbToppings.Text = st;

        }
        

        

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        double GetSelectedSizePrice()
        {
            if (rbSmall.Checked) 
                return Convert.ToDouble(rbSmall.Tag);
            if (rbMedium.Checked) 
                return Convert.ToDouble(rbMedium.Tag);
            if (rbLarge.Checked) 
                return Convert.ToDouble(rbLarge.Tag);
            return 0;
               
        }
        private double GetSelectedCrutPrice()
        {
            if (rbThinCrust.Checked) 
                return Convert.ToDouble(rbThinCrust.Tag);
            if (rbThickCrust.Checked) 
                return Convert.ToDouble(rbThickCrust.Tag);
            return 0;
        }
        private double CalculateToppingsPrice()
        {
            double total = 0;
            if (cbExtraCheese.Checked)
                total += Convert.ToDouble(cbExtraCheese.Tag);
            if (cbMushrooms.Checked)
                total += Convert.ToDouble(cbMushrooms.Tag);
            if (cbOlives.Checked)
                total += Convert.ToDouble(cbOlives.Tag);
            if (cbOnion.Checked)
                total += Convert.ToDouble(cbOnion.Tag);
            if (cbTomatoes.Checked)
                total += Convert.ToDouble(cbTomatoes.Tag);
            if (cbGreenPeppers.Checked)
                total += Convert.ToDouble(cbGreenPeppers.Tag);
            return total;
        }
        private double CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrutPrice() + CalculateToppingsPrice();
        }

        private void UpdateOrderSummary()
        {
            UpdateCrustType(); UpdateSize();UpdateSelectedToppings(); UpdateTotalPrice();

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }


        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnOrder.Enabled = false;
            gbSize.Enabled = false;
            gbCrustType.Enabled = false;
            gbToppings.Enabled = false;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void cbExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void cbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void cbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSelectedToppings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gbToppings.Enabled = true;
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            btnOrder.Enabled = true;
        }
    }
}

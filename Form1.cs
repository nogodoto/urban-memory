using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSUOFinalLAB_LAROSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Person
        {
            public Person(string name, string address, string phone)
            {
                CustomerName = name;
                Address = address;
                Phone = phone;

            }
            public String CustomerName { get; set; }
            public String Address { get; set; }
            public String Phone { get; set; }

        }
        class Customer : Person

        {
            public Customer(string name, string address, string phone, string ID, double purchaseamount, bool onMailer)
                : base(name, address, phone)
            {
                CustomerID = ID;

                PurchaseAmount = purchaseamount;
                OnMailer = onMailer;

            }
            public string CustomerID { get; set; }

            public double PurchaseAmount { get; set; }
            public bool OnMailer { get; set; }


            public virtual double CalcAmount()
            {
                return PurchaseAmount;

            }

        }
        class PreferredCustomer : Customer
        {
            public PreferredCustomer(string name, string address, string phone, string ID, double purchaseamount, bool onMailer)
                : base(name, address, phone, ID, purchaseamount, onMailer)
            {
                DiscountAmt = SetDiscountAmt();
                //GetDiscount();


            }
            public readonly double DiscountAmt;

            public double SetDiscountAmt()  //calculates discount %
            {
                double discount = 0;
                if (PurchaseAmount >= 499)
                { discount = 0; }
                else if (PurchaseAmount >= 500 && PurchaseAmount <= 999)
                { discount = 0.05; }
                else if (PurchaseAmount >= 1000 && PurchaseAmount <= 1499)
                { discount = 0.06; }
                else if (PurchaseAmount >= 1500 && PurchaseAmount <= 1999)
                { discount = 0.07; }
                else if (PurchaseAmount >= 2000)
                { discount = 0.10; }
                return discount;


            }
            public double GetDiscount()
            {
                return PurchaseAmount * DiscountAmt;
            }
            public override double CalcAmount()
            {
                return base.CalcAmount() - GetDiscount();
            }


        }

        
        PreferredCustomer preferredCustomer = new PreferredCustomer();
        Person person = new Person();
        Customer customer = new Customer();

 

    private void btnDisplay_Click(object sender, EventArgs e)
        {
        preferredCustomer.CustomerName = txtName.Text;
        preferredCustomer.Address = txtAddress.Text;
        preferredCustomer.Phone = txtPhone.Text;
        preferredCustomer.PurchaseAmount = Convert.ToDouble(txtPurchaseAmt.Text);

        if (radMailing.Checked)
        {
            preferredCustomer.OnMailer = false;

        }
        else { preferredCustomer.OnMailer = true; }
        MessageBox.Show("Name: " + preferredCustomer.CustomerName + Environment.NewLine + "Address :" + preferredCustomer.Address + Environment.NewLine +
            "Phone Number:" + preferredCustomer.Phone + Environment.NewLine + "Purchase Amount:" + preferredCustomer.PurchaseAmount + Environment.NewLine + "Discount Amount:" + preferredCustomer.DiscountAmt);
    }
    }
}

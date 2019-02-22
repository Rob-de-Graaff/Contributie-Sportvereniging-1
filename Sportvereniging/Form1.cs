using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sportvereniging
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Member> members;
        private int ageLimit;
        private double _priceTotal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ageLimit = 18;
            members = new Dictionary<int, Member>();
           
            members.Add(1, new Member("John Deer", Convert.ToDateTime("10/2/1990"), Convert.ToDateTime("15/8/2000"), "", false, 0, 0, 1));
            members.Add(2, new Member("John Dough", Convert.ToDateTime("18/2/2005"), Convert.ToDateTime("1/8/2015"), "", true, 0, 0, 1));

            // Sets properties per member
            foreach (KeyValuePair<int, Member> entry in members)
            {
                int age = CalculateYears(entry.Value.DateOfBirth);
                int membership = CalculateYears(entry.Value.StartDate);

                // Sets status + contribution property
                if (age>=18)
                {
                    entry.Value.Status = "senior";
                    entry.Value.Contribution = 75;
                    
                }
                else
                {
                    entry.Value.Status = "junior";
                    entry.Value.Contribution = 40;
                }

                // Checks if member is playing, sets FederationFee property
                if (entry.Value.Playing)
                {
                    entry.Value.FederationFee = 45;
                }

                // Sets Discount property
                switch (membership)
                {
                    case int y when (y >= 7):
                        entry.Value.Discount = 0.965;
                        break;
                    case int y when (y < 7 && y >= 4):
                        entry.Value.Discount = 0.965;
                        break;
                }
            }

            // Displays title property
            listBoxMembers.DataSource = members.Values.ToList();
            listBoxMembers.DisplayMember = "name";

            // Displays calculation, total
            labelTicketsTotal.Text = $@"Contribution Total = contribution * discount + federation Fee";
            labelPriceTotal.Text = $@"Total: € {Math.Round(_priceTotal, 2):0.00},-";
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            Member tempMember = (Member)listBoxMembers.SelectedItem;

            _priceTotal = tempMember.Contribution * tempMember.Discount + tempMember.FederationFee;

            // Displays calculation, total
            labelTicketsTotal.Text = $@"Contribution Total = contribution € {tempMember.Contribution} * discount {(1 - tempMember.Discount)*100}% + federation Fee € {tempMember.FederationFee}";
            labelPriceTotal.Text = $@"Total: € {Math.Round(_priceTotal, 2):0.00},-";
        }

        private static int CalculateYears(DateTime date)
        {
            int years = DateTime.Now.Year - date.Year;  
            if (DateTime.Now.DayOfYear < date.DayOfYear)  
                years = years - 1;  
  
            return years; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportvereniging
{
    class Member
    {
        private string name;
        private DateTime dateOfBirth;
        private DateTime startdate;
        private string status;//
        private bool playing;
        private double contribution;//
        private double federationFee;//
        private double discount;//

        public Member(string name, DateTime dateOfBirth, DateTime startdate, string status, bool playing, double contribution, double federationFee, double discount)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.startdate = startdate;
            this.status = status;
            this.playing = playing;
            this.contribution = contribution;
            this.federationFee = federationFee;
            this.discount = discount;
        }

        public override string ToString()
        {
            return $"Name:{name}, Date of birth:{dateOfBirth}, Started:{startdate}, Status:{status}, Contribution:{contribution}";
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
        }

        public DateTime StartDate
        {
            get { return startdate; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public bool Playing
        {
            get { return playing; }
        }

        public double Contribution
        {
            get { return contribution; }
            set { contribution = value; }
        }

        public double FederationFee
        {
            get { return federationFee; }
            set { federationFee = value; }
        }

        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}

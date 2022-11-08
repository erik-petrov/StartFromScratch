using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace StartFromScratch.Models
{
    public enum PaymentType
    {
        [Display(Name = "Daily")]
        Daily,
        [Display(Name = "Montly")]
        Montly,
        [Display(Name = "Yearly")]
        Yearly
    }
    public class RealEstate
    {
        protected RealEstate(int id, string address, float area, float cost, string link)
        {
            Id = id;
            Address = address;
            Area = area;
            Cost = cost;
            ImageLink = link;
        }
        public RealEstate()
        {
            
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public float Area { get; set; }
        public float Cost { get; set; }
        public string ImageLink { get; set; }
    }
    public class Rent : RealEstate
    {
        public Rent(int id, string address, float area, float cost, PaymentType paymentType, string link) : base(id, address, area, cost, link)
        {
            PaymentType = paymentType;
        }
        public Rent(RealEstate house, PaymentType payment, DateTime from, DateTime until)
        {
            Address = house.Address;
            Area = house.Area;
            Cost = house.Cost;
            ImageLink = house.ImageLink;
            PaymentType = payment;
            From = from;
            Until = until;
        }

        public Rent() { }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public PaymentType PaymentType { get; set; }
    }
    public class Buy : RealEstate
    {
        public int ChildrenAmount { get; set; }
        public string Details { get; set; }
        public Buy(int id, string address, float area, float cost, int children, string details, string link) : base(id, address, area, cost, link)
        {
            Details = details;
            ChildrenAmount = children;
        }
        public Buy(RealEstate house, int children, string details)
        {
            Address = house.Address;
            Area = house.Area;
            Cost = house.Cost;
            Details = details;
            ChildrenAmount = children;
            ImageLink = house.ImageLink;
        }
        public Buy() { }
    }
}

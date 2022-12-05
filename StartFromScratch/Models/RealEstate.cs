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
        [Display(Name = "Aadress")]
        public string Address { get; set; }
        [Display(Name = "Pindala")]
        public float Area { get; set; }
        [Display(Name = "Kulu")]
        public float Cost { get; set; }
        [Display(Name = "Pilt")]
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
        [Display(Name = "Alates")]
        public DateTime From { get; set; }
        [Display(Name = "Kuni")]
        public DateTime Until { get; set; }
        [Display(Name = "Makse tüüp")]
        public PaymentType PaymentType { get; set; }
    }
    public class Buy : RealEstate
    {
        [Display(Name = "Kohtumis aeg")]
        public DateTime Meetup { get; set; }
        public Buy(int id, string address, float area, float cost, string link, DateTime meetup) : base(id, address, area, cost, link)
        {
            Meetup = meetup;
        }
        public Buy(RealEstate house, DateTime meetup)
        {
            Address = house.Address;
            Area = house.Area;
            Cost = house.Cost;
            Meetup = meetup;
            ImageLink = house.ImageLink;
        }
        public Buy() { }
    }
}

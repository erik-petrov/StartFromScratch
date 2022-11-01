using Microsoft.VisualBasic;
using System.Net;

namespace StartFromScratch.Models
{
    public enum PaymentType
    {
        Daily,
        Montly,
        Yearly
    }
    public class RealEstate
    {
        protected RealEstate(int id, string address, float area, float cost)
        {
            Id = id;
            Address = address;
            Area = area;
            Cost = cost;
        }
        public RealEstate()
        {
            
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public float Area { get; set; }
        public float Cost { get; set; }
    }
    public class Rent : RealEstate
    {
        public Rent(int id, string address, float area, float cost, PaymentType paymentType) : base(id, address, area, cost)
        {
            PaymentType = paymentType;
        }
        public Rent() { }
        public DateInterval Length { get; set; }

        public PaymentType PaymentType { get; set; }
    }
    public class Buy : RealEstate
    {
        public DateOnly LastRestoration { get; set; }
        public Buy(int id, string address, float area, float cost, DateOnly lastRestoration) : base(id, address, area, cost)
        {
            LastRestoration = lastRestoration;
        }
        public Buy() { }
    }
}

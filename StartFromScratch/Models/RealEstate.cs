using Microsoft.VisualBasic;
using System.Net;
using System.Security.Policy;

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
        public Rent(RealEstate house, PaymentType payment, DateInterval length)
        {
            Address = house.Address;
            Area = house.Area;
            Cost = house.Cost;
            PaymentType = payment;
            Length = length;
        }
        public Rent() { }
        public DateInterval Length { get; set; }
        public PaymentType PaymentType { get; set; }
    }
    public class Buy : RealEstate
    {
        public int ChildrenAmount { get; set; }
        public string Details { get; set; }
        public Buy(int id, string address, float area, float cost, int children, string details) : base(id, address, area, cost)
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
        }
        public Buy() { }
    }
}

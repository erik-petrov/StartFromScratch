using bruh.Database;
using System.Xml.Linq;

namespace StartFromScratch.Models
{
    /*public abstract class Human
    {
        protected Human(int id, string fullName, string email, string phone, string password)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Password = password;
        }

        public int Id { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Password { get; }
    }
    public class User : Human
    {
        public DateTime RegisterDate { get; set; }
        public Rent[] GetRentedPlaces() => throw new NotImplementedException();

        public User(int id, string name, string email, string phone, string password, DateTime regDate): base(id, name, email, phone, password)
        {
            RegisterDate = regDate;
        }

        public User(int id, string fullName, string email, string phone, string password) : base(id, fullName, email, phone, password)
        {
        }
    }
    public class Agent : Human
    {
        public int YearsInField { get; set; }
        public bool IsAvailable() => throw new NotImplementedException();
        public Agent(int id, string name, string email, string phone, string password, int years) : base(id, name, email, phone, password)
        {
            YearsInField = years;
        }

        public Agent(int id, string fullName, string email, string phone, string password) : base(id, fullName, email, phone, password)
        {
        }
    }*/
    public class User
    {
        public User(int id, string fullName, string email, string phone, string password, DateTime registerDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Password = password;
            RegisterDate = registerDate;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public Rent[] GetRentedPlaces() => throw new NotImplementedException();
    }
    public class Agent
    {
        public Agent(int id, string fullName, string email, string phone, string password, int yearsInField)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Password = password;
            YearsInField = yearsInField;
        }

        public Agent() { }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int YearsInField { get; set; }
        public bool IsAvailable() => throw new NotImplementedException();
    }
    public class Consultation
    {
        public Consultation(DateTime startTime, DateTime endTime, User user, string description)
        {
            StartTime = startTime;
            EndTime = endTime;
            User = user;
            Description = description;
        }
        public Consultation() {}

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public User? User { get; set; }
        public string Description { get; set; }
    }
}
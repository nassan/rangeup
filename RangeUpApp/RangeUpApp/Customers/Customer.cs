using System;
using System.Collections.Generic;
using System.Text;

namespace RangeUpApp
{
    public class Customer 
    {
        public static int count = 0;

        public Customer(string Name, string GunType, string Time)
        {
            this.Name = Name;
            this.GunType = GunType;
            this.Time = Time;
            this.number = count++;
            this.StartTime = DateTime.Now;
        }

        public Customer()
        {
        }

        public Customer(int number)
        {
            this.number = number;
        }

        public int number { get; set; }

        // Name and surname
        public string Name { get; set; }

        // Type of gun
        public string GunType { get; set; }

        // Time
        public string Time { get; set; }

        // CurrentTime
        public DateTime StartTime { get; set; }

        // For Analytics
        public string Visits { get; set; }
        public string TotalTime { get; set; }
        public string favoriteGun { get; set; }


       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RangeUpApp
{
    public class Customer 
    {
        public static int count = 0;

        public Customer(string Name, string GunType, string Countdown)
        {
            this.Name = Name;
            this.GunType = GunType;
            this.Countdown = Countdown;
            this.number = count++;
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
        public string Countdown { get; set; }

        // For Analytics
        public string Visits { get; set; }
        public string TotalTime { get; set; }
        public string favoriteGun { get; set; }


       
    }
}

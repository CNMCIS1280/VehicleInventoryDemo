using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleInventory
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public double Mileage { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public string Remarks { get; set; }
        public double LastOilChange { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"{VIN} {Make} {Model} {Year} {Color}";
        }
    }
}

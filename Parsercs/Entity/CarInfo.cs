using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsercs
{
    public class CarInfo
    {
        public int CarId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string YearOfIssue { get; set; }
        public string Mileage { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public string City { get; set; }
        public string ImagePath { get; set; } // Путь к изображению
    }
}

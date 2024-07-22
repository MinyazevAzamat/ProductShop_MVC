 using System;
namespace WebApplication3.Models
{
    public class Tovar
    {
        public int? ID_tovara { get; set; }
        public string? Nazvanie { get; set; }
        public int? Price { get; set; }
        public string? Oblast { get; set; }
    
        public Tovar (int? id_t, string? name, int? price, string? oblast)
        {
            ID_tovara = id_t;
            Nazvanie = name;
            Price = price;
            Oblast = oblast;
        }
    }
}
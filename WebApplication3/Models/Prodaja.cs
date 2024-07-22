using System;
namespace WebApplication3.Models
{
    public class Prodaja
    {
        public int? ID_prodaj { get; set; }
        public int? ID_prodav { get; set; }
        public int? ID_pokup { get; set; }
        public Prodaja (int? j, int? c, int? p)
        {
            ID_prodaj = j;
            ID_prodav = c;
            ID_pokup = p;
        }
    }
}
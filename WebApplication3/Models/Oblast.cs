using System;
namespace WebApplication3.Models
{
    public class Oblast
    {
        public int? ID_Obl { get; set; }
        public int? ID_Sotr { get; set; }
        public string? Name { get; set; }
        public Oblast(int? id_obl, int? id_sotr, string? name)
        {
            ID_Obl = id_obl;
            ID_Sotr = id_sotr;
            Name = name;
        }
    }
}
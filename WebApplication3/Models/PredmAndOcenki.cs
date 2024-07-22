using System;
namespace WebApplication3.Models
{
    public class PredmAndOcenki
    {
        public string? Name1 { get; set; }
        public int? Val1 { get; set; }
        public string? Name2 { get; set; }
        public int? Val2 { get; set; }
        public string? Sb { get; set; }
        public PredmAndOcenki(string? kp1, int? o1, string? kp2, int? o2, string? sb)
        {
            Name1 = kp1;
            Val1 = o1;
            Name2 = kp2;
            Val2 = o2;
            Sb = sb;
        }
    }
}
using System;
namespace WebApplication3.Models
{
    public class Pokupatel
    {
        public int? id { get; set; }
        public string? f_p { get; set; }
        public string? i_p { get; set; }
        public string? o_p { get; set; }
        public string? FIO { get; set; }
        public Pokupatel(int? id_r, string? f, string? i, string? o)
        {
            id = id_r;
            f_p = f;
            i_p = i;
            o_p = o;
            this.FIO = f + " " + i + " " + o; 
        }
    }
}
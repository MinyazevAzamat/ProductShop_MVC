using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using System.Data;
using System.Data.OleDb;
using System.Runtime.Intrinsics.Arm;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        string cnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\10\Desktop\Продуктовый.accdb;";
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\10\Desktop\DB_TP.accdb
        List<Oblast> oblast = new List<Oblast>();
        List<Tovar> tovar = new List<Tovar>();
        List<Prodaja> prodaja = new List<Prodaja>();
        List<Prodovec> prodavec = new List<Prodovec>();
        List<Pokupatel> pokupatel = new List<Pokupatel>();
        public ActionResult Index()
        {
            OleDbDataAdapter dAdaptOb = new OleDbDataAdapter($"SELECT * FROM Область_товаров", cnStr);
            DataTable dtOb = new DataTable();
            dAdaptOb.Fill(dtOb);
            foreach (var x in dtOb.AsEnumerable())
            {
                Oblast obl = new Oblast(
                    x.Field<int?>("Код"),
                    x.Field<int?>("ID_сотрудника"),
                    x.Field<string?>("Название_области")
                    );
                this.oblast.Add(obl);
            }
            ViewBag.Oblasti = oblast;
            return View();
        }
         
         public ActionResult Obl(int id)
         {
            OleDbDataAdapter dAdaptOb = new OleDbDataAdapter($"SELECT * FROM Область_товаров", cnStr);
            DataTable dtOb = new DataTable();
            dAdaptOb.Fill(dtOb);
            foreach (var x in dtOb.AsEnumerable())
            {
                Oblast obl = new Oblast(
                    x.Field<int?>("Код"),
                    x.Field<int?>("ID_сотрудника"),
                    x.Field<string?>("Название_области")
                    );
                this.oblast.Add(obl);
            }

            OleDbDataAdapter dAdaptProd = new OleDbDataAdapter($"SELECT * FROM Товары", cnStr);
            DataTable dtProd = new DataTable();
            dAdaptProd.Fill(dtProd);
            foreach (var x in dtProd.AsEnumerable())
            {
                Tovar student = new Tovar(
                    x.Field<int?>("ID_Продукта"),
                    x.Field<string?>("Название"),
                    x.Field<int?>("Цена"),
                    x.Field<string?>("Область_товаров")
                    );
                tovar.Add(student);
            }

            var nasha_obl = from s in oblast
                where s.ID_Obl == id
                select s;
            var tovari = from x in tovar
                where x.Oblast == nasha_obl.First().Name
                select x;
             ViewBag.Tovari = tovari;
             return View();
         }
        public ActionResult Prod(int id)
        {
            OleDbDataAdapter dAdaptS = new OleDbDataAdapter($"SELECT * FROM Продажи", cnStr);
            DataTable dtSt = new DataTable();
            dAdaptS.Fill(dtSt);
            foreach (var x in dtSt.AsEnumerable())
            {
                Prodaja prods = new Prodaja(
                    x.Field<int?>("ID_Продукта"),
                    x.Field<int?>("ID_Сотрудника"),
                    x.Field<int?>("ID_Покупателя")
                    );
                if (id == x.Field<int?>("ID_Продукта"))
                    prodaja.Add(prods);
            }
            OleDbDataAdapter dAdaptPr = new OleDbDataAdapter($"SELECT * FROM Сотрудники", cnStr);
            DataTable dtPr = new DataTable();
            dAdaptPr.Fill(dtPr);
            foreach (var x in dtPr.AsEnumerable())
            {
                Prodovec prod = new Prodovec(
                    x.Field<int?>("ID_Сотрудника"),
                    x.Field<string?>("Фамилия"),
                    x.Field<string?>("Имя"),
                    x.Field<string?>("Отчество")
                    );
              //  if (prodaja.First().ID_prodav == x.Field<int?>("ID_Сотрудника"))
                    prodavec.Add(prod);
            }
            var prodi = from pr in prodavec.AsEnumerable()
                        from x in prodaja.AsEnumerable()
                        where x.ID_prodav == pr.id
                        select pr.FIO;

            OleDbDataAdapter dAdaptPok = new OleDbDataAdapter($"SELECT * FROM Покупатели", cnStr);
            DataTable dtPok = new DataTable();
            dAdaptPok.Fill(dtPok);
            foreach (var x in dtPok.AsEnumerable())
            {
                Pokupatel prod = new Pokupatel(
                    x.Field<int?>("ID_Покупателя"),
                    x.Field<string?>("Фамилия"),
                    x.Field<string?>("Имя"),
                    x.Field<string?>("Отчество")
                    );
               // if (prodaja.First().ID_pokup == x.Field<int?>("ID_Покупателя"))
                    pokupatel.Add(prod);
            }
            var pokupi = from pr in pokupatel.AsEnumerable()
                        from x in prodaja.AsEnumerable()
                        where x.ID_pokup == pr.id
                        select pr.FIO;
            List<string> PokAndProd = new List<string>();
            var pok = pokupi.ToList();
            var prod1 = prodi.ToList();
            for (int i = 0; i < pokupi.Count(); i++)
            {
                PokAndProd.Add(prod1[i] + "\t" + pok[i]);
            }
            ViewBag.PokupAndProd = PokAndProd;
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLBeneficiosWeb.Models;

namespace CLBeneficiosWeb.Areas.checkout.Controllers
{
    public class AssinarController : Controller
    {
        CLBeneficiosEntities db = new CLBeneficiosEntities();

        // GET: checkout/Assinar
        public ActionResult Index()
        {
            List<Beneficios_Convenios> Lista = db.Beneficios_Convenios.Where(o=>o.idConvênio == 1).ToList();
            ViewBag.Preco_Mensal = Lista.Where(s=>s.Obrigatorio).Sum(s => s.Preço_Mensal);
            ViewBag.Preco_Assinatura = Lista.Where(s => s.Obrigatorio && s.Preço_Assinatura > 0).Sum(s => s.Preço_Assinatura);
            return View(Lista);
        }
    }
}
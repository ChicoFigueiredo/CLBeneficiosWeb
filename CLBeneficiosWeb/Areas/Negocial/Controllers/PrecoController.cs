using CLBeneficiosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CLBeneficiosWeb.Areas.Negocial.Controllers
{
    public class PrecoController : Controller
    {
        dbCL_BeneficiosEntities db = new dbCL_BeneficiosEntities();

        // GET: Negocial/Preco
        public ActionResult Index()
        {
            return View();
        }

        // GET: Negocial/Preco/Calcular
        public ActionResult Calcular(int[] B)
        {
            List<Beneficios_Convenios> Lista = db.Beneficios_Convenios.Where(o => o.idConvênio == 1).ToList();
            ViewBag.Preco_Mensal = Lista.Where(s => s.Obrigatorio || B.Contains(s.idBeneficio)).Sum(s => s.Preço_Mensal);
            ViewBag.Preco_Assinatura = Lista.Where(s => (s.Obrigatorio || B.Contains(s.idBeneficio)) && s.Preço_Assinatura > 0).Sum(s => s.Preço_Assinatura);
            return View(Lista);
        }
    }
}
using System.Web.Mvc;
using CLBeneficiosWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace CLBeneficiosWeb.Controllers
{
    public class HomeController : ControllerMestre
    {
        public ActionResult Index()
        {
            ViewBag.Valor_Assinatura = ConvenioAtual.Beneficios_Convenios.Where(s => s.Obrigatorio).Sum(s => s.Preço_Mensal);
            return View(ConvenioAtual);
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }
    }
}

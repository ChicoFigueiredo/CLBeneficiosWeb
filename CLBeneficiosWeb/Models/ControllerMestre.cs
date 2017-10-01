using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLBeneficiosWeb.Models;

namespace System.Web.Mvc
{
    public class ControllerMestre : Controller
    {
        public CLBeneficiosEntities db = new CLBeneficiosEntities();
        private VariaveisSessao VS {
            get
            {
                return (VariaveisSessao)this.Session["settings"];
            }
        }

        public Convenio ConvenioAtual {
            get
            {
                return ((VariaveisSessao)this.Session["settings"]).Convenio_Selecionado;
            }
        }
        public ControllerMestre() : base()
        {
        }
        
        // GET: ControlerMestre
        public ActionResult Index2()
        {
            return View();
        }
    }
}
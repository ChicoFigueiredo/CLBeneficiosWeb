using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CLBeneficiosWeb.Models
{
    public class ClassesGlobais
    {
    }

    public class VariaveisSessao
    {
        CLBeneficiosEntities db = new CLBeneficiosEntities();

        public int codigoConveniado { get; set; }
        public string strCodigoConveniado { get { return this.codigoConveniado.ToString("0000000");} }
        public Convenio Convenio_Selecionado { get; set; }

        public VariaveisSessao(string url)
        {
            List<Convenio> Lista_Convenio = db.Convenios
                                                .AsNoTracking()
                                                .Include("Beneficios_Convenios")
                                                .Include("Grupo_Descontos")
                                                .ToList();
            Convenio_Selecionado = Lista_Convenio.Where(w => Regex.IsMatch(url, w.URL_Raiz)).First();
            if (Convenio_Selecionado != null)
            {
                codigoConveniado = Convenio_Selecionado.idConvênio;
            }
        }
    }
}
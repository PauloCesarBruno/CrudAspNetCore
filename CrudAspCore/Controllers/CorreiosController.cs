using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudAspCore.Models;
using System;
//==============================================================================================
// Link Uri: https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl
// Link GitHub: https://github.com/tborgesvieira/Web-Service-Client-Core
//==============================================================================================

namespace WebApplicationCep.Controllers
{
    public class CorreiosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CrudAspCore.Models.Cep cep)
        {
            if (!ModelState.IsValid)
            {
                return View(cep);
            }

            var correios = new Correios.AtendeClienteClient();

            try
            {
                var consulta = correios.consultaCEPAsync(cep.Codigo.Replace("-", "")).Result;

                if (consulta != null)
                {
                    ViewBag.Endereco = new CrudAspCore.Models.Endereco() // Retorno de ViewBag
                    {
                        Descricao = consulta.@return.end, // Retorno de ViewBag
                        Complemento = consulta.@return.complemento2, // Retorno de ViewBag
                        Bairro = consulta.@return.bairro,  // Retorno de ViewBag
                        Cidade = consulta.@return.cidade,  // Retorno de ViewBag
                        UF = consulta.@return.uf  // Retorno de ViewBag
                    };
                }
            }
            catch (Exception)
            {
                // Se o Cep Não Existir retorna essas ViewBag´s Criadas no Index.
                ViewBag.ERRO = "ATENÇÃO: Cep Inválido ou Inexistente!!!"; // ViewBag Criada no Index.
                ViewBag.ERRO2 = " ";
                ViewBag.ERRO3 = "Verifique e tente novamente.";
            }

            return View(cep);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new Correios.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento2.Data;
using Estacionamento2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ativos : ControllerBase
    {
        EstacionamentoContext Bd = new EstacionamentoContext();

        // Da entrada no carro
        [HttpGet]
        public ActionResult<dynamic> Get()
        {

            var query =
                (from t in Bd.TemposPermanencia
                 join c in Bd.Carros on t.CarroPlaca equals c.Placa
                 where t.Ativo == true
                 select new { c.Placa, c.Marca, c.Modelo, c.Cor, Entrada = t.DataInicio.ToString("HH:mm dd/MM/yyyy") }).ToList();


            return query;
        }
    }
}

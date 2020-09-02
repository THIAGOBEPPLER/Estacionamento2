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
    public class Entrada : ControllerBase
    {
        EstacionamentoContext Bd = new EstacionamentoContext();

        // Da entrada no carro
        [HttpPut("{Placa}")]
        public ActionResult<Carro> Put(string placa)
        {
            var carro = new Carro();
            var tempo = new TempoPermanencia();

            var VerificaAtivo =
                (from t in Bd.TemposPermanencia
                 where t.CarroPlaca == placa
                 select t.Ativo).LastOrDefault();

            if (VerificaAtivo)
                return Ok("Carro ja esta no patio!");

            var dataAtual = DateTime.Now;

            tempo.DataInicio = dataAtual;
            tempo.CarroPlaca = placa;
            tempo.Ativo = true;

            Bd.Add(tempo);
            Bd.SaveChanges();

            return Ok("Carro adicionado ao Patio!");
        }
    }
}

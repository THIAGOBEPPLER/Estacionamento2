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
    public class Baixa : ControllerBase
    {
        EstacionamentoContext Bd = new EstacionamentoContext();

        // Da baixa no carro
        [HttpPut("{Placa}")]
        public ActionResult<Carro> Put(string placa)
        {
            var carro = new Carro();
            var tempo = new TempoPermanencia();

            var VerificaAtivo =
                (from t in Bd.TemposPermanencia
                 where t.CarroPlaca == placa
                 select t.Ativo).LastOrDefault();

            //tempo = query;

            if (!VerificaAtivo)
                return Ok("Esse carro nao esta no patio!");


            var query =
                (from t in Bd.TemposPermanencia
                 where t.CarroPlaca == placa
                 select t).LastOrDefault();


            tempo = query;

            var dataAtual = DateTime.Now;
            double duracao;
            float valor;
            TimeSpan  aux;
            DateTime dataIni;

            dataIni = tempo.DataInicio;

            aux = dataAtual - dataIni;

            duracao = (int)aux.TotalMinutes;

            if (duracao <= 30)
                valor = 5;
            else
            {
                valor = (int)(duracao / 30) * 5;
            }

            tempo.Tempo = duracao;
            tempo.DataFim = dataAtual;
            tempo.Ativo = false;
            tempo.Valor = valor;

            Bd.Update(tempo);
            Bd.SaveChanges();

            //var lista = new List<dynamic>();
            //lista.Add(dataIni.ToString("HH:mm dd/MM/yyyy"));
            //lista.Add(dataAtual.ToString("HH:mm dd/MM/yyyy"));
            //lista.Add(duracao);
            //lista.Add(valor);

            var saida =
                (from t in Bd.TemposPermanencia
                 join c in Bd.Carros on t.CarroPlaca equals c.Placa
                 where c.Placa == placa
                 select new
                 {
                     c.Placa,
                     c.Marca,
                     c.Modelo,
                     c.Cor,
                     Entrada = t.DataInicio.ToString("HH:mm dd/MM/yyyy"),
                     Saida = t.DataFim.Value.ToString("HH:mm dd/MM/yyyy"),
                     t.Tempo,
                     t.Valor
                     }).LastOrDefault();



            return Ok(saida);
        }
    }
}

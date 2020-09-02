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

    
    public class AdicionaCarro : ControllerBase
    {
        EstacionamentoContext Bd = new EstacionamentoContext();

        // Adiciona novo carro
        [HttpPut("{Placa}/{Marca}/{Modelo}/{Cor}")]
        public ActionResult<Carro> Put(string placa, string marca, string modelo, string cor)
        {
            var carro = new Carro();


            var query =
                (from c in Bd.Carros
                 where (c.Placa == placa)
                 select c.Placa).Any();

            if (query == true)
            {
                return Ok("Carro ja existente!");
            }

            carro.Placa = placa;
            carro.Marca = marca;
            carro.Modelo = modelo;
            carro.Cor = cor;

            Bd.Carros.Add(carro);
            Bd.SaveChanges();

            return Ok("Carro Adicionado!");
        }

        // Verifica Placa existente e retorna os dados
        [HttpGet("{Placa}")]
        public ActionResult<Carro> Get(string placa)
        {
            var carro = new Carro();

            var query =
                (from c in Bd.Carros
                 where (c.Placa == placa)
                 select new { c.Placa, c.Marca, c.Modelo, c.Cor }).ToArray().SingleOrDefault();            

            //var verifica = query.Any();

            //if (verifica == true)
            //{
            //    return Ok(query);
            //}


            return Ok(query);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento2.Models
{
    public class Carro
    {
        [Key]
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public List<TempoPermanencia> TempoP { get; set; }

        // public List<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento2.Models
{
    public class TempoPermanencia
    {
        public int ID { get; set; }
        public DateTime DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public Nullable<double> Tempo { get; set; }
        public bool Ativo { get; set; }
        public Nullable<float> Valor { get; set; }

        public string CarroPlaca { get; set; }
        public Carro Carro { get; set; }

        //public int BlogId { get; set; }
        //public Blog Blog { get; set; }
    }
}

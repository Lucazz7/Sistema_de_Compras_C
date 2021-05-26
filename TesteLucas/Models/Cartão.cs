using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLucas.Models
{
    public class Cartão
    {
        public int Id { get; set; }

        public string N_Cartao { get; set;}

        public string Nome_Titular { get; set; }

        public String Cpf_Titular { get; set; }

        public int Cod_seguranca { get; set; }

        public string Validade_Cartao { get; set; }

        public int N_parcelas { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }




    }
}

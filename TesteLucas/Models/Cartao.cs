using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLucas.Models
{
    public class Cartao
    {
        public int Id { get; set; }

        [Display(Name = "Numero do Cartão*")]
        public string N_Cartao { get; set;}
        [Display(Name = "Nome do Titular do Cartão*")]
        public string Nome_Titular { get; set; }

        [Display(Name = "CPF do Titular do Cartão*")]
        public String Cpf_Titular { get; set; }

        [Display(Name = "Codigo de Segurança*")]
        public int Cod_seguranca { get; set; }
        [Display(Name = "Validade do Cartão*")]
        public string Validade_Cartao { get; set; }

        [Display(Name = "Numero de parcelas*")]
        public int N_parcelas { get; set; }
        [Display(Name = "Nome do Usuario*")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }




    }
}

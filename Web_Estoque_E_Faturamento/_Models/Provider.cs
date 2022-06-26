using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Web_Estoque_E_Faturamento._Models
{
    public class Provider
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public string Andress {get;set;}
        public string Cnpj {get;set;}
    }
}
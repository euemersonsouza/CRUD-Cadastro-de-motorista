using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Cadastro_de_motorista.Models
{
    public class Motorista
    {
        
        public int Motid { get; set; }
        public string Motome { get; set; }
        public string Motsobrenome { get; set; }
        public string Motcaminhao { get; set; }
        public string Motendereco { get; set; }
        public string Motmarca { get; set; }
        public string Motmodelo { get; set; }
        public string Motnumcaminhao { get; set; }
        public string Moteixos { get; set; }
    }
}
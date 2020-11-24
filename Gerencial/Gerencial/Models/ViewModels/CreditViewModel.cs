using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerencial.Models.ViewModels
{
    public class CreditViewModel
    {
        public DateTime DataPesquisa { get; set; }

        public bool bImprimir { get; set; }

        public List<Credit> Credit { get; set; }

        public List<Client> Client { get; set; }

        public float Total { get; set; }
    }
}
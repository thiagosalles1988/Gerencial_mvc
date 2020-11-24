using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerencial.Models.ViewModels
{
    public class CreditVM
    {
        public Credit Credit { get; set; }

        public IEnumerable<Client> Client { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gerencial.Models
{
    public class Credit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira a Descrição da Venda!")]
        [Display(Name = "Venda")]
        public string NameCredit { get; set; }

        [Display(Name = "Data de Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Insira a Data de Pagamento! Formato: DD/MM/AAAA")]
        public DateTime PaymentsDate { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public string PaymentForm { get; set; }

        [Required(ErrorMessage = "Insira o Valor")]
        [Display(Name = "Valor")]
        public float Value { get; set; }

        [Display(Name = "Observação")]
        public string Observation { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

    }
}
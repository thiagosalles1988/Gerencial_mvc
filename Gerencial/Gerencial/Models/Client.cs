using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gerencial.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o Nome Completo!")]        
        [Display(Name = "Nome")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "E-mail inválido")]        
        [Display(Name = "Email")]
        public string Mail { get; set; }
                
        //[Min18YearIfMember]
        [Display(Name = "Data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insira a Data de Nascimento!")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Bairro")]
        public string District { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        [Display(Name = "Profissão")]
        public string Profession { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        



    }
}
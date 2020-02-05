using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;

namespace ContractSystem.Domain.Model
{
    /// <summary>
    /// we have contractmodel for ui intraction and convert in to contract for databse intraction
    /// </summary>
  public  class ContractModel
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        
        [MaxLength(500)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string BrokerAgentName { get; set; }

        [Required]
        [MaxLength(50)]
        public string BrokerCompanyName { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

    }
   
}

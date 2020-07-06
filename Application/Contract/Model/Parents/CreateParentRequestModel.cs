using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Contract.Model.Parents
{
    public class CreateParentRequestModel
    {
        [Required]
        public string Name { get; set; }


    }
}

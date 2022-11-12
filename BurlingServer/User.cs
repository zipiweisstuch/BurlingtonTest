using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurlingServer
{

    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength()]
        public string FirstName { get; set; }
        [Required]
        [MaxLength()]
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Database.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public Models.Endereco Endereco { get; set; }
        public Models.Gerente Gerente { get; set; }
    }
}

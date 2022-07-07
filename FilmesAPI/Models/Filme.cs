using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório!")] // Validações
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório!")] // Validações
        public string Diretor { get; set; }
        [MaxLength(30, ErrorMessage = "O campo de genero não pode ser maior que 30 caracteres")] // Validações
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no máximo 600 min")] // Validações
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}

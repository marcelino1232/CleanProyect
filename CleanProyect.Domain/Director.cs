using CleanProyect.Domain.Comman;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanProyect.Domain
{
    public class Director : BaseDomainModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [ForeignKey("VideoId")]
        public int VideoId { get; set; }

        public Video? Video { get; set; }

    }
}

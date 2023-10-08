using CleanProyect.Domain.Comman;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanProyect.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actors = new HashSet<Actor>();
        }

        public string? Nombre { get; set; }

        [ForeignKey("StreamerId")]
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor>? Actors { get; set; }
        public virtual Director? Director { get; set; }
    }
}

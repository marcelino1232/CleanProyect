using CleanProyect.Domain.Comman;

namespace CleanProyect.Domain
{
    public class Streamer : BaseDomainModel
    { 
        public string? Nombre { get; set; }
        public string? Url { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }
    }
}

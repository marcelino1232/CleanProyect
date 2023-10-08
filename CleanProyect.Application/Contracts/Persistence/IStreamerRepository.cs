using CleanProyect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProyect.Application.Contracts.Persistence
{
    public interface IStreamerRepository : IAsyncRepository<Streamer>
    {

    }
}

using AutoMapper;
using CleanProyect.Application.Contracts.Persistence;
using CleanProyect.Application.Exceptions;
using CleanProyect.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanProyect.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository streamerRepository;
        private readonly ILogger<DeleteStreamerCommandHandler> logger;
        private readonly IMapper mapper;

        public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository,ILogger<DeleteStreamerCommandHandler> logger, IMapper mapper)
        {
            this.streamerRepository = streamerRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            await streamerRepository.DeleteAsync(streamerToDelete);

            logger.LogInformation($"El {request.Id} streamer fue eliminado con exito");

            return Unit.Value;
        }
    }
}

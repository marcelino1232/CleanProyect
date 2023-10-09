using AutoMapper;
using CleanProyect.Application.Contracts.Persistence;
using CleanProyect.Application.Exceptions;
using CleanProyect.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanProyect.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommnandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository streamerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateStreamerCommnandHandler> logger;

        public UpdateStreamerCommnandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommnandHandler> logger)
        {
            this.streamerRepository = streamerRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate =  await streamerRepository.GetByIdAsync(request.Id);

            if(streamerToUpdate == null)
            {
                logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            mapper.Map(request,streamerToUpdate,typeof(UpdateStreamerCommand), typeof(Streamer));

            await streamerRepository.UpdateAsync(streamerToUpdate);

            logger.LogInformation($"La operacion fue exitosa actualixando el Streamer {request.Id}");

            return Unit.Value;
        }
    }
}

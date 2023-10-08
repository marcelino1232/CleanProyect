using AutoMapper;
using CleanProyect.Application.Contracts.Infrastructure;
using CleanProyect.Application.Contracts.Persistence;
using CleanProyect.Application.Models;
using CleanProyect.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanProyect.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository streamerRepository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly ILogger<CreateStreamerCommandHandler> logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper , IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            this.streamerRepository = streamerRepository;
            this.emailService = emailService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = mapper.Map<Streamer>(request);

            var resultado = await streamerRepository.AddAsync(streamerEntity);

            logger.LogInformation($"Registrado Corretamente Id : { resultado.Id }");

            await SendEmail(resultado);

            return resultado.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "marcelinoheredia.02@gmail.com",
                Body = "La compania de streamer fue Creado Corretamente",
                Subject = "Mensaje de Alerta"
            };

            try
            {
                await emailService.SendEmail(email);
            }catch(Exception ex)
            {
                logger.LogError($"Errores enviando el email de {streamer.Id}");
            }
        }
    }
}

using FluentValidation;

namespace CleanProyect.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidation : AbstractValidator<UpdateStreamerCommand>
    {
       // private readonly IStreamerRepository streamerRepository;

        public UpdateStreamerCommandValidation()
        {

            //this.streamerRepository = streamerRepository;

            //RuleFor(p => p.Id).Custom(async (Id, context) =>
            //{
            //    var resultado = await streamerRepository.Exist(x => x.Id == Id);

            //    if (!resultado)
            //    {
            //        context.AddFailure("El Streamer ya Existe");
            //    }
            //});

            RuleFor(p => p.Nombre)
               .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
               .NotNull()
               .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50  caracteres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("la {Url} no puede estar en blanco");
        }
        
    }
}

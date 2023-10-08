using AutoMapper;
using CleanProyect.Application.Contracts.Persistence;
using MediatR;

namespace CleanProyect.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideoListQueryHandler : IRequestHandler<GetVideoListQuery, List<VideosVm>>
    {
        private readonly IVideoRepository videoRepository;
        private readonly IMapper mapper;

        public GetVideoListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideoListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await videoRepository.GetVideoByNombre(request._Username);
            return mapper.Map<List<VideosVm>>(videoList);
        }
    }
}

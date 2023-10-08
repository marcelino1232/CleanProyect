using AutoMapper;
using CleanProyect.Application.Features.Streamers.Commands.CreateStreamer;
using CleanProyect.Application.Features.Videos.Queries.GetVideosList;
using CleanProyect.Domain;

namespace CleanProyect.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideosVm>();
            CreateMap<CreateStreamerCommand, Streamer>();
        }
    }
}

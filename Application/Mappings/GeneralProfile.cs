using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region commands
            CreateMap<CreateAuthorCommand, Author>();
            #endregion
        }
    }
}

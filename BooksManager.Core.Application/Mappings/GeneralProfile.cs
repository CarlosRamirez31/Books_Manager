using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using Application.Feautres.Authors.Commands.UpdateAuthorCommand;
using AutoMapper;
using BooksManager.Core.Application.Dtos;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region commands

            #region Author
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            #endregion

            #endregion
        }
    }
}

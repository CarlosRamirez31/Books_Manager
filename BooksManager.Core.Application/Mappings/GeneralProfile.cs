using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using Application.Feautres.Authors.Commands.UpdateAuthorCommand;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Users;
using BooksManager.Core.Application.Feautres.Authors.Queries.GetAllAuthor;
using BooksManager.Core.Application.Parameters;
using BooksManager.Core.Application.Wrappers;
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
            CreateMap<PageResponse<Author>, PageResponse<AuthorResponseDto>>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            #endregion

            #endregion
        }
    }
}

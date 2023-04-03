using Application.Feautres.Authors.Commands.CreateAuthorCommand;
using Application.Feautres.Authors.Commands.UpdateAuthorCommand;
using AutoMapper;
using BooksManager.Core.Application.Dtos.Author;
using BooksManager.Core.Application.Dtos.Book;
using BooksManager.Core.Application.Dtos.Comment;
using BooksManager.Core.Application.Feautres.Books.Commands.CreateBookCommand;
using BooksManager.Core.Application.Feautres.Books.Commands.UpdateBookCommand;
using BooksManager.Core.Application.Feautres.Comments.Commands.CreateCommentCommand;
using BooksManager.Core.Application.Feautres.Comments.Commands.UpdateCommentCommand;
using BooksManager.Core.Application.Wrappers;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Mappings

            #region Author
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<PageResponse<Author>, PageResponse<AuthorResponseDto>>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            #endregion

            #region Book
            CreateMap<Book, BookResponseDto>();
            CreateMap<PageResponse<Book>, PageResponse<BookResponseDto>>();
            CreateMap<CreateBookCommand, Book>()
                .ForMember(x => x.AuthorsBooks, opt => opt.MapFrom(AuthorsBookMap));

            CreateMap<UpdateBookCommand, Book>()
                .ForMember(x => x.AuthorsBooks, opt => opt.MapFrom(AuthorsBookMap));
            #endregion

            #region Comment

            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<UpdateCommentCommand, Comment>();
            CreateMap<Comment, CommentResponseDto>();

            #endregion

            #endregion
        }


        #region Book methods

        private ICollection<AuthorsBook> AuthorsBookMap(CreateBookCommand command, Book book)
        {
            var result = new List<AuthorsBook>();

            if (command.AuthorsIds is null)
                return result;

            foreach(var id in command.AuthorsIds)
            {
                result.Add(new AuthorsBook() { AuthorId = id });
            }

            return result;
        }

        private ICollection<AuthorsBook> AuthorsBookMap(UpdateBookCommand command, Book book)
        {
            var result = new List<AuthorsBook>();

            if (command.AuthorsIds is null)
                return result;

            foreach(var id in command.AuthorsIds)
            {
                result.Add(new AuthorsBook() { AuthorId = id });
            }

            return result;
        }

        #endregion
    }
}

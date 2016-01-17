using AutoMapper;
using Library.DAL.Entities;
using Library.Dto.Dto;

namespace Library.Bootstrap
{
    /// <summary>
    /// The auto mapper config.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// The register mapping.
        /// </summary>
        public static void RegisterMapping()
        {
            MapEntityToEntity();
            MapEntityToDto();
            MapDtoToEntity();
        }

        /// <summary>
        /// Map entity to entity.
        /// </summary>
        private static void MapEntityToEntity()
        {
            Mapper.CreateMap<Book, Book>();
            Mapper.CreateMap<Category, Category>();
        }

        /// <summary>
        /// Map entity to dto.
        /// </summary>
        private static void MapEntityToDto()
        {
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Category, CategoryDto>();
        }

        /// <summary>
        /// Map dto to entity.
        /// </summary>
        private static void MapDtoToEntity()
        {
            Mapper.CreateMap<BookDto, Book>()
                .ForMember(d => d.Categories, opt => opt.Ignore());
            Mapper.CreateMap<CategoryDto, Category>();
        }
    }
}

using System.Linq;

using AutoMapper;

using Library.Dto.Dto;
using Library.Utilites.Extensions;
using Library.Web.ViewModel;

namespace Library.Web.App_Start
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
            MapDtoToViewModel();
            MapViewModelToDto();
        }

        /// <summary>
        /// The map dto to view model.
        /// </summary>
        private static void MapDtoToViewModel()
        {
            Mapper.CreateMap<CategoryDto, CategoryViewModel>();
            Mapper.CreateMap<BookDto, BookViewModel>()
                .ForMember(d => d.SelectedCategoriesId, opt => opt.MapFrom(i => i.Categories.Select(c => c.Id)));
            Mapper.CreateMap<ReportDto, ReportViewModel>();
            
        }

        /// <summary>
        /// The map view model to dto.
        /// </summary>
        private static void MapViewModelToDto()
        {
            Mapper.CreateMap<CategoryViewModel, CategoryDto>();
            Mapper.CreateMap<BookViewModel, BookDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(i => i.SelectedCategoriesId.SelectNull(c => new CategoryDto { Id = c })));
            Mapper.CreateMap<ReportViewModel, ReportDto>();
        }
    }
}
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Library.DAL.Api;
using Library.Dto.Api;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// The base controller with CRUD operations.
    /// </summary>
    /// <typeparam name="TDto">The Dto object.</typeparam>
    /// <typeparam name="TEntity">The entity object.</typeparam>
    public class BaseCrudController<TDto, TEntity> : BaseController
        where TDto : class, IBaseDto
        where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Get one object by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TDto"/>.</returns>
        public TDto Get(int id)
        {
            var entity = repository.Get<TEntity>(id);

            return Mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// The get all objects.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<TDto> GetAll()
        {
            var entities = repository.Get<TEntity>();

            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        /// <summary>
        /// Create object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        [HttpPost]
        public virtual void Create(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);

            repository.Add(entity);

            repository.Save();
        }

        /// <summary>
        /// Update object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        [HttpPut]
        public virtual void Update(TDto dto)
        {
            var entity = repository.Get<TEntity>(dto.Id);

            Mapper.Map(dto, entity);

            repository.Save();
        }

        /// <summary>
        /// The delete object.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(int id)
        {
            var entity = this.repository.Get<TEntity>(id);
            repository.Delete(entity);

            repository.Save();
        }
    }
}

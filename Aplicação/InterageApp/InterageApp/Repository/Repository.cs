using InterageApp.Exceptions;
using InterageApp.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace InterageApp.Repository
{
    public class Repository<Entity, DTO, Chave> : IRepository<Entity, DTO, Chave> where DTO : class where Entity: class
    {
        private readonly DbContext _db;
        private readonly IMapper<Entity, DTO> _mapper;

        public Repository(DbContext db, IMapper<Entity, DTO> mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public DTO Delete(Chave chave)
        {
            Entity entity = _db.Set<Entity>().Find(chave);
            if (entity == null) throw new NotFoundException(typeof(Entity).Name);
            DTO dto = _mapper.Map(entity);
            _db.Set<Entity>().Remove(entity);
            _db.SaveChanges();
            return dto;
        }

        public ICollection<DTO> Query(Func<Entity, bool> predicate)
        {
            return _mapper.Map(_db.Set<Entity>().Where(predicate).ToList());
        }

        public ICollection<DTO> Read()
        {
            return _mapper.Map(_db.Set<Entity>().ToList());
        }

        public DTO Read(Chave chave)
        {
            Entity entity = _db.Set<Entity>().Find(chave);
            if (entity == null) throw new NotFoundException(typeof(Entity).Name);
            DTO dto = _mapper.Map(entity);
            return dto;
        }

        public DTO Save(DTO resource)
        {
            Entity entity = _mapper.Map(resource);
            _db.Set<Entity>().AddOrUpdate(entity);
            _db.SaveChanges();
            return _mapper.Map(entity);

        }
    }
}
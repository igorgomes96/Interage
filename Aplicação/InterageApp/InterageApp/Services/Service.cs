using InterageApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Services
{
    public class Service<Entity, DTO, Chave> : IService<Entity, DTO, Chave> where DTO : class where Entity : class
    {
        private readonly IRepository<Entity, DTO, Chave> _repo;

        public Service(IRepository<Entity, DTO, Chave> repository)
        {
            _repo = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public DTO Delete(Chave chave)
        {
            return _repo.Delete(chave);
        }

        public ICollection<DTO> Read()
        {
            return _repo.Read();
        }

        public DTO Read(Chave chave)
        {
            return _repo.Read(chave);
        }

        public DTO Save(DTO resource)
        {
            return _repo.Save(resource);
        }
    }
}
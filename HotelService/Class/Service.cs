using HotelEntity.Class;
using HotelRepository.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Class
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        Repository<TEntity> repo = new Repository<TEntity>();
        public int Delete(TEntity entity)
        {
           return  repo.Delete(entity);
        }

        public TEntity Get(int id)
        {
            return repo.Get(id);
        }

        public List<TEntity> GetAll()
        {
            return repo.GetAll();
        }

        public int Insert(TEntity entity)
        {
           return repo.Insert(entity);
           
        }

        public int Update(TEntity entity)
        {
            return repo.Update(entity);
        }
    }
}

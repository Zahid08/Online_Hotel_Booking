using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Interface
{
  public interface IService<TEntity>where TEntity:Entity
    {

        List<TEntity> GetAll();
        TEntity Get(int id);
        int Insert(TEntity entity);
        int Delete(TEntity entity);
        int Update(TEntity entity);

    }
}

using Kitchen.Core.Commons;
using Kitchen.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Delete(TEntity entity);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> GetbyId(int id);
        TEntity GetbyIdAznotraking(params object[] ids);
        IQueryable<TEntity> GetAll { get; }
        IQueryable<TEntity> GetAllAsNotraking { get; }
        //User
        Task<User> GetbyUsername(string UserName);
        Task<User> GetbyUserEmail(string Email);
        Task<User> GetbyUseToken(string Token);
    }
}

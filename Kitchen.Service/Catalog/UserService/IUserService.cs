using Kitchen.Core.Domain.User;
using Kitchen.Service.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserListItmeDTO>> GettAll();
        Task<UserListItmeDTO> GetById(int Id);
        Task<UserRigesterDTO> RigesterUser(UserRigesterDTO userrigester);
        Task<UserUpdateDTO> UpdateUser(UserUpdateDTO userrigester);
        Task UpdateUserRole(UpdateUserRoleDTO userRole);
        Task Delete(int id);
        Task<string> Login(User user);
        bool IsExist(int Id);
        Task<IEnumerable<UserLoginDTO>> searchbuUsername(UserLoginDTO userLogin);

    }
}

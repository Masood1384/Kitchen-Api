using Kitchen.Service.DTOs.GroupDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.GroupService
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupListItemDTO>> GetAllGroup();
        Task<GroupListItemDTO> GetGroupById(int Id);
        Task<GroupDTO> AddGroup(GroupDTO groupDTO);
        Task<GroupDTO> UpdateGroup(GroupDTO groupDTO);
        Task DeleteGroup(int Id);
        bool IsExists(int Id);
    }
}

using Kitchen.Core.Domain.Food;
using Kitchen.Core.Extension;
using Kitchen.Data.Repository;
using Kitchen.Service.DTOs.FoodDTO;
using Kitchen.Service.DTOs.GroupDTO;
using Microsoft.EntityFrameworkCore;
using shop.Service.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.Catalog.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _grouprepository;
        public GroupService(IRepository<Group> Grouprepository)
        {
            _grouprepository = Grouprepository;
        }
        public async Task<GroupDTO> AddGroup(GroupDTO groupDTO)
        {
            var group = groupDTO.ToEntity<Group>();
            group.CreateON = DateTime.Now;
            group.UpdateON = DateTime.Now;
            await _grouprepository.Add(group);
            groupDTO.ID = group.ID;
            return groupDTO;

        }

        public async Task DeleteGroup(int Id)
        {
            var group =await _grouprepository.GetbyId(Id);
            await _grouprepository.Delete(group);
        }

        public async Task<IEnumerable<GroupListItemDTO>> GetAllGroup()
        {
            var list =await _grouprepository.GetAllAsNotraking.Select(p => new GroupListItemDTO
            {
                ID = p.ID,
                Title = p.Title,
                CreateON = p.CreateON,
                UpdateON = p.UpdateON,
                LocalCreate = p.CreateON.ToPersian(),
                LocalUpdate = p.UpdateON.ToPersian(),

            }).ToListAsync();
            return list;
        }

        public async Task<GroupListItemDTO> GetGroupById(int Id)
        {
            var list = _grouprepository.GetbyIdAznotraking(Id);
            var dto = list.ToDTO<GroupListItemDTO>();
            return dto;
        }

        public bool IsExists(int Id)
        {
            var prod = _grouprepository.GetbyIdAznotraking(Id);
            if (prod == null) return false;
            return true;
        }

        public async Task<GroupDTO> UpdateGroup(GroupDTO groupDTO)
        {

            var group =await _grouprepository.GetbyId(groupDTO.ID);
            group.Title = groupDTO.Title;
            group.UpdateON = DateTime.Now;
            await _grouprepository.Update(group);
            return groupDTO;
        }
    }
}

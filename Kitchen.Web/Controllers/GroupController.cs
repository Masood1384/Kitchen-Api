using Kitchen.Framework;
using Kitchen.Service.Catalog.GroupService;
using Kitchen.Service.DTOs.GroupDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Web.Controllers
{
    public class GroupController:KitchenController
    {
        #region Field
        private readonly IGroupService _groupService;
        public GroupController(IGroupService GroupService)
        {
            _groupService = GroupService;
        }
        #endregion
        #region Group
        [HttpGet]
        public async Task<IActionResult> GetAllGroup(int id)
        {
            return Ok(await _groupService.GetAllGroup());
        }
        [HttpGet("Find/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (!_groupService.IsExists(Id))
            {
                return NotFound();
            }
            else
            {
                var list = await _groupService.GetGroupById(Id);
                return Ok(list);
            }
        }
        [HttpPost , Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGroup(GroupDTO group)
        {
            if(group.ID != 0)
            {
                return BadRequest();
            }
            else
            {
                await _groupService.AddGroup(group);
                return CreatedAtAction("GetById", new { Id = group.ID }, group);
            }
        }
        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGroup(int Id)
        {
            if(!_groupService.IsExists(Id))
            {
                return NotFound();
            }
            else
            {
                await _groupService.DeleteGroup(Id);
                return Ok("Group Removed");
            }
            
        }
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGroup(GroupDTO group)
        {
            if(!_groupService.IsExists(group.ID))
            {
                return NotFound();
            }
            else
            {
                await _groupService.UpdateGroup(group);
                return Ok(group);
            }
        }
        #endregion
    }
}

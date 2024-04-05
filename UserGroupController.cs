using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EagleEye.Core.Authorization;
using EagleEye.Data.Entities.Detections;
using EagleEye.Data.Entities.Identity;
using EagleEye.UI.Core.Models;
using EagleEye.UI.Web.Controllers;
using EagleEye.UI.Web.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EagleEye.UI.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.ADMINISTRATORS)]

    public class UserGroupController : EEControllerBase
    {
        private UserManager<DomainUser> userManager;
        private readonly IUserGroupService _iUserGroupService;

        public UserGroupController( UserManager<DomainUser> userMrg, IUserGroupService iUserGroupService) 
        {
            userManager = userMrg;
            _iUserGroupService = iUserGroupService;
        }

        public ViewResult Index() => View();

        public ViewResult Create() => View();
        

        [HttpGet]
        public IActionResult GetAll()
        {
            var usergroup = _iUserGroupService.GetAll();
            return Ok(usergroup);
        }

        [HttpPost]
        public UserGroup Post([FromBody] UserGroup value)
        {
            var tempUserGroup = _iUserGroupService.Insert(value);
            return tempUserGroup;
        }

        [HttpPut("{id}")]
        public UserGroup Put(int id, [FromBody] UserGroup value)
        {
            value.Id = id;
            var tempUserGroup = _iUserGroupService.Update(value);
            return tempUserGroup;
        }

        [HttpDelete("{id}")]
        public UserGroup Delete(int id)
        {
            return _iUserGroupService.Delete(new UserGroup() { Id = id });
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
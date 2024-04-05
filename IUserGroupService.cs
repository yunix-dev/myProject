using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EagleEye.UI.Web.Core.Services
{
    public interface IUserGroupService : IServiceBase<UserGroup>
    {
        public UserGroup UpdateUserGroup(UserGroup item);
    }
}

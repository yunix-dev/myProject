using EagleEye.Data.Entities;

namespace EagleEye.UI.Web.Core.Services
{
    public class UserGroup : Entity<int>
    {
        /// <summary>
        /// 그룸 명
        /// </summary>
        public int id { get; set; }
        
        public string GroupName { get; set; }
    }
}

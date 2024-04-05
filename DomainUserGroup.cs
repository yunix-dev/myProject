using EagleEye.Data.Entities.Detections;
using System;
using System.Collections.Generic;
using System.Text;

namespace EagleEye.Data.Entities.Identity
{
    public class DomainUserGroup : IEntity<int>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DomainUserGroup() : base() { }
    }
}

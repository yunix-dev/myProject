using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EagleEye.UI.Web.Core.Services
{
    public class UserGroupService : ServiceDapperBase<UserGroup, int>, IUserGroupService
    {
        public UserGroupService(IConfiguration configuration) : base(configuration) { }
        public override List<UserGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserGroup UpdateUserGroup(UserGroup item)
        {
            var connection = this.GetConnection();

            var query2 = $@"UPDATE [dbo].[TB_UserGroup]
                           SET    
                               [GroupName] = @GroupName
                            WHERE Id = @Id";

            var result2 = connection.Execute(query2, item);
            return item;
        }

        public override UserGroup Insert(UserGroup item)
        {
            var connection = this.GetConnection();
            var query = $@"INSERT INTO [dbo].[TB_UserGroup]
               ([Id]
               ,[GroupName])
         VALUES
               (@Id
               ,@GroupName)";
            var resultCount = connection.Execute(query, item);
            return item;

        }

        public override UserGroup Update(UserGroup item)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<UserGroup> GetPaging(int start, int length)
        {
            throw new NotImplementedException();
        }

        public override UserGroup Get(UserGroup item)
        {
            throw new NotImplementedException();
        }

        public override UserGroup Delete(UserGroup item)
        {
            var connection = this.GetConnection();
            var query = "Delete TB_UserGroup Where Id = @Id";
            var result = connection.Execute(query, item);
            return item;
        }

        UserGroup IUserGroupService.UpdateUserGroup(UserGroup item)
        {
            throw new NotImplementedException();
        }
    }
}

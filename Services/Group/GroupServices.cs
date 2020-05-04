using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Product
{
    public class GroupServices : IGroupServices
    {
        private Models.Repositories.GroupRepository bl_group = new Models.Repositories.GroupRepository();

        public bool AddGroup(Group group)
        {
            return bl_group.Add(group);
        }

        public bool DeleteGroup(int Id)
        {
            var group = bl_group.Find(Id);
            return bl_group.Delete(group);
        }

        public bool UpdateGroup(Group group)
        {
            return bl_group.Update(group);
        }
    }
}

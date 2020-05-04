using Models;

namespace Services.Product
{
    public interface IGroupServices
    {

        bool AddGroup(Group group);
        bool UpdateGroup(Group group);
        bool DeleteGroup(int Id);
    }
}

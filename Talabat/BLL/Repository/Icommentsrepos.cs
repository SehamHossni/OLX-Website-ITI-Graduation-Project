using DAL.Entities;

namespace BLL.Repository
{
    public interface Icommentsrepos
    {
        Task Add(Comment Ent);
    }
}
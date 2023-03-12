using Data.Classes;
namespace Data.IRepository
{
    public interface IMonstersRepository
    {
        public Task<List<Monsters>> GetAll();
        public Task Update(Monsters monsters);
    }
}

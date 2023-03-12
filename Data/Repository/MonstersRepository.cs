using Microsoft.EntityFrameworkCore;
using Data.IRepository;
using Data.Classes;

namespace Data.Repository
{
    public class MonstersRepository : IMonstersRepository
    {
        public MyDbContext _context { get; set; }
        public MonstersRepository(MyDbContext context) {
            _context = context;
        }
        public async Task<List<Monsters>> GetAll()
        {
            return await _context.Monsters.ToListAsync();
        }
        public async Task Update(Monsters monsters)
        {
            _context.Monsters.Update(monsters);
            await _context.SaveChangesAsync();
        }
    }
}

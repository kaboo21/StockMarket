using DataAccessLayer.Data;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class LotItemRepository : ILotItemRepository
    {
        private readonly ApplicationDbContext _context;

        public LotItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<LotItemEntity> GetAll()
        {
            var result = _context.LotItems.ToList();
            return result;
        }

        public LotItemEntity GetById(int id)
        {
            return _context.LotItems.FirstOrDefault(l => l.Id == id);
        }

        public void Add(LotItemEntity lot)
        {
            _context.LotItems.Add(lot);
            _context.SaveChanges();
        }

        public bool Update(LotItemEntity lot)
        {
            var lotDb = _context.LotItems.FirstOrDefault(l => l.Id == lot.Id);
            if (lotDb == null)
            {
                return false;
            }
            _context.LotItems.Update(lot);
            _context.SaveChanges();

            return true;
        }

        public LotItemEntity? SaleLotItemNumber(int id, int numberToSale)
        {
            var lotDb = _context.LotItems.FirstOrDefault(l => l.Id == id);
            if (lotDb == null)
            {
                return null;
            }

            lotDb.RemainShareNumber -= numberToSale;
            var result =_context.LotItems.Update(lotDb).Entity;
            _context.SaveChanges();

            return result;
        }


        public bool Delete(int id)
        {
            var lotDb = _context.LotItems.FirstOrDefault(l => l.Id == id);
            if (lotDb == null)
            {
                return false;
            }
            _context.LotItems.Remove(lotDb);
            _context.SaveChanges();

            return true;
        }
    }
}

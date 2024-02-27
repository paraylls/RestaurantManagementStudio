using BarService.Models;

namespace BarService.Data
{
    public class BartenderRepo : IBartenderRepo
    {
        private readonly ApplicationDbContext _context;

        public BartenderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBartender(BartenderModel bartender)
        {
            if (bartender == null)
            {
                throw new ArgumentNullException(nameof(bartender));
            }

            _context.Bartenders.Add(bartender);
            _context.SaveChanges();
        }

        public void DeleteBartender(int id)
        {
            var bartenderToDelete = _context.Bartenders.FirstOrDefault(b => b.Id == id);
            if (bartenderToDelete != null)
            {
                _context.Bartenders.Remove(bartenderToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<BartenderModel> GetAllBartenders() => _context.Bartenders.ToList();


        public BartenderModel GetBartenderById(int id) => _context.Bartenders.FirstOrDefault(b => b.Id == id);

        public void UpdateBartender(int id, BartenderModel bartender)
        {
            var existingBartender = _context.Bartenders.FirstOrDefault(b => b.Id == id);
            if (existingBartender != null)
            {
                _context.SaveChanges();
            }
        }
    }
}

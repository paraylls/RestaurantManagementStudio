using BarService.Models;

namespace BarService.Data
{
    public interface IBartenderRepo
    {
        IEnumerable<BartenderModel> GetAllBartenders();
        BartenderModel GetBartenderById(int id);
        void CreateBartender(BartenderModel bartender);
        void UpdateBartender(int id, BartenderModel bartender);
        void DeleteBartender(int id);
    }
}

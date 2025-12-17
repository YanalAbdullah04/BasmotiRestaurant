
using Microsoft.VisualBasic;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {

        public MasterOfferRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.EditDate = DateTime.Now;
            data.IsActive = !data.IsActive;
            Db.MasterOffers.Update(data);
            Db.SaveChanges();

        }

        public void Add(MasterOffer entity)
        {
            entity.CreatDate= DateTime.Now;
            entity.EditDate = DateTime.Now;
            Db.MasterOffers.Add(entity);
            Db.SaveChanges();

        }

        public void Delete(int Id, MasterOffer entity)
        {
            var Data = Find(Id);
            Data.EditDate = DateTime.Now;
            Data.IsDeleted= true;
            Db.MasterOffers.Update(Data);
            Db.SaveChanges();



        }

        public MasterOffer Find(int Id)
        {
            return Db.MasterOffers.SingleOrDefault(x=>x.MasterOfferId==Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
            entity.EditDate= DateTime.Now;
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return Db.MasterOffers.Where(x => x.IsDeleted == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return Db.MasterOffers.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }
    }
}

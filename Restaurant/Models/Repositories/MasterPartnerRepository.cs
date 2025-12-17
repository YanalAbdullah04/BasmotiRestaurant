
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public MasterPartnerRepository( ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            Db.MasterPartners.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            entity.CreatDate = DateTime.Now;
            entity.EditDate = entity.CreatDate;
            entity.IsActive = true;
            Db.MasterPartners.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            var data = Find(Id);
            data.EditDate= DateTime.Now;
            data.IsDeleted = true;
            Db.MasterPartners.Update(data);
            Db.SaveChanges();

        }

        public MasterPartner Find(int Id)
        {
            return Db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);

        }

        public void Update(int Id, MasterPartner entity)
        
        {
            entity.EditDate = DateTime.Now;
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }


        public List<MasterPartner> View()
        {
            return Db.MasterPartners.Where(x=>x.IsDeleted==false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
           return Db.MasterPartners.Where(x=>x.IsDeleted==false&&x.IsActive==true).ToList();
        }



    }
}

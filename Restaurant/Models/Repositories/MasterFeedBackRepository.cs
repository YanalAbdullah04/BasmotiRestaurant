
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterFeedBackRepository : IRepository<MasterFeedBack>
    {
        private readonly ApplicationDbContext db;

        public MasterFeedBackRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            db.MasterFeedBacks.Update(data);
            db.SaveChanges();
            
        }

        public void Add(MasterFeedBack entity)
        {
           entity.CreatDate = DateTime.Now;
           db.MasterFeedBacks.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int Id, MasterFeedBack entity)
        {
          entity=Find(Id);
            entity.IsDeleted = true;
            entity.EditDate= DateTime.Now;
            db.MasterFeedBacks.Update(entity);
            db.SaveChanges();

        }

        public MasterFeedBack Find(int Id)
        {

            return db.MasterFeedBacks.SingleOrDefault(x => x.MasterFeedBackId == Id);

        }

        public void Update(int Id, MasterFeedBack entity)
        {
          entity.EditDate = DateTime.Now;
            db.MasterFeedBacks.Update(entity);
            db.SaveChanges();
        }

        public List<MasterFeedBack> View()
        {
           return db.MasterFeedBacks.Where(x=>x.IsDeleted==false).ToList();
        }

        public List<MasterFeedBack> ViewClient()
        {
            return db.MasterFeedBacks.Where(x => x.IsDeleted ==false &&x.IsActive==true).ToList();
        }
    }
}

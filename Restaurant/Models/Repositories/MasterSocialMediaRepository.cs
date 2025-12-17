
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        private readonly ApplicationDbContext db;

        public MasterSocialMediaRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = Find(Id);
            data.EditDate = DateTime.Now;
            data.IsActive = !data.IsActive;
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();


        }

        public void Add(MasterSocialMedia entity)
        {
            entity.CreatDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            db.MasterSocialMedia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedia entity)
        {
            var data=Find(Id);
            data.IsDeleted = true;
            data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(data);
            db.SaveChanges();

        }

        public MasterSocialMedia Find(int Id)
        {
            return db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediaId == Id);
        }

        public void Update(int Id, MasterSocialMedia entity)
        {
            entity.EditDate= DateTime.Now;
            db.MasterSocialMedia.Update(entity);
            db.SaveChanges();

        }

        public List<MasterSocialMedia> View()
        {
            return db.MasterSocialMedia.Where(x=>x.IsDeleted==false).ToList();
        }

        public List<MasterSocialMedia> ViewClient()
        {
            return db.MasterSocialMedia.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();

        }
    }
}

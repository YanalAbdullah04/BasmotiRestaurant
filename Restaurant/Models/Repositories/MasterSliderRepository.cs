
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        private readonly ApplicationDbContext db;

        public MasterSliderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {

            var data = Find(Id);
            data.EditDate = DateTime.Now;
            data.IsActive = !data.IsActive;
            db.MasterSliders.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.CreatDate = DateTime.Now;
            entity.EditDate = entity.CreatDate;
            db.MasterSliders.Add(entity);
            db.SaveChanges() ;

        
        }

        public void Delete(int Id, MasterSlider entity)
        {
           var data=Find(Id);
            data.EditDate= DateTime.Now;
            data.IsDeleted = true;
            db.MasterSliders.Update(data);
            db.SaveChanges() ;
        }

        public MasterSlider Find(int Id)
        {
            return db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            entity.EditDate = DateTime.Now;
            db.MasterSliders.Update(entity);
            db.SaveChanges() ;

        }

        public List<MasterSlider> View()
        {
            return db.MasterSliders.Where(x => x.IsDeleted == false).ToList();

        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }
    }
}

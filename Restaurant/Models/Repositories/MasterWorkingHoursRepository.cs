
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHoursRepository : IRepository<MasterWorkingHours>
    {
        public MasterWorkingHoursRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges();

            
        }

        public void Add(MasterWorkingHours entity)
        {
         entity.CreatDate= DateTime.Now;
            entity.EditDate = entity.CreatDate;
            Db.MasterWorkingHours.Add(entity);
            Db.SaveChanges() ;

        }

        public void Delete(int Id, MasterWorkingHours entity)
        {
            var data= Find(Id);
            data.IsDeleted = true;
            data.EditDate = DateTime.Now;
            Db.MasterWorkingHours.Update(data);
            Db.SaveChanges() ;
        }

        public MasterWorkingHours Find(int Id)
        {
            return Db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == Id);


        }

        public void Update(int Id, MasterWorkingHours entity)
        {

            entity.EditDate = DateTime.Now;
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterWorkingHours> View()
        {
            return Db.MasterWorkingHours.Where(x => x.IsDeleted == false).ToList();
        }

        public List<MasterWorkingHours> ViewClient()
        {
            return Db.MasterWorkingHours.Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
        }
    }
}

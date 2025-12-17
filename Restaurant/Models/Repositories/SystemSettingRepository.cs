
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {

        public SystemSettingRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            Db.SystemSettings.Update(data);
            Db.SaveChanges(); 
        }

        public void Add(SystemSetting entity)
        {
            entity.CreatDate = DateTime.Now;
            entity.EditDate = entity.CreatDate;
            Db.SystemSettings.Add(entity);
            Db.SaveChanges();   
        }

        public void Delete(int Id, SystemSetting entity)
        {
           var data=Find(Id);
            data.IsDeleted = true;
            data.EditDate = DateTime.Now;
            Db.SystemSettings.Update(data);
            Db.SaveChanges() ; 
        }

        public SystemSetting Find(int Id)
        {
            return Db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            entity.EditDate = DateTime.Now;
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return Db.SystemSettings.Where(x => x.IsDeleted==false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {

            return Db.SystemSettings.Where(x => x.IsDeleted==false&&x.IsActive).ToList();
        }
    }
}

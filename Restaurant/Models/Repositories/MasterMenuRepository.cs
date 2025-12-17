
using Microsoft.VisualBasic;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public MasterMenuRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateAndTime.Now;
            Db.MasterMenus.Update(data);
            Db.SaveChanges();
        }

        public void Add(MasterMenu entity)
        {
            entity.CreatDate = DateAndTime.Now;
            entity.EditDate = entity.CreatDate;
            Db.MasterMenus.Add(entity);
            Db.SaveChanges();

        }

        public void Delete(int Id, MasterMenu entity)
        {
            entity = Find(Id);
            entity.IsDeleted = true;
            entity.EditDate = DateTime.Now;
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return Db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            entity.EditDate = DateAndTime.Now;
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return Db.MasterMenus.Where(x => x.IsDeleted == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return Db.MasterMenus.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();


        }
    }
}

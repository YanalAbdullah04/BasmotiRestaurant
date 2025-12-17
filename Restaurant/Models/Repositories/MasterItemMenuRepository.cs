
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {

        public ApplicationDbContext Db { get; }

        public MasterItemMenuRepository( ApplicationDbContext db)
        {
            Db = db;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();

        }

        public void Add(MasterItemMenu entity)
        {
         entity.CreatDate= DateTime.Now;
            entity.EditDate= DateTime.Now;
            Db.MasterItemMenus.Add(entity);
            Db.SaveChanges();


        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var data=Find(Id);
            data.EditDate = DateTime.Now;
            data.IsDeleted = true;
            Db.MasterItemMenus.Update(data);
            Db.SaveChanges();
           

        }

        public MasterItemMenu Find(int Id)
        {
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).SingleOrDefault(x=>x.MasterItemMenuId==Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
          entity.EditDate = DateTime.Now;
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x=>x.IsDeleted==false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x=>x.IsDeleted==false&&x.IsActive==true).ToList();
        }
    }
}

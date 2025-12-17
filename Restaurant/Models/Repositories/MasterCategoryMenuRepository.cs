
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public MasterCategoryMenuRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {

            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();



        }

        public void Add(MasterCategoryMenu entity)
        {
            entity.CreatDate = DateTime.Now;
            Db.MasterCategoryMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var data = Find(Id);
                  
           data.IsDeleted = true;
           data.EditDate = DateTime.Now;
            Db.MasterCategoryMenus.Update(data);
            Db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            return Db.MasterCategoryMenus.SingleOrDefault(x=>x.MasterCategoryMenuId==Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            entity.EditDate = DateTime.Now;
            

            Db.MasterCategoryMenus.Update(entity);

            Db.SaveChanges() ;
        }

        public List<MasterCategoryMenu> View()
        {


            return Db.MasterCategoryMenus.Where(x=>x.IsDeleted==false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return Db.MasterCategoryMenus.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();

        }
    }
}



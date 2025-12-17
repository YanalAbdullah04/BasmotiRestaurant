
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterServicesRepository : IRepository<MasterServices>
    {
        public MasterServicesRepository( ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            Db.MasterServices.Update(data);
            Db.SaveChanges();

            
            
        }

        public void Add(MasterServices entity)
        {
          entity.CreatDate=DateTime.Now;
            entity.EditDate = entity.CreatDate;
            Db.MasterServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, MasterServices entity)
        {
            var data = Find(Id);
             data.IsDeleted = !data.IsDeleted; ;
            data.EditDate = DateTime.Now;
            Db.MasterServices.Update(data);
            Db.SaveChanges() ;
        }

        public MasterServices Find(int Id)
        {
            return Db.MasterServices.SingleOrDefault(x => x.MasterServicesId == Id);
        }

        public void Update(int Id, MasterServices entity)
        
        {
            entity.EditDate = DateTime.Now;

           Db.MasterServices.Update(entity);
            Db.SaveChanges();


        }


        public List<MasterServices> View()
        {
            return Db.MasterServices.Where(x => x.IsDeleted == false).ToList();

        }

        public List<MasterServices> ViewClient()
        {
           return Db.MasterServices.Where(X=>X.IsDeleted==false&&X.IsActive==true).ToList();

        }
    }
}

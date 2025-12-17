
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        private readonly ApplicationDbContext db;

        public TransactionContactUsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
           
        }

        public void Add(TransactionContactUs entity)
        { entity.CreatDate = DateTime.Now;
            db.TransactionContactUs.Add(entity);
            db.SaveChanges(); 


        }

        public void Delete(int Id, TransactionContactUs entity)
        {
            //var data = Find(Id);
            //entity.IsDeleted = true;
            //db.TransactionContactUs.Update(data);
            //db.SaveChanges();


        }

        public TransactionContactUs Find(int Id)
        {
            return db.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == Id);
        }

        public void Update(int Id, TransactionContactUs entity)
        {
            db.TransactionContactUs.Update(entity);
            db.SaveChanges();
        }

        public List<TransactionContactUs> View()
        {
            return db.TransactionContactUs.Where(x => x.IsDeleted == false).ToList();

        }

        public List<TransactionContactUs> ViewClient()
        {
            return db.TransactionContactUs.Where(x => x.IsDeleted == false).ToList();
        }
    }
}

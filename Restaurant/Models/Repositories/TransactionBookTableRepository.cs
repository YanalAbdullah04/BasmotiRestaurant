
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        private readonly ApplicationDbContext db;

        public TransactionBookTableRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            
           
        }

        public void Add(TransactionBookTable entity)
        {
            entity.CreatDate = DateTime.Now;

            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            //var data= Find(Id);
            //data.IsDeleted = true;
            //db.TransactionBookTables.Update(entity);
            //db.SaveChanges() ;
        }

        public TransactionBookTable Find(int Id)
        {
            return db.TransactionBookTables.SingleOrDefault(x=>x.TransactionBookTableId==Id);
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            //db.TransactionBookTables.Update(entity);
            //db.SaveChanges();

           
        }

        public List<TransactionBookTable> View()
        {
            return   db.TransactionBookTables.Where(x => x.IsDeleted == false).ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
           return db.TransactionBookTables.Where(x => x.IsDeleted == false).ToList();
        }
    }
}

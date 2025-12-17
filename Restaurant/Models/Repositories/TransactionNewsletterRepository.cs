
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public TransactionNewsletterRepository(ApplicationDbContext db )
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Active(int Id)
        {
           
        }

        public void Add(TransactionNewsletter entity)
        {
           entity.CreatDate = DateTime.Now;
            Db.TransactionNewsletters.Add( entity );
            Db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            var data = Find(Id);
            data.IsDeleted = true;
            Db.TransactionNewsletters.Update(data);
            Db.SaveChanges() ;
        }

        public TransactionNewsletter Find(int Id)
        {
            return Db.TransactionNewsletters.SingleOrDefault(x => x.TransactionNewsletterId==Id);

        }

        public void Update(int Id, TransactionNewsletter entity)
        {

        Db.TransactionNewsletters.Update(entity);
            Db.SaveChanges();

        }
        
        public List<TransactionNewsletter> View()
        {
            return Db.TransactionNewsletters.Where(x => x.IsDeleted == false).ToList();

        }

        public List<TransactionNewsletter> ViewClient()
        {
                return Db.TransactionNewsletters.Where(x => x.IsDeleted == false).ToList();
        }
    }
}

namespace Restaurant.Models.Repositories
{
    public interface IRepository<t>
    {
        void Add(t entity);
        void Delete(int Id,t entity);
        void Active(int Id);

        List<t> View();
        t Find(int Id);

        void Update(int Id,t entity);
        List<t> ViewClient();




    }
}

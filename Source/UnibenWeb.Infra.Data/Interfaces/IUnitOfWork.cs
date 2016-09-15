namespace UnibenWeb.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges(bool doLog, string userId); // commit
    }
}
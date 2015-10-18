namespace BaseMVC.Data.UnitOfWork
{
    using Repositories;
    using Model;

    public interface IBaseMVCData
    {
        IRepository<ApplicationUser> Users { get; }

        void SaveChanges();
    }
}

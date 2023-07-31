using ADvanced.Core.Repositories;

namespace ADvanced.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository User { get; }
    public IRoleRepository Role { get; }

    public UnitOfWork(IUserRepository user, IRoleRepository role)
    {
        User = user;
        Role = role;
    }
}
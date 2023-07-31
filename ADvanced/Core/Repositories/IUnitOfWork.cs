namespace ADvanced.Core.Repositories;

public class IUnitOfWork
{
    IUserRepository User { get; }

    IRoleRepository Role { get; }
}
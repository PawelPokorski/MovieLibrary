using MovieLibrary.Core.Interfaces;
using MovieLibrary.Data.Context;

namespace MovieLibrary.Infrastructure;

public class UnitOfWork(MovieContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
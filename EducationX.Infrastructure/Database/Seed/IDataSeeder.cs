using System.Collections.Generic;

namespace EducationX.Infrastructure.Database.Seed
{
    public interface IDataSeeder<TEntityType>
    {
        IEnumerable<TEntityType> Seed();
    }
}

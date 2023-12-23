using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Data;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Converter
{
    public class IdConverter : ValueConverter<Identification, Guid>
    {
        public IdConverter()
            : base(
                v => v.Uuid,
                v => new Identification(v))
        {
        }
    }
}

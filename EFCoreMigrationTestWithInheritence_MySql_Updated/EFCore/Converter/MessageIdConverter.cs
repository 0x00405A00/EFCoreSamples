using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.EFCore.Converter
{
    public class MessageIdConverter : ValueConverter<MessageId, Guid>
    {
        public MessageIdConverter()
            : base(
                v => v.Id,
                v => new MessageId(v))
        {
        }
    }
}

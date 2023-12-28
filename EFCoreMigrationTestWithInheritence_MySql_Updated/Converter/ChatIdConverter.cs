using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.ValueObjects.Ids;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated.Converter
{
    public class ChatIdConverter : ValueConverter<ChatId, Guid>
    {
        public ChatIdConverter()
            : base(
                v => v.Uuid,
                v => new ChatId(v))
        {
        }
    }
}

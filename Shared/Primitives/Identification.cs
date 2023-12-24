namespace Shared.Primitives
{

    public record Identification(Guid Uuid) : IEquatable<Identification>
    {
        public static Identification Create() => new Identification(Guid.NewGuid());
        public override string ToString()
        {
            return Uuid.ToString();
        }

        public override int GetHashCode()
        {
            return Uuid.GetHashCode() * 41;
        }
    }
}

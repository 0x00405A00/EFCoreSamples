namespace Shared.Primitives
{

    public record Identification(Guid Id) : IEquatable<Identification>
    {
        public static Identification Create() => new Identification(Guid.NewGuid());
        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }
    }
}

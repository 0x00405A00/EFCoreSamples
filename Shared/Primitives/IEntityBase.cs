namespace Shared.Primitives
{
    public interface IEntityBase
    {
        CustomDateTime CreatedTime { get; set; }
        CustomDateTime? DeletedTime { get; set; }
        CustomDateTime? LastModifiedTime { get; set; }
    }
}
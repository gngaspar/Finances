namespace Finances.Contract
{
    public interface IListOrder<T>
    {
        T Field { get; set; }

        bool IsDesc { get; set; }
    }
}
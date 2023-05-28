namespace ManageBooking.Intefaces
{
    public interface IRepo<K, T>
    {
        T Add(T item);
        T Update(T item);
        ICollection<T> GetAll();
        T Delete(K Key);
        T Get(K Key);
    }
}

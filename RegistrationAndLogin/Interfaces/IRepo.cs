namespace RegistrationAndLogin.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IRepo<K, T> : IBaseRepo<K, T>
    {
        T Update(T item);
        T Delete(K key);
        ICollection<T> GetAll();
    }
}

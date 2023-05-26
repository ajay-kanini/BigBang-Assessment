namespace RegistrationAndLogin.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepo<K, T>
    {

        T Add(T item);
        T Get(K key);
    }
}

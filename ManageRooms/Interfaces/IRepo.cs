namespace ManageRooms.Interfaces
{
    public interface IRepo<K,T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Add(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        
        T Update(T item);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetAll();
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Key"></param>
       /// <returns></returns>
        T Delete(K Key);
       
        /// <summary>
       /// 
       /// </summary>
       /// <param name="Key"></param>
       /// <returns></returns>
        T Get(K Key);
    }
}

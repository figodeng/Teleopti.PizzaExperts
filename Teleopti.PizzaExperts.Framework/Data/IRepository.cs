using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Data
{
    /// <summary>
    /// IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: BaseRecord
    {
        /// <summary>
        /// Create Data
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(string id);

        /// <summary>
        /// Get All Datas
        /// </summary>
        IEnumerable<T> Table { get; }
        
    }
}

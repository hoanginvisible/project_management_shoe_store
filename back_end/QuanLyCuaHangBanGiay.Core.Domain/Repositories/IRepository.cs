using System.ComponentModel.DataAnnotations;
using Dapper;

namespace QuanLyCuaHangBanGiay.Core.Domain.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Find an object using its Unique Identifier
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <returns></returns>
        Task<T?> FindByIdAsync(string sql, DynamicParameters dynamicParameters);

        /// <summary>
        /// Filter a list with given parameter
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> Filter(string sql, DynamicParameters dynamicParameters);

        /// <summary>
        /// Set Parameter with DTO object properties
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        DynamicParameters SetParameters(object parameter);

        /// <summary>
        /// Run Validator throws exception when fails validation
        /// </summary>
        /// <typeparam name="ValidatingObject"></typeparam>
        /// <param name="queryQueries"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="validationResults"></param>
        /// <returns></returns>
        Task RunValidator<ValidatingObject>(
            string queryQueue,
            DynamicParameters dynamicParameters,
            List<ValidationResult> validationResults
        );
    }
}


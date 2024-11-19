using Newtonsoft.Json;
using SharedLibrary.DTOs;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using System.Data.Common;
using Microsoft.Extensions.Primitives;


namespace SharedLibrary.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.Records)
                .Take(pagination.Records);
        }




        public static IQueryable<T> GetFilteredDataAsync<T>(this IQueryable<T> queryable, string jsonString)
        {
            var filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            // Recorre los filtros y crea condiciones dinámicas
            foreach (var filter in filters)
            {
                var propertyName = filter.Key;
                var propertyValue = filter.Value;
                // Construye la expresión de filtro
                queryable = queryable.ApplyDynamicFilter(propertyName, propertyValue);
            }

            return queryable;
        }

        /// <summary>
        /// Crea un método genérico para aplicar el filtro dinámico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        private static IQueryable<T> ApplyDynamicFilter<T>(this IQueryable<T> query, string propertyName, object propertyValue)
        {
            // Obtén el tipo de la entidad
            var parameter = Expression.Parameter(typeof(T), "e");

            // Crea la expresión para la propiedad: e.PropertyName
            var property = Expression.Property(parameter, propertyName);

            if (property.Type == typeof(Int32)) {
                return query.FilterEqual(property, propertyValue, parameter);
            }

            if (property.Type == typeof(string))
            {
                return query.FilterLike(property, parameter, propertyValue.ToString() ?? "");
            }

             return query;
        }


        private static IQueryable<T> FilterEqual<T>(this IQueryable<T> query, MemberExpression property, object propertyValue, ParameterExpression parameter)
        {

            // Crea la expresión para el valor del filtro
            var constant = Expression.Constant(Convert.ToInt32(propertyValue));

            // Crea la comparación e.PropertyName == propertyValue
            var equalExpression = Expression.Equal(property, constant);

            // Crea el lambda: e => e.PropertyName == propertyValue
            var lambda = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);

            // Aplica el filtro a la consulta
            return query.Where(lambda);

        }

        private static IQueryable<T> FilterLike<T>(this IQueryable<T> query, MemberExpression property, ParameterExpression parameter, string stringValue)
        {

            // Aquí aplicamos un "LIKE" que sería similar a SQL "%valor%"
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            var likeExpression = Expression.Call(property, method, Expression.Constant(stringValue));

            // Crea el lambda: e => e.PropertyName LIKE propertyValue
            var lambda = Expression.Lambda<Func<T, bool>>(likeExpression, parameter);

            // Aplica el filtro a la consulta
            return query.Where(lambda);

        }


    }
}

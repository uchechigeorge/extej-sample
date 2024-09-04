using System.Linq.Expressions;

namespace MVCWebApplication1.Helpers;

public static partial class OrderHelperExtensions
{

  /// <summary>
  /// Custom expression
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="source"></param>
  /// <param name="propertyName"></param>
  /// <param name="descending"></param>
  /// <param name="anotherLevel"></param>
  /// <returns></returns>
  private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
  {
    ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
    MemberExpression property = Expression.PropertyOrField(param, propertyName);
    LambdaExpression sort = Expression.Lambda(property, param);
    MethodCallExpression call = Expression.Call(
        typeof(Queryable),
        (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
        [typeof(T), property.Type],
        source.Expression,
        Expression.Quote(sort));
    return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
  }

  /// <summary>
  /// Sorts the elements of a sequence in a specified order according to a specified key string.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="source">The sequence to sort</param>
  /// <param name="propertyName">String representation of the property to perform the sort query on</param>
  /// <param name="descending">Flag to determine if to sort elements in descending order</param>
  /// <returns></returns>
  public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool descending)
  {
    return OrderingHelper(source, propertyName, descending, false);
  }

}

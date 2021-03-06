using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    static public class EnumerableExtensions
    {
        static public void each<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items) visitor(item);
        }

        static public IEnumerable<Output> map_all<Input,Output>(this IEnumerable<Input> items, Mapper<Input,Output> mapper)
        {
            return items.Select(input => mapper.map(input));
        }
    }
}
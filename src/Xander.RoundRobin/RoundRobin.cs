using System.Collections.Generic;
using System.Linq;

namespace Xander.RoundRobin
{
    public class RoundRobin<T>
    {
        private readonly T[] _items;

        private int _currentIndex = -1;

        public RoundRobin(IEnumerable<T> items)
        {
            _items = items.ToArray();
        }

        public T GetNextItem()
        {
            if (_items.Length == 0)
                return default(T);

            _currentIndex++;
            if (_currentIndex >= _items.Length)
                _currentIndex = 0;
            return _items[_currentIndex];
        }
    }
}
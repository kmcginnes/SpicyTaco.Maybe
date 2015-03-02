using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maybe
{
    public static class Maybe
    {
        public static Maybe<T> Empty<T>() where T : class
        {
            return Maybe<T>.Empty;
        }

        public static Maybe<T> Create<T>(T value) where T : class
        {
            return Maybe<T>.Create(value);
        }
    }

    public class Maybe<T> where T : class
    {
        public static Maybe<T> Empty = new Maybe<T>();

        public static Maybe<T> Create<T>(T value) where T : class
        {
            return new Maybe<T>(value);
        }

        Maybe() { }

        Maybe(T value)
        {
            _value = value;
        }

        readonly T _value;
        public T Value
        {
            get
            {
                if (_value == null)
                {
                    throw new InvalidOperationException("Value was null. Check HasValue before accessing Value.");
                }
                return _value;
            }
        }

        public bool HasValue {get { return _value != null; } }
    }
}

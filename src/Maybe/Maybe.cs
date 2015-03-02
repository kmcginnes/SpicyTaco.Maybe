using System;
using System.Collections.Generic;

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

        public static Maybe<T> ToMaybe<T>(this T value) where T : class
        {
            return Maybe<T>.Create(value);
        }
    }

    public class Maybe<T> : IEquatable<Maybe<T>> where T : class
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

        public bool Equals(Maybe<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Maybe<T>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(_value);
        }

        public static bool operator ==(Maybe<T> left, Maybe<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Maybe<T> left, Maybe<T> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var typeName = typeof (T).Name;
            return HasValue 
                ? Value.ToString()
                : String.Format("Maybe<{0}> has no value", typeName);
        }

        public static implicit operator Maybe<T>(T value)
        {
            return Create(value);
        }

        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
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

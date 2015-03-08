using System;

namespace SpicyTaco
{
    public sealed class Nothing<T> : Maybe<T>, IEquatable<Nothing<T>>
    {
        public static readonly Maybe<T> Instance = new Nothing<T>();
        readonly Lazy<string> _toString;

        Nothing()
        {
            _toString = new Lazy<String>(() => String.Format("Maybe<{0}> is empty", typeof(T).Name));
        }

        public bool Equals(Nothing<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_toString, other._toString);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Nothing<T>) obj);
        }

        public override int GetHashCode()
        {
            return (_toString != null ? _toString.GetHashCode() : 0);
        }

        public static bool operator ==(Nothing<T> left, Nothing<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Nothing<T> left, Nothing<T> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return _toString.Value;
        }
    }
}

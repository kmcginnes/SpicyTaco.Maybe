using System;
using System.Collections.Generic;

namespace SpicyTaco.Maybe
{
    public class Just<T> : Maybe<T>, IEquatable<Just<T>>
    {
        readonly T _value;
        public T Value { get { return _value; } }

        public Just(T value)
        {
            _value = value;
        }

        public bool Equals(Just<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(this.Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Just<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(Just<T> left, Just<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Just<T> left, Just<T> right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
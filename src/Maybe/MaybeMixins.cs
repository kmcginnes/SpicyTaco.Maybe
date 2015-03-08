using System;
using System.Collections.Generic;

namespace SpicyTaco
{
    public static class MaybeMixins
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T))
                ? (Maybe<T>) Nothing<T>.Instance
                : (Maybe<T>) Just<T>.FromValue(value);
        }

        public static Maybe<TRet> Bind<T, TRet>(this Maybe<T> maybe, Func<T, Maybe<TRet>> bindFunc)
        {
            var just = maybe as Just<T>;
            return just == null
                ? Nothing<TRet>.Instance
                : bindFunc(just.Value);
        }

        public static Maybe<TRet> Select<T, TRet>(this Maybe<T> maybe, Func<T, TRet> selector)
        {
            var just = maybe as Just<T>;
            return just == null
                ? Nothing<TRet>.Instance
                : selector(just.Value).ToMaybe();
        }

        public static Maybe<C> SelectMany<A, B, C>(this Maybe<A> a, Func<A, Maybe<B>> func, Func<A, B, C> select)
        {
            return a.Bind(
                outer => func(outer).Bind(
                    inner => select(outer, inner).ToMaybe()));
        }

        public static Maybe<T> Do<T>(this Maybe<T> maybe, Action<T> action)
        {
            var just = maybe as Just<T>;
            if (just != null)
                action(just.Value);
            return maybe;
        }

        public static Maybe<T> DoWhenEmpty<T>(this Maybe<T> maybe, Action action)
        {
            var nothing = maybe as Nothing<T>;
            if (nothing != null)
                action();
            return maybe;
        }
    }
}
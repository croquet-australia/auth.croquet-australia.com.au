using System;

namespace CroquetAustralia.Auth.Specifications.Helpers
{
    public static class Extensions
    {
        /// <summary>
        ///     If <paramref name="exception" /> is an AggregateException with only one inner exception then
        ///     return the inner exception otherwise return the exception this method was passed.
        /// </summary>
        public static Exception UnwrapException(this Exception exception)
        {
            var aggregateException = exception as AggregateException;
            var unwrapedException = aggregateException?.InnerExceptions.Count == 1 ? aggregateException.InnerException : exception;

            return unwrapedException;
        }
    }
}
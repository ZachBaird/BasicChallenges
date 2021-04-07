namespace Challenges.Library
{
    /// <summary>
    /// Custom Result type.
    /// </summary>
    /// <typeparam name="TSuccess">The type for Success.</typeparam>
    /// <typeparam name="TFailure">The type for Failure.</typeparam>
    public abstract class Result<TSuccess, TFailure>
    {
        private Result() { }

        /// <summary>
        /// The Success condition storing a resulting value.
        /// </summary>
        public sealed class Success : Result<TSuccess, TFailure>
        {
            public TSuccess Value { get; }

            public Success(TSuccess value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// The Failure condition storing an error message.
        /// </summary>
        public sealed class Failure : Result<TSuccess, TFailure>
        {
            public TFailure Message { get; }

            public Failure(TFailure message)
            {
                Message = message;
            }
        }
    }
}

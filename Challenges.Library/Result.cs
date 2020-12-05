namespace Challenges.Library
{
    public abstract class Result<TSuccess, TFailure>
    {
        private Result() { }

        public sealed class Success : Result<TSuccess, TFailure>
        {
            public TSuccess Value { get; }

            public Success(TSuccess value)
            {
                Value = value;
            }
        }

        public sealed class Failure : Result<TSuccess, TFailure>
        {
            public TFailure Value { get; }

            public Failure(TFailure value)
            {
                Value = value;
            }
        }
    }
}

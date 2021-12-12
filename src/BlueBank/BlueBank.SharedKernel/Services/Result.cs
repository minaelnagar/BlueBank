namespace BlueBank.SharedKernel.Services
{
    public class Result<T>
    {
        private Result() { }

        public static Result<T> Success()
        {
            return new Result<T>()
            {
            };
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>()
            {
                Value = value
            };
        }

        public static Result<T> Fail()
        {
            return new Result<T>()
            {
                DidFail = true
            };
        }

        public static Result<T> Fail(BusinessError error)
        {
            return new Result<T>()
            {
                DidFail = true,
                Error = error
            };
        }

        public bool DidFail { get; private set; }
        public BusinessError Error { get; private set; }
        public T Value { get; private set; }
    }
}

namespace BlueBank.SharedKernel.Services
{
    public class Result<T>
    {
        public Result(T value)
        {
            Value = value;
            DidFail = false;
        }

        public Result(BusinessError error)
        {
            Error = error;
            DidFail = true;
        }

        public bool DidFail { get; private set; }
        public BusinessError Error { get; private set; }
        public T Value { get; private set; }
    }
}

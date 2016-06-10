
namespace PingYourPackage.Domain.Services
{
    public class OperationResult
    {
        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; private set; }
    }

    public class OperationResult<TEntity> : OperationResult
    {
        public OperationResult(bool isSucccess) : base(isSucccess)
        {

        }

        public TEntity Entity { get; set; }
    }
}

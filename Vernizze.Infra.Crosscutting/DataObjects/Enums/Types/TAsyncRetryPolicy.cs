namespace Vernizze.Infra.Crosscutting.DataObjects.Enums.Types
{
    public enum TAsyncRetryPolicy
    {
        Undefined = 0,
        DontRetry = 1,
        RetryOnce = 2,
        RetryTwice = 3,
        RetryForEver = 4,

    }
}

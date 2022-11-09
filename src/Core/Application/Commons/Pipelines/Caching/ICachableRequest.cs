namespace Application.Commons.Pipelines.Caching;

public interface ICachableRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}
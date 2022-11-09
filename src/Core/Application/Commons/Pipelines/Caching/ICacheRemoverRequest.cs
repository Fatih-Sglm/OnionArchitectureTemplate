namespace Application.Commons.Pipelines.Caching;

public interface ICacheRemoverRequest
{
    bool BypassCache { get; }
    string CacheKey { get; }
}
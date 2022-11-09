namespace Application.Commons.Pipelines.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}
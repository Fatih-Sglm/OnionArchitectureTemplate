using CrossCuttingConcerns.Exceptions;

namespace Application.Abstractions.Rules
{
    public abstract class BaseBusinessRules
    {
        public virtual Task CannotBeNull<T>(T item)
        {
            if (item is null)
                throw new NotFoundException($"{nameof(T)} is not found");
            return Task.CompletedTask;
        }
        //public abstract Task CanNotDuplicate(string name);
    }
}

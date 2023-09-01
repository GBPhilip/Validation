namespace Validation
{
    internal class ExistsValidator : IValidator
    {
        private readonly IRepository repository;

        public ExistsValidator(IRepository repository)
        {
            this.repository = repository;
        }
        public string? IsValid(PersonScore personScore)
        {
            ArgumentNullException.ThrowIfNull(nameof(personScore));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Id));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Score));
            return repository.DoesIdExist(personScore.Id)? $"{personScore.Id} already exists" : null;
        }
    }
}

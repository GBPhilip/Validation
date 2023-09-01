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
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            return repository.DoesIdExist(personScore.Id)? $"{personScore.Id} already exists" : null;
        }



        public async Task<string?> IsValidAsync(PersonScore personScore)
        {
            await Task.Delay(1000);
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            await Task.Delay(1000);
            return await repository.DoesIdExistAsync(personScore.Id) ? $"{personScore.Id} already exists" : null;
        }
    }
}

namespace Validation
{
    internal class MinValidator : IValidator
    {
        public string? IsValid(PersonScore personScore)
        {
            ArgumentNullException.ThrowIfNull(nameof(personScore));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Id));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Score));
            if (personScore.Score < 0) return "Score is too low for person {personScore.Id}";
            return null;
        }

        public Task<string?> IsValidAsync(PersonScore personScore)
        {
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            if (personScore.Score < 0) return Task.FromResult((string?)"Score is too low for person {personScore.Id}");
            return Task.FromResult((string?)null);
        }
    }
}

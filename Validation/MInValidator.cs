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
    }
}

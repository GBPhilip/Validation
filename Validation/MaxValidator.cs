namespace Validation
{
    internal class MaxValidator : IValidator
    {
        public string? IsValid(PersonScore personScore)
        {
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            if (personScore.Score > 100) return "Score is too high for person {personScore.Id}";
            return null;
        }
    }
}

namespace Validation
{
    internal class MaxValidator : IAsync
    {
        public string? IsValid(PersonScore personScore)
        {
            Console.WriteLine("MaxValidator");
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            if (personScore.Score > 100) return "Score is too high for person {personScore.Id}";
            return null;
        }

        public async Task<string?> IsValidAsync(PersonScore personScore)
        {
            Console.WriteLine("MaxValidatorAsync");
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            if (personScore.Score > 100) return (string?)"Score is too high for person {personScore.Id}";
            return (string?)null;
        }
    }
}

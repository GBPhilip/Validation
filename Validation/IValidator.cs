namespace Validation
{
    internal interface IValidator
    {
        public string? IsValid(PersonScore personScore);

        public Task<string?> IsValidAsync(PersonScore personScore);
    }
}

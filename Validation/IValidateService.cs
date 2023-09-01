namespace Validation
{
    internal interface IValidateService
    {
        List<string> ValidateAll(PersonScore personScore);
        Task<List<string>> ValidateAllAsync(PersonScore personScore);
    }
}

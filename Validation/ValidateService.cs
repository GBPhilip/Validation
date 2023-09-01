namespace Validation
{
    internal class ValidateService :IValidateService
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidateService(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public List<string> ValidateAll(PersonScore personScore)
        {
            List<string> errors = new();
            foreach (var validator in _validators)
            {
                try
                {
                    string? error = validator.IsValid(personScore);
                    if (error is not null) errors.Add(error);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);    
                }      
            }
            return errors;
        }
    }
}

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
                string? error= null;
                try
                {
                    error = validator.IsValid(personScore);

                }
                catch (Exception ex)
                {
                    errors.Add($"Unable to validate - {validator.GetType()} {ex.Message}");
                }               
                if (error is not null) errors.Add(error);
            }
            return errors;
        }


        public async Task<List<string>> ValidateAllAsync(PersonScore personScore)
        {
            List<string> errors = new();
            foreach (var validator in _validators)
            {
                string? error = null;
                try
                {
                    error = await validator.IsValidAsync(personScore);

                }
                
                catch (Exception ex) 
                {
                    errors.Add($"Unable to validate - {validator.GetType()} {ex.Message}");
                }
                if (error is not null) errors.Add(error);
            }
            return errors;
        }

    }
}

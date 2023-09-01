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
            List<string?> errors = new();
            List<Task<string?>> tasks = new();
            try
            {
                foreach (var validator in _validators)
                {
                    tasks.Add(validator.IsValidAsync(personScore));
                }

                errors.AddRange(await Task.WhenAll(tasks));
            }
            catch (Exception ex)
            {
                var exceptions = tasks.Where(t => t.Exception != null)
                    .Select(t => t.Exception).ToList();
                foreach (var ae in exceptions)
                {
                    ae.Handle(e =>
                    {
                        errors.Add(e.Message);
                        return true;
                    });
                }
            }

            return errors.Where(x => x != null).ToList();
        }

    }
}

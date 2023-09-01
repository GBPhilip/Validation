﻿namespace Validation
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
            Console.WriteLine("Exists");
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            return repository.DoesIdExist(personScore.Id)? $"{personScore.Id} already exists" : null;
        }



        public async Task<string?> IsValidAsync(PersonScore personScore)
        {
            Console.WriteLine("ExistsAsync");
            ArgumentNullException.ThrowIfNull(personScore);
            ArgumentNullException.ThrowIfNull(personScore.Id);
            ArgumentNullException.ThrowIfNull(personScore.Score);
            return await repository.DoesIdExistAsync(personScore.Id) ? $"{personScore.Id} already exists" : null;
        }
    }
}

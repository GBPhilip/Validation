using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    internal class MaxValidator : IValidator
    {
        public string? IsValid(PersonScore personScore)
        {
            ArgumentNullException.ThrowIfNull(nameof(personScore));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Id));
            ArgumentNullException.ThrowIfNull(nameof(personScore.Score));
            if (personScore.Score > 100) return "Score is too high for person {personScore.Id}";
            return null;
        }
    }
}

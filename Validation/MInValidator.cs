using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    internal class MInValidator : IValidator
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

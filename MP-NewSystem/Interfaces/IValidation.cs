using MP_NewSystem.Models;

namespace MP_NewSystem.Interfaces
{
    public interface IValidation
    {
        CustomValidationResult CheckUserParameters(string[] args);
        void SeedParams();
    }
}

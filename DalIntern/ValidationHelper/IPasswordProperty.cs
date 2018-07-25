using Microsoft.AspNet.Identity;


namespace DalIntern.ValidationHelper
{
    interface IPasswordProperty : IIdentityValidator<string>
    {
        string GetPassword { get; set; }

        bool isValid { get; set; }
    }
}

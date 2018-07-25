using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{
    public class RequireNonLetterorDigitValidator : IValidatorNode
    {
        private IValidatorNode nextValidator { get; set; }

        public IValidatorNode SetNextNode(IValidatorNode node)
        {
            this.nextValidator = node;
            return node;
        }

        public bool Validate(PasswordProperty property)
        {
            try
            {
                if (hasNonLetterOrDigit(property.GetPassword))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors("Password must have a non letter or digit.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool hasNonLetterOrDigit(string passwordItem)
        {
            return passwordItem.Any(x => !char.IsLetterOrDigit(x));
        }

    }
}
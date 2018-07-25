using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{
    public class RequireLowerCaseValidator : IValidatorNode
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
                if (hasLowerCase(property.GetPassword))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors("Password must have lower case letter.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool hasLowerCase(string passwordItem)
        {
            return passwordItem.Any(x => char.IsLower(x));
        }

    }
}
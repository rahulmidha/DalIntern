
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{
    public class RequireUpperCaseValidator : IValidatorNode
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
                if (hasUpperCase(property.GetPassword))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors("Password must have an upper case letter.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool hasUpperCase(string passwordItem)
        {
            return passwordItem.Any(x => char.IsUpper(x));
        }

    }
}
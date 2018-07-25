using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{ 

    public class RequirePassword : IValidatorNode
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
                if (!string.IsNullOrWhiteSpace(property.GetPassword))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors("Password is required.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
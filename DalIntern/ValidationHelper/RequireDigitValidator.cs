﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{
    public class RequireDigitValidator : IValidatorNode
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
                if (hasDigits(property.GetPassword))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors("Password requires digit.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool hasDigits(string passwordItem)
        {
            return passwordItem.Any(x => char.IsDigit(x));
        }

    }
}
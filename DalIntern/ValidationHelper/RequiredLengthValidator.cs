///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Mathew Zimola                  Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Mathew Zimola                 25-July-2018       Class Created
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalIntern.ValidationHelper
{
    public class RequiredLengthValidator : IValidatorNode
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
                if (hasrequiredLength(property))
                    return nextValidator != null ? nextValidator.Validate(property) : true;
                else
                {
                    property.AddErrors( string.Format("Password must have required length of {0}",property.RequiredLength));
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool hasrequiredLength(PasswordProperty passwordItem)
        {
            return passwordItem.GetPassword.Length > passwordItem.RequiredLength;
        }

    }
}
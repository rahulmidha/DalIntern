///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Nishanth Antony Satler       Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Nishanth Antony Satler        25-July-2018       Class Created
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DalIntern.ValidationHelper
{
    public class PasswordProperty :IPasswordProperty
    {

        private string _password;
        private bool _IsValid;

        public string GetPassword
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public bool isValid
        {
            get
            {
                return _IsValid;
            }
            set
            {
                _IsValid = value;
            }
        }

        public List<string> errors = new List<string>();

        //
        // Summary:
        //     Require a digit ('0' - '9')
        public bool RequireDigit { get; set; }
        //
        // Summary:
        //     Minimum required length
        public int RequiredLength { get; set; }
        //
        // Summary:
        //     Require a lower case letter ('a' - 'z')
        public bool RequireLowercase { get; set; }
        //
        // Summary:
        //     Require a non letter or digit character
        public bool RequireNonLetterOrDigit { get; set; }
        //
        // Summary:
        //     Require an upper case letter ('A' - 'Z')
        public bool RequireUppercase { get; set; }


        public Task<IdentityResult> ValidateAsync(string item)
        {
            _password = item;
            try
            {
                // Setup Chain of Responsibiity
                IValidatorNode passwordValidator = SetupValidatorSequence();
                if(!passwordValidator.Validate(this))
                {
                    return Task.FromResult<IdentityResult>(IdentityResult.Failed(errors.ToArray()));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult<IdentityResult>(IdentityResult.Success);
        }

        public IValidatorNode SetupValidatorSequence()
        {
            IValidatorNode rootNode = null;
            try
            {
                IValidatorNode node = new RequirePassword();
                rootNode = node;
                if(RequireLowercase)
                {
                    node = node.SetNextNode(new RequireLowerCaseValidator());
                }
                if(RequireDigit)
                {
                    node = node.SetNextNode(new RequireDigitValidator());
                }
                if(RequiredLength>0)
                {
                    node = node.SetNextNode(new RequiredLengthValidator());
                }
                if(RequireNonLetterOrDigit)
                {
                    node = node.SetNextNode(new RequireNonLetterorDigitValidator());
                }
                if(RequireLowercase)
                {
                    node = node.SetNextNode(new RequireLowerCaseValidator());
                }
                if(RequireUppercase)
                {
                    node = node.SetNextNode(new RequireUpperCaseValidator());
                }
                return rootNode;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddErrors(string error)
        {
            errors.Add(error);
        }

    }
}
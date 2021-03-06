﻿///-----------------------------------------------------------------
///   Namespace:      DalIntern
///   Class:          <Class Name>
///   Description:    <Description>
///   Author:         Rahul Midha                Date: 25-July-2018
///   Notes:          
///   Revision History:
///   Name:                         Date:              Description:
///   Rahul Midha                   25-July-2018       Class Created
///-----------------------------------------------------------------
using Microsoft.AspNet.Identity;


namespace DalIntern.ValidationHelper
{
    interface IPasswordProperty : IIdentityValidator<string>
    {
        string GetPassword { get; set; }

        bool isValid { get; set; }
    }
}

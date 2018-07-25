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
namespace DalIntern.ValidationHelper
{
   public interface IValidatorNode
    {
        IValidatorNode SetNextNode(IValidatorNode node);
        bool Validate(PasswordProperty property);
    }
}

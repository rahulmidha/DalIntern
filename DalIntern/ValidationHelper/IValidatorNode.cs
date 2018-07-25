
namespace DalIntern.ValidationHelper
{
   public interface IValidatorNode
    {
        IValidatorNode SetNextNode(IValidatorNode node);
        bool Validate(PasswordProperty property);
    }
}

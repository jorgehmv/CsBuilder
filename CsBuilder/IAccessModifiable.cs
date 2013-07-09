using CsBuilder.Elements;

namespace CsBuilder
{
    public interface IAccessModifiable
    {
        AccessModifier AccessModifier { get; set; }
    }
}
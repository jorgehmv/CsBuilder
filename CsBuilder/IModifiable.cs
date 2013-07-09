using CsBuilder.Elements;

namespace CsBuilder
{
    public interface IModifiable
    {
        Modifier Modifier { get; set; }
    }
}
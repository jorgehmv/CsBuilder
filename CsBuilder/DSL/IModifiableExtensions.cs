using CsBuilder.Elements;

namespace CsBuilder.DSL
{
    public static class IModifiableExtensions
    {
        public static T Virtual<T>(this T modifiable) where T : IModifiable
        {
            modifiable.Modifier = Modifier.Virtual;
            return modifiable;
        }

        public static T Override<T>(this T modifiable) where T : IModifiable
        {
            modifiable.Modifier = Modifier.Override;
            return modifiable;
        }

        public static T OverrideIf<T>(this T modifiable, bool doOverride) where T : IModifiable
        {
            modifiable.Modifier = doOverride ? Modifier.Override : Modifier.Virtual;
            return modifiable;
        }
    }
}
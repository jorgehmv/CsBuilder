using CsBuilder.Elements;

namespace CsBuilder.DSL
{
    public static class IAccessModifiableExtensions
    {
        public static T Public<T>(this T accessModifiable) where T : IAccessModifiable
        {
            accessModifiable.AccessModifier = AccessModifier.Public;
            return accessModifiable;
        }

        public static T Private<T>(this T accessModifiable) where T : IAccessModifiable
        {
            accessModifiable.AccessModifier = AccessModifier.Private;
            return accessModifiable;
        }

        public static T Protected<T>(this T accessModifiable) where T : IAccessModifiable
        {
            accessModifiable.AccessModifier = AccessModifier.Protected;
            return accessModifiable;
        }

        public static T ProtectedInternal<T>(this T accessModifiable) where T : IAccessModifiable
        {
            accessModifiable.AccessModifier = AccessModifier.ProtectedInternal;
            return accessModifiable;
        }
    }
}
#region [ using ]

using System.Linq;
using System.Collections.Generic;
using CsBuilder.Elements;
using CsBuilder.Formatters;
using CsBuilder.Types;
using CsBuilder.Utils;
using CsBuilder.Comments;

#endregion

namespace CsBuilder.Statements
{
    public class ClassStatement : Statement, IAccessModifiable, IAttributable
    {
        private readonly IList<AttributeStatement> attributes;
        private readonly BlockStatement body;
        private readonly NameElement name;
        private readonly IList<CsType> interfaces;

        public ClassStatement(string name)
        {
            AccessModifier = AccessModifier.Public;
            ClassModifier = ClassModifier.Empty;

            this.name = new NameElement(name);
            body = new BlockStatement();
            attributes = new List<AttributeStatement>();
            CsType = new CustomType(name);
            interfaces = new List<CsType>();
        }

        public ClassModifier ClassModifier { get; set; }

        public CsType CsType { get; protected set; }

        public CsType Base { get; set; }

        public void AddInterface(CsType type)
        {
            interfaces.Add(type);
        }

        #region IAccessModifiable Members

        public AccessModifier AccessModifier { get; set; }

        #endregion

        #region IAttributable Members

        public void AddAttribute(AttributeStatement attributeStatement)
        {
            attributes.Add(attributeStatement);
        }

        public IEnumerable<AttributeStatement> Attributes
        {
            get { return attributes; }
        }

        #endregion

        public void AddMethod(MethodStatement methodStatement)
        {
            body.AddStatement(methodStatement);
        }

        public void AddProperty(PropertyStatement propertyStatement)
        {
            body.AddStatement(propertyStatement);
        }

        public void AddField(FieldStatement fieldStatement)
        {
            body.AddStatement(fieldStatement);
        }

        public void AddConstructor(ConstructorStatement constructorStatement)
        {
            body.AddStatement(constructorStatement);
        }

        public void AddNestedClass(ClassStatement classStatement)
        {
            body.AddStatement(classStatement);
        }

        // TODO: refactor
        public override void Render(ICodeWriter renderer)
        {
            if (attributes.Count > 0)
            {
                renderer.Write("{0} ", attributes.First());
                renderer.WriteLine("");
                foreach (AttributeStatement attribute in attributes.Skip(1))
                {
                    renderer.WriteLine("{0} ", attribute);
                }
                if (Base != null)
                {
                    if (interfaces.Count > 0)
                    {
                        renderer.Write("{0} {1} class {2} : {3}", AccessModifier, ClassModifier, name, Base);
                        renderer.WriteLine(string.Format(", {0}", CodeUtils.Placeholders(interfaces.Count)), interfaces.ToArray());
                    }
                    else
                    {
                        renderer.WriteLine("{0} {1} class {2} : {3}", AccessModifier, ClassModifier, name, Base);
                    }
                }
                else
                {
                    if (interfaces.Count > 0)
                    {
                        renderer.Write("{0} {1} class {2}", AccessModifier, ClassModifier, name);
                        renderer.WriteLine(string.Format(" : {0}", CodeUtils.Placeholders(interfaces.Count)), interfaces.ToArray());
                    }
                    else
                    {
                        renderer.WriteLine("{0} {1} class {2}", AccessModifier, ClassModifier, name);
                    }
                }
            }
            else
            {
                renderer.Write("{0} {1} class {2}", AccessModifier, ClassModifier, name);

                if (Base != null)
                {
                    renderer.Write(" : {0}", Base);
                    if (interfaces.Count > 0)
                    {
                        renderer.Write(string.Format(", {0}", CodeUtils.Placeholders(interfaces.Count)), interfaces.ToArray());
                    }
                }
                else if (interfaces.Count > 0)
                {
                    renderer.Write(string.Format(" : {0}", CodeUtils.Placeholders(interfaces.Count)), interfaces.ToArray());
                }
            }

            renderer.Write("{0}", body);
        }

    }
}
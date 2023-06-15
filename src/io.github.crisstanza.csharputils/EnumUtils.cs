using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace io.github.crisstanza.csharputils
{
    public class EnumUtils
    {
        public string GetMemberValue(Type type, string name)
        {
            MemberInfo[] memberInfos = type.GetMember(name);
            if (memberInfos.Length == 0)
            {
                return null;
            }
            IList<CustomAttributeNamedArgument> namedArguments = memberInfos[0].CustomAttributes.FirstOrDefault().NamedArguments;
            if (namedArguments.Count == 0)
            {
                return null;
            }
            return namedArguments[0].TypedValue.Value.ToString();
        }
    }
}

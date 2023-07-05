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
            IEnumerable<CustomAttributeData> memberInfoCustomAttributes = memberInfos[0].CustomAttributes;
            CustomAttributeData memberInfoCustomAttribute = memberInfoCustomAttributes.FirstOrDefault();
            if (memberInfoCustomAttribute == null)
            {
                return null;
            }
            IList<CustomAttributeNamedArgument> memberInfoCustomAttributeNamedArguments = memberInfoCustomAttribute.NamedArguments;
            if (memberInfoCustomAttributeNamedArguments.Count == 0)
            {
                return null;
            }
            CustomAttributeNamedArgument memberInfoCustomAttributeNamedArgument = memberInfoCustomAttributeNamedArguments[0];
            return memberInfoCustomAttributeNamedArgument.TypedValue.Value.ToString();
        }
    }
}

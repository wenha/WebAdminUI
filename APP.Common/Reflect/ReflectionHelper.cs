using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.Reflect
{
    public static class ReflectionHelper
    {
        public static List<object> GetAttributesOfMemberAndDeclaringType(MemberInfo memberInfo, bool inherit = true)
        {
            var attributeList = new List<object>();

            attributeList.AddRange(memberInfo.GetCustomAttributes(inherit));

            if(memberInfo.DeclaringType != null)
            {
                attributeList.AddRange(memberInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(inherit));
            }

            return attributeList;
        }
    }
}

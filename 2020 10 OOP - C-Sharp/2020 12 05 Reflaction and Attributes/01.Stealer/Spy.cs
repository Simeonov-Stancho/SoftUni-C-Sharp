using System;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsFOrInvestigate)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Static
                                            | BindingFlags.Instance
                                            | BindingFlags.Public
                                            | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            Object classForInvestigate = Activator.CreateInstance(type, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields.Where(f => fieldsFOrInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classForInvestigate)}");
            }

            return sb.ToString().Trim();
        }
    }
}
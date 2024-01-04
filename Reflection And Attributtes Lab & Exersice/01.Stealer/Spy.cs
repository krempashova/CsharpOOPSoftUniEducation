namespace Stealer
{
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            var classType = Type.GetType($"Stealer.{investigatedClass}");

            var fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => requestedFields.Contains(x.Name));

            var classInstance = Activator.CreateInstance(classType);

            var fieldsInfo = new StringBuilder();

            fieldsInfo.AppendLine($"Class under investigation: Stealer.{investigatedClass}");

            foreach (var field in fields)
            {
                fieldsInfo.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return fieldsInfo.ToString().TrimEnd();
        }
    }
}

using System.Text;
using System.Reflection;
using WaniKaniService;

WaniKaniClient client;
string type;

// get input
try
{
    client = new WaniKaniClient(args[0]);
    type = args[1];
}
catch (Exception)
{
    throw;
}

// string to response
object response = type switch
{
    "user" => client.UserClient.GetAsync().Result,
    _ => throw new Exception("Data type not valid.")
};

// write the response
Console.WriteLine(PropertiesToString(response));

string PropertiesToString(object obj, string tab = "")
{
    StringBuilder sb = new StringBuilder();

    PropertyInfo[] properties = obj.GetType().GetProperties();
    foreach (PropertyInfo pInfo in properties)
    {
        object? p = pInfo.GetValue(obj, null);

        if (p is null)
            continue;

        sb.AppendLine($"{tab}{pInfo.Name}: {p}");

        if (p.GetType().FullName!.Contains("WaniKaniService.Models"))
            sb.AppendLine(PropertiesToString(p, tab + "    "));
    }

    return sb.ToString();
}
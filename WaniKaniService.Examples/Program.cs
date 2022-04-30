﻿using System.Collections;
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

// set encoding to support Japanese characters
Console.OutputEncoding = Encoding.UTF8;

// string to response
object response;

switch (type)
{
    case "user":
        response = client.UserClient.GetAsync().Result;
        break;

    case "subject":
        try
        {
            int id = Convert.ToInt32(args[2]);
            response = client.SubjectsClient.GetAsync(id).Result;
        }
        catch (Exception)
        {
            throw;
        }
        break;

    default:
        throw new Exception("Data type not valid.");
}

// write the response
Console.WriteLine(response);
Console.WriteLine(PropertiesToString(response));

string PropertiesToString(object obj, string tab = "")
{
    // if it is primitive, it has no properties
    if (obj.GetType().IsPrimitive)
        return $"{tab}{obj.GetType().Name}: {obj?.ToString()!}";

    StringBuilder sb = new StringBuilder();

    PropertyInfo[] properties = obj.GetType().GetProperties();
    foreach (PropertyInfo pInfo in properties)
    {
        object? p = pInfo.GetValue(obj);

        if (p is null)
            continue;

        sb.AppendLine($"{tab}{pInfo.Name}: {p}");

        if (p is IList pIList)
            foreach (object item in pIList)
                sb.AppendLine(PropertiesToString(item, tab + "    "));
        else if (p.GetType().FullName!.Contains("WaniKaniService.Models"))
            sb.AppendLine(PropertiesToString(p, tab + "    "));
    }

    return sb.ToString();
}
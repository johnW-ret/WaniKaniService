using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaniKaniService.Models;

namespace WaniKaniService.Examples
{
    public class ResponseProvider
    {
        public ResponseProvider(WaniKaniClient waniKaniClient)
        {
            ArgumentNullException.ThrowIfNull(waniKaniClient, nameof(waniKaniClient));
            
            wkClient = waniKaniClient;
        }

        private readonly WaniKaniClient wkClient;

        public object GetResponse(string command, string? parameter = null)
        {
            object client = CommandToClient(command);

            if (client is IResponseClient responseClient)
                return responseClient.GetAsync().Result;
            else if (client is ICollectionClient collectionClient)
                if (GetWhetherPlural(command))
                    return GetResourceFromCollection(collectionClient, parameter);
                else
                    return GetResource(collectionClient, parameter);
            else
                throw new Exception("Client type cannot be identified.");
        }

        private int SelectIdFromConsole(object collection)
        {
            IEnumerable<int>? ids = null;

            switch (collection)
            {
                case IEnumerable<Resource<Subject>> subjectCollection:
                    foreach (Resource<Subject> item in subjectCollection)
                        Console.WriteLine(string.Format("{0,8} {1,5} {2,5}", item.Data?.Type, item.Id, item.Data?.Characters));

                    ids = subjectCollection.Select(s => s.Id);
                    break;

                case IEnumerable<Resource<Assignment>> assignmentCollection:
                    foreach (Resource<Assignment> item in assignmentCollection)
                        Console.WriteLine(string.Format("{0,8} {1,5} {2,5}", item.Data?.SubjectType, item.Id, item.Data?.SubjectId));

                    ids = assignmentCollection.Select(s => s.Id);
                    break;
            }

            if (ids is null)
                throw new Exception("Collection could not be found");

            // prompt user for specific response
            int id = -1;
            while (!ids.Contains(id))
            {
                Console.WriteLine("Enter the id for the subject you want to view.");
                id = Convert.ToInt32(Console.ReadLine());
            }

            return id;
        }

        private object GetResourceFromCollection(ICollectionClient client, string? parameter)
        {
            parameter ??= string.Empty;

            try
            {
                // get collection
                int id = SelectIdFromConsole(client.GetAllAsync(parameter).Result);
                
                return client.GetAsync(id).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object GetResource(ICollectionClient client, string? parameter)
        {
            try
            {
                int id = Convert.ToInt32(parameter);
                return client.GetAsync(id).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool GetWhetherPlural(string command)
        {
            return command switch
            {
                "assignments"
                or "subjects"
                    => true,

                "assignment"
                or "subject"
                or "user"
                    => false,

                _ => throw new Exception("Command not recognized.")
            };
        }

        private object CommandToClient(string command)
        {
            return command switch
            {
                "assignment"
                or "assignments"
                    => wkClient.AssignmentsClient,

                "subject"
                or "subjects"
                    => wkClient.SubjectsClient,

                "user"
                    => wkClient.UserClient,

                _ => throw new Exception("Command not recognized.")
            };
        }
    }
}

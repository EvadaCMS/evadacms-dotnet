using Evada.ManagementApi;
using Evada.ManagementApi.Models;
using System;
using System.Threading.Tasks;

namespace ConsoleWorkbench
{
    class Program
    {
        static string _token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjZjYTdkZDc0ZTkzNWVkODlkMDIwOTRjZmYxOTQxYjg2IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MTkxNTk3MzEsImV4cCI6MTUxOTI0NjEzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo0OTk2MCIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjQ5OTYwL3Jlc291cmNlcyIsImFwaSJdLCJjbGllbnRfaWQiOiIwYWFmZTAwZGIwY2M0YjgwOTIzM2NiZTBkNmRhZGE0ZiIsImNvbnRhaW5lcklkIjoiZTI4ZjE2YmItN2NkZS00Yzg0LWJmZWItZjllZDdmNDUwZjliIiwic3Vic2NyaXB0aW9uSWQiOiIwYmQ2NGVjNy0yZDhkLTRkNTYtOTlhOC1mOGFjYTYxMzdiZjUiLCJzdWIiOiJhOTc3OTA2Ni1iZDJjLTRhYTUtOTQ1Yi1hODdiMDBlNjU1ZDgiLCJqdGkiOiI5ZjljNTM0ZDg5ZGVlNDQzZDRjMjU5N2JmZTM2NmEwNiIsInNjb3BlIjpbImNyZWF0ZTpjb250YWluZXJzIiwicmVhZDphc3NldHMiLCJyZWFkOmNvbnRhaW5lcnMiLCJyZWFkOmNvbnRlbnRfaXRlbXMiLCJyZWFkOmNvbnRlbnRfdHlwZV9tb2R1bGVzIiwicmVhZDpjb250ZW50X3R5cGVzIiwicmVhZDpsYW5ndWFnZXMiLCJyZWFkOm1vZHVsZXMiLCJyZWFkOnVzZXJzIiwicmVhZDp3b3JrZmxvd19zdGVwcyIsInVwZGF0ZTpjb250YWluZXJzIl19.jCw_MwG4PHjx0WXBgO8h1G10BHYExEuR-p-aGFU-TwsmyMDq9Q8vHuXDVuMaD_4ywXR1-fU3NGJE0rEKE9X4q9ogDEsYj_rRzWaY3dCfXczrrlBvxvO-399Bze-PnrOV3D5u0VNpXXR0VkqyQtCtLUgkIGl9cEQB_nf2BbBocaCJM0nvtml0AuhlHywyuYmD6Py2HeDPuqV0nw4ul_i3QCIA4Ti4QwLbbhX5-6i5LOT1qifQ7uLzA7QblNY8gzyGdC3y4NaT5MyS5kOlpaZVzkZsAcVAX8pgJUHncIDqb8WLq33H-t5i58VmygAGuSzzXyaRKg1zjF_Crb6Crg2O1Q";
        static string _baseUrl = "http://localhost:49960";

        static void Main(string[] args)
        {
            // ManagementApiMainAsync(args).GetAwaiter().GetResult();

            // Containers_GetAll().GetAwaiter().GetResult();
            // Containers_Get().GetAwaiter().GetResult();
            // Containers_Create().GetAwaiter().GetResult();
            Containers_Update().GetAwaiter().GetResult();

            Console.ReadKey();
        }

        public static async Task Containers_GetAll()
        {
            var managementApiClient = new ManagementApiClient(_token, _baseUrl);
            var containers = await managementApiClient.Containers.GetAllAsync();

            foreach (var container in containers)
            {
                Console.WriteLine(container.Name);
            }
        }

        public static async Task Containers_Get()
        {
            var managementApiClient = new ManagementApiClient(_token, _baseUrl);
            var container = await managementApiClient.Containers.GetAsync(Guid.Parse("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b"));
            Console.WriteLine(container.Name);
        }

        public static async Task Containers_Create()
        {
            var managementApiClient = new ManagementApiClient(_token, _baseUrl);
            var container = await managementApiClient.Containers.CreateAsync(new ContainerCreateRequest
            {
                Name = "Test from .net api"
            });
            Console.WriteLine(container.Name);
        }

        public static async Task Containers_Update()
        {
            var managementApiClient = new ManagementApiClient(_token, _baseUrl);
            var container = await managementApiClient.Containers.UpdateAsync(Guid.Parse("D78F265B-6F36-4E79-BF2B-F79730C3A161"), new ContainerUpdateRequest
            {
                Name = "Updated name from .net api"
            });
                
            Console.WriteLine(container.Name);
        }

        /*public static async Task ManagementApiMainAsync(string[] args)
        {
            var managementApiClient = new ManagementApiClient(_token, _baseUrl);
            var container = await managementApiClient.Containers.GetAsync(Guid.Parse("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b"));
            
            Console.WriteLine(container.Name);

            Console.ReadKey();
        }*/


    }
}

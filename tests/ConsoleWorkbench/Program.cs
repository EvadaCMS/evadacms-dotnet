using Evada.ContentApi;
using Evada.ContentApi.Models;
using Evada.Core.QueryParameters;
using Evada.ManagementApi;
using Evada.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleWorkbench
{
    class Program
    {
        static string _token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjZjYTdkZDc0ZTkzNWVkODlkMDIwOTRjZmYxOTQxYjg2IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MTkxNTk3MzEsImV4cCI6MTUxOTI0NjEzMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo0OTk2MCIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjQ5OTYwL3Jlc291cmNlcyIsImFwaSJdLCJjbGllbnRfaWQiOiIwYWFmZTAwZGIwY2M0YjgwOTIzM2NiZTBkNmRhZGE0ZiIsImNvbnRhaW5lcklkIjoiZTI4ZjE2YmItN2NkZS00Yzg0LWJmZWItZjllZDdmNDUwZjliIiwic3Vic2NyaXB0aW9uSWQiOiIwYmQ2NGVjNy0yZDhkLTRkNTYtOTlhOC1mOGFjYTYxMzdiZjUiLCJzdWIiOiJhOTc3OTA2Ni1iZDJjLTRhYTUtOTQ1Yi1hODdiMDBlNjU1ZDgiLCJqdGkiOiI5ZjljNTM0ZDg5ZGVlNDQzZDRjMjU5N2JmZTM2NmEwNiIsInNjb3BlIjpbImNyZWF0ZTpjb250YWluZXJzIiwicmVhZDphc3NldHMiLCJyZWFkOmNvbnRhaW5lcnMiLCJyZWFkOmNvbnRlbnRfaXRlbXMiLCJyZWFkOmNvbnRlbnRfdHlwZV9tb2R1bGVzIiwicmVhZDpjb250ZW50X3R5cGVzIiwicmVhZDpsYW5ndWFnZXMiLCJyZWFkOm1vZHVsZXMiLCJyZWFkOnVzZXJzIiwicmVhZDp3b3JrZmxvd19zdGVwcyIsInVwZGF0ZTpjb250YWluZXJzIl19.jCw_MwG4PHjx0WXBgO8h1G10BHYExEuR-p-aGFU-TwsmyMDq9Q8vHuXDVuMaD_4ywXR1-fU3NGJE0rEKE9X4q9ogDEsYj_rRzWaY3dCfXczrrlBvxvO-399Bze-PnrOV3D5u0VNpXXR0VkqyQtCtLUgkIGl9cEQB_nf2BbBocaCJM0nvtml0AuhlHywyuYmD6Py2HeDPuqV0nw4ul_i3QCIA4Ti4QwLbbhX5-6i5LOT1qifQ7uLzA7QblNY8gzyGdC3y4NaT5MyS5kOlpaZVzkZsAcVAX8pgJUHncIDqb8WLq33H-t5i58VmygAGuSzzXyaRKg1zjF_Crb6Crg2O1Q";
        static string _baseUrl = "https://localhost:49961";

        static void Main(string[] args)
        {
            // ManagementApiMainAsync(args).GetAwaiter().GetResult();

            // Containers_GetAll().GetAwaiter().GetResult();
            // Containers_Get().GetAwaiter().GetResult();
            // Containers_Create().GetAwaiter().GetResult();
            // Containers_Update().GetAwaiter().GetResult();

            // ContentItems_GetAll().GetAwaiter().GetResult();
            // ContentItems_Get().GetAwaiter().GetResult();

            //ContentItems_TPF().GetAwaiter().GetResult();
            //ContentItems_TPF_HomePage().GetAwaiter().GetResult();
            ContentItems_Via_Home().GetAwaiter().GetResult();
            // ContentItems_Serialized().GetAwaiter().GetResult();


            //Management_CreateAuthorizationToken().GetAwaiter().GetResult();


            Console.ReadKey();
        }

        public static async Task Management_CreateAuthorizationToken()
        {
            var managementApiClient = new ManagementApiClient(string.Empty, _baseUrl);
            var token = await managementApiClient.Authorization.CreateTokenAsync("0aafe00db0cc4b809233cbe0d6dada4f", "BlJRXGmZjp0R5Xutg+1R7Y5dMu8FixoiRZAtvqZislg=");
            Console.WriteLine(token.AccessToken);
        }

        public static async Task ContentItems_Get()
        {
            var contentApiClient = new ContentApiClient("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b", _token, _baseUrl);
            
            var item = await contentApiClient.ContentItems.GetAsync("eric-zimmerman",
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1),
                    new ExcludeModulesParameter(false)
                });
            //var modules = ((IEnumerable<dynamic>)item.modules);
            /*foreach (var module in modules)
            {
                Console.WriteLine(module.value);
            }*/

            //Console.WriteLine(item.name);
        }

        public static async Task ContentItems_Serialized()
        {
            var contentApiClient = new ContentApiClient("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b");
            ContentItem item = await contentApiClient.ContentItems.GetAsync("eric-zimmermans", 
                new List<IQueryParameter>
                {
                    new DepthParameter(1)
                });

            var nameModule = item.Modules.FirstOrDefault(x => x.Slug == "name");
            Console.WriteLine(nameModule.Value);
            /*foreach (var module in item.Modules)
            {
                Console.WriteLine(module.Value);
            }*/
        }

        public static async Task ContentItems_TPF_HomePage()
        {
            var contentApiClient = new ContentApiClient("729e5a36-798d-4006-8dfe-397c26d6db2d", string.Empty, _baseUrl);

            ContentItem item = await contentApiClient.ContentItems.GetAsync("home-page");
            var assets = item.GetAssets("banner-image");

            List<ContentItem> showItems = await contentApiClient.ContentItems.GetAllAsync(new List<IQueryParameter>
            {
                new TypesParameter("show"),
                new DepthParameter(1)
            });

            foreach (var show in showItems)
            {
                var venue = show.GetReferenceItems("venue").FirstOrDefault();
                if (venue != null)
                {
                    Console.WriteLine(venue.GetString("name"));
                }
            }
        }

        public static async Task ContentItems_Via_Home()
        {
            var contentApiClient = new ContentApiClient("be140d2b-267f-4ba5-9b60-dc8ebcb5446c", string.Empty, _baseUrl);

            ContentItem item = await contentApiClient.ContentItems.GetAsync("home", new List<IQueryParameter>
            {
                new DepthParameter(1)
            });
            /*var assets = item.GetAssets("banner-image");

            List<ContentItem> showItems = await contentApiClient.ContentItems.GetAllAsync(new List<IQueryParameter>
            {
                new TypesParameter("show"),
                new DepthParameter(1)
            });

            foreach (var show in showItems)
            {
                var venue = show.GetReferenceItems("venue").FirstOrDefault();
                if (venue != null)
                {
                    Console.WriteLine(venue.GetString("name"));
                }
            }*/
            var hero = item.GetReferenceItems("hero-unit").FirstOrDefault();
            if (hero != null)
            {
                Console.WriteLine(hero.GetString("title"));
            }            
        }

        public static async Task ContentItems_TPF()
        {
            var contentApiClient = new ContentApiClient("729e5a36-798d-4006-8dfe-397c26d6db2d", string.Empty, _baseUrl);

            //ContentItem item = await contentApiClient.ContentItems.GetAsync("home-page");
            List<ContentItem> showItems = await contentApiClient.ContentItems.GetAllAsync(new List<IQueryParameter>
            {
                new TypesParameter("show"),
                new DepthParameter(1)
            });

            foreach (var show in showItems)
            {
                var venue = show.GetReferenceItems("venue").FirstOrDefault();
                if (venue != null)
                {
                    Console.WriteLine(venue.GetString("name"));
                }
            }
        }

        public static async Task ContentItems_GetAll()
        {
            var contentApiClient = new ContentApiClient("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b", _token, _baseUrl);
            var items = await contentApiClient.ContentItems.GetAllAsync(new TypesParameter("author", "about-page"));

            foreach (var item in items)
            {
                //Console.WriteLine(item.name);
                /*var modules = ((IEnumerable<dynamic>)item.modules);
                foreach (var module in modules)
                {
                    Console.WriteLine(module.value);
                }*/
            }
            /*foreach (var item in items)
            {
                var textModules = ((IEnumerable<dynamic>)item.modules).Where(x => x.type == "text");
                foreach (var txt in textModules)
                {
                    Console.WriteLine(txt.value);
                }
            }*/

            var authorItems = ((IEnumerable<dynamic>)items).Where(x => x.content_type.slug == "author");
            foreach (var author in authorItems)
            {
                Console.WriteLine(author.slug);
            }
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

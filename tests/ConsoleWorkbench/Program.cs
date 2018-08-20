using Evada.DeliveryApi;
using Evada.DeliveryApi.Models;
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
        const string _baseUrl = "https://localhost:49965";
        const string _containerId = "be140d2b-267f-4ba5-9b60-dc8ebcb5446c";

        static void Main(string[] args)
        {
            // ManagementApiMainAsync(args).GetAwaiter().GetResult();

            // Containers_GetAll().GetAwaiter().GetResult();
            // Containers_Get().GetAwaiter().GetResult();
            // Containers_Create().GetAwaiter().GetResult();
            // Containers_Update().GetAwaiter().GetResult();

            //Items_GetAll_No_Params().GetAwaiter().GetResult();
            //Items_GetAll_ByCreatedAt().GetAwaiter().GetResult();
            //Items_GetAll_By_Name().GetAwaiter().GetResult();
            //Items_GetAll_By_Slug().GetAwaiter().GetResult();
            //Items_GetAll_By_PublishAt().GetAwaiter().GetResult();
            //Items_GetAll_With_Select().GetAwaiter().GetResult();
            //Items_GetAll_With_OrderBy().GetAwaiter().GetResult();
            //Items_GetAll_ByLang().GetAwaiter().GetResult();
            //Items_GetAll_ByTypeId().GetAwaiter().GetResult();
            //Items_GetSingle().GetAwaiter().GetResult();

            Med_Get_Home().GetAwaiter().GetResult();

            Console.ReadKey();
        }

        public static async Task Med_Get_Home()
        {
            var client = new DeliveryApiClient("b8b59548-7fe1-42a2-9c3c-2c1b93fa6b45", "en -US", _baseUrl);
            var item = await client.Items.GetSingleAsync("home",
                new QueryParameter[] { new DepthParameter(1) });

            var bannerSlides = item.References
                .Where(r => r.System.Type.Id == new Guid("0da33202-760f-4ff1-9cee-e20f6ab80673")).ToList();

            //var serviceReferenceIds = item.GetValue<List<Guid>>("services");
            //var serviceItems = item.References.Where(r => serviceReferenceIds.Any(x => x == r.System.Id));
            var serviceItems = item.GetReferences("services");
            foreach (var si in serviceItems)
            {
                Console.WriteLine(si.System.Name);
            }

            //Console.WriteLine(item.System.Name);
        }

        public static async Task Items_GetAll_With_OrderBy()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new SelectParameter(new List<string>
                    {
                        Fields.Name
                    }),
                    new OrderParameter(Fields.Name, descending: true),
                    new TotalParameter(true)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }

            Console.WriteLine(items.Pagination.Total);
        }

        public static async Task Items_GetAll_With_Select()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new SelectParameter(new List<string>
                    {
                        Fields.Name
                    })
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_PublishAt()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new FirstPublishedAtParameter(ParameterOperator.LessThan, DateTime.Parse("8/6/2018")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_Slug()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new SlugParameter(ParameterOperator.Equals, "different_type_test"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_Name()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new NameParameter(ParameterOperator.Equals, "Different Type Test"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_ByCreatedAt()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new CreatedAtParameter(ParameterOperator.LessThan, DateTime.Parse("8/6/2018")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetSingle()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var item = await client.Items.GetSingleAsync("test_item_for_publishing",
                new List<QueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1)
                });
            Console.WriteLine(item.System.Name);
        }

        public static async Task Items_GetAll_ByLang()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_ByTypeId()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);
            var items = await client.Items.GetAsync(
                new List<QueryParameter>
                {
                    new TypeParameter(Guid.Parse("6ffdeb1b-9b87-4154-a5b0-65c362970906")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_No_Params()
        {
            var client = new DeliveryApiClient(_containerId, "en-US", _baseUrl);

            /*foreach (var item in await client.Items.GetAllAsync())
            {
                Console.WriteLine(item.System.Name);
            }*/
            var items = await client.Items.GetAsync();
            var item = items.Items[0];
            //Console.WriteLine(item.GetString("title"));
            Console.WriteLine(item.GetValue<string>("title"));
            /*foreach (var module in item.Modules)
            {
                Console.WriteLine(module.Value.Value);
            }*/
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        /**
         * TODO: rewrite these three tests into a single parameterized test
         * If you're stuck, have a look at the exercises for Day 1, as we
         * did the exact same thing there (just for a unit test instead of an API test).
         * Do this either using the [TestCase] attribute, or using [TestDataSource] combined
         * with the appropriate method to create and yield the TestCaseData objects.
         */
        [Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public async Task GetDataForUser2_CheckName_ShouldEqualErvinHowell()
        {
            RestRequest request = new RestRequest("/users/2", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Ervin Howell"));
        }

        [Test]
        public async Task GetDataForUser3_CheckName_ShouldEqualClementineBauch()
        {
            RestRequest request = new RestRequest("/users/3", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo("Clementine Bauch"));
        }

        /*
        public static Dictionary<int,string> userinfo = new Dictionary<int, string>
        {
            {1, "Leanne Graham"},
            {2, "Ervin Howell"},
            {3, "Clementine Bauch"}
        };
        */

        private static Dictionary<int, string> LoadUsers()
        {
            string filePath = "D:\\Bootcamp\\sdet-bootcamp-main\\csharp\\SdetBootcampDay3\\Exercises\\userinfo.json";
            if(!File.Exists(filePath))
            {
                throw new FileNotFoundException("Json file not found");
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<int, string>>(json)!;
        }

        [Test, TestCaseSource("Users")]
        public async Task GetDataForUsers(int userId, string name)
        {
            RestRequest request = new RestRequest($"/users/{userId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject data = JObject.Parse(response.Content!);

            Assert.That(data.SelectToken("name")!.ToString(), Is.EqualTo(name));
        }

        private static IEnumerable<TestCaseData> Users()
        {
            var users = LoadUsers();

            foreach (var item in users)
            {
                yield return new TestCaseData(item.Key, item.Value).SetName($"User {item.Key} is {item.Value}");
            }
            
            /*
            for(int i = 1; i<=3; i++)
            {
                yield return new TestCaseData(i, userinfo[i]).SetName($"User {i} is {userinfo[i]}");
            }
            // yield return new TestCaseData(1, "Leanne Graham").SetName("User 1 is Leanne Graham");
            // yield return new TestCaseData(2, "Ervin Howell").SetName("User 2 is Ervin Howell");
            // yield return new TestCaseData(3, "Clementine Bauch").SetName("User 3 is Clementine Bauch");
            */
        }

        [TestCase(1, "Leanne Graham", TestName = "User 1 is Leanne Graham")]
        [TestCase(2, "Ervin Howell", TestName = "User 2 is Ervin Howell")]
        [TestCase(3, "Clementine Bauch", TestName = "User 3 is Clementine Bauch")]
         public async Task GetDataForUser_CheckName_ShouldEqualExpectedName_UsingTestCase
            (int userId, string name)
        {
            RestRequest request = new RestRequest($"/users/{userId}", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            JObject responseData = JObject.Parse(response.Content!);

            Assert.That(responseData.SelectToken("name")!.ToString(), Is.EqualTo(name));
        }
    }
}

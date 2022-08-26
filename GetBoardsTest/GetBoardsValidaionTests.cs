


namespace GetBoardsTest
{
    public class GetBoardsValidaionTests
    {

        private static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
            _client = new RestClient("https://api.trello.com");

        private IRestRequest RequestWitAuth(string url) =>
            new RestRequest(url)
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d8")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1");

        [Test]
        public void CheckGetBoards()
        {
            var request = RequestWitAuth("/1/members/{memberId}/boards")
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("memberId", "annabellabenyi1");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse
                    (File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckGetBoard()
        {
           var request = RequestWitAuth("/1/boards/{boardId}")
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo("My New board"));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse
                (File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_a_board.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }


        [Test]
        public void CheckGetBoardWithInvalidID()
        {
            var request = RequestWitAuth("/1/boards/{boardId}")
                 .AddUrlSegment("boardId", "invalid");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("invalid id"));
        }

        [Test]
        public void CheckGetBoardWithInvlidAuth()
        {
            var request = new RestRequest("/1/boards/{boardId}")
               .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("unauthorized permission requested"));
        }

        [Test]
        public void CheckGetBoardWithOtherUsersToken()
        {
            var request = new RestRequest("/1/boards/{boardId}")
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d8")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c2")
                .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid token"));

        }

        [Test]
        public void CheckGetBoardWithOtherUsersKey()
        {
            var request = new RestRequest("/1/boards/{boardId}")
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d7")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1")
                .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid key"));

        }
    }

   
}
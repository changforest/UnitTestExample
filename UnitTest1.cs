using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var client = new RestClient(serverUri);
            var request = new RestRequest(this.uri, Method.POST);
            request.Timeout = 50000;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            var bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmZDYxOTEzNjlAZ21haWwuY29tIiwibmFtZWlkIjoiMjI0MDY1IiwidHlwIjoiUyIsIm5iZiI6MTYyNzk3MTM2NSwiZXhwIjoxNjU5NTA3MzY1LCJpYXQiOjE2Mjc5NzEzNjUsImlzcyI6IkhpVHV0b3IifQ.Aaqqry2tNfojmQgOqRsMgaDvRrA9aVD8A9F4d0xKIOE";
            request.AddHeader("Authorization", string.Format("Bearer {0}", bearerToken));


            var req = new User()
            {
                UserId = 224065,
                FolderName = "Unit 01",
                LadderMaterialCode = "",
                MaterialTitle = "測試教材",
                FolderSequence = 1,
            };

            request.AddJsonBody(req);

            Parallel.For(1, 10, (i, state) => 
            {
                var responseData = client.Execute(request);
                if ((int)responseData.StatusCode != 200)
                {
                    failList.Add(responseData.StatusCode);
                }
                else
                {
                    succList.Add(responseData.StatusCode);
                }
            });

            var a = 1;
            Assert.Pass();
        }
        private class User
        {
            /// <summary>
            /// 程式編號
            /// </summary>
            public int UserId { get; set; }
            public string FolderName { get; set; }
            public string MaterialTitle  { get; set; }
            public string LadderMaterialCode { get; set; }
            public int FolderSequence { get; set; }
        }
    }
}
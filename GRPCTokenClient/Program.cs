using Grpc.Core;
using Grpc.Net.Client;
using GRPCTokenServer;
using System;
using System.Net.Http;

namespace GRPCTokenClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // AppContext.SetSwitch(
            //"System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
            //true);
            // var httpClient = new HttpClient();
            // // The port number(50051) must match the port of the gRPC server.
            // httpClient.BaseAddress = new Uri("http://localhost:50051");
            // var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);

            // HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("https://localhost:50051");
            //var result = await httpClient.PostAsync("api/token", new { Email = "admin@contract.com", Password = "12345678" }.AsJson());
            var tokenValue = "Bearer " + "eyJhbGciOiJSUzI1NiIsImtpZCI6Ijk4OTIzRkRERTkxODJDOURERjRGQzZCQzNBMEI1RDUzNDNFNkM4QjEiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJtSklfM2VrWUxKM2ZUOGE4T2d0ZFUwUG15TEUifQ.eyJuYmYiOjE1NjEyNjEwODUsImV4cCI6MTU2MjI2MTA4NSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1NDMxMSIsImF1ZCI6ImlkZW50aXR5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI0NzczYzUzMi0wMDg1LTQwZGUtYTllNy1iZTNlMjBhNjdlOTQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTU5MDE0MDIzODIiLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6Iks0RlE2Sk1TNEZPUzROR1Q2TE9UVFlJR1ZDRTZRQlRVIiwidXNlcmlkIjoiNDc3M2M1MzItMDA4NS00MGRlLWE5ZTctYmUzZTIwYTY3ZTk0IiwidXNlcm5hbWUiOiIxNTkwMTQwMjM4MiJ9.pSEkPwyRMNeDYd6ONR0xjJMfhFhOgZB_gcr0fa7NP8dAnPfuf4aW0xIzNsAp6NGn91fu9vbV5gSEbTUghRfzKemEcPwIDaeho1oYvV-xFRWBBo4JFBx5FcB-kVdy4TeFCTu1nTIb0MUqmkgk40HFngmK7jW9epAu2m1YYvyvweqoe5cS4eHcEMun4lSOlJwoCmL-V1DW_LQb8LojrBUjn2mz3f0yAlUWIA_vi_Z37QX60Sg-BMtlrH0fdaJuypNdRtlWp6qvNEZgZ496wIjHnSCUr15Z6AbqQfa2XTBI16pLj96HTeTjkxGR0XmoCaRmXWiTeOg0nFq5pZ8dDoJOIg";

            var metadata = new Metadata
            {
                { "Authorization", tokenValue }
            };
            CallOptions callOptions = new CallOptions(metadata);



            var channel = new Channel("localhost:50051", SslCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" }, callOptions);
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

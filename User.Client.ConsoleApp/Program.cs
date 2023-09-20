using Grpc.Net.Client;
using User.GrpcService.Host;

var message = new UserRequest
{
	Id = 2
};

var messageP = new UserPostRequest
{
	FirstName = "eli",
	LastName = "Mohamadi",
	NationalCode = 00222222222,
	Birthday = "Aban",
	Id = 4
};

var messageD = new UserDeleteRequest
{
	Id = 3
};

var messageU = new UserUpdateRequest
{
	FirstName = "Elham",
	LastName = "Mohamadi",
	NationalCode = 00222233222,
	Birthday = "Aban",
	Id= 2
};

var channel = GrpcChannel.ForAddress("http://localhost:5127");

var client = new Greeter.GreeterClient(channel);

var srerveReply = await client.GetUserAsync(message);

var srerveReplyP = client.PostUser(messageP);

var srerveReplyD = client.DeleteUser(messageD);

var srerveReplyU = client.UpdateUser(messageU);


Console.WriteLine(srerveReply);
Console.WriteLine(srerveReplyP);
Console.WriteLine(srerveReplyD);
Console.WriteLine(srerveReplyU);

Console.ReadLine();
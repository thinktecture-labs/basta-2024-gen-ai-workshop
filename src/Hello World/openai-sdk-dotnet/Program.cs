using OpenAI.Chat;


var apiKey = System.Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (String.IsNullOrEmpty(apiKey))
{
	Console.Error.WriteLine("OPENAI_API_KEY environment variable is not set");
	return;
}

var model = "gpt-4";
var client = new ChatClient(model, apiKey);

var messages = new List<ChatMessage>([
		new SystemChatMessage("Du bist ein freundlicher, fröhlicher chat-assistent."),
	]);

var completed = false;

Console.CancelKeyPress += (sender, eventArgs) =>
{
	eventArgs.Cancel = true;
	completed = true;
};

while (!completed)
{
	// Get user input
	Console.Write("Your input: ");
	var input = Console.ReadLine();

	// in case it's empty (enter, or ctrl-c), we just ignore it
	if (String.IsNullOrEmpty(input)) continue;

	// add it to chat history
	messages.Add(new UserChatMessage(input));

	// get response from LLM
	var response = await client.CompleteChatAsync(messages);
	var answer = response.Value.ToString();

	// add response to chat history and write it to the user
	messages.Add(new AssistantChatMessage(answer));
	Console.WriteLine($"AI output: {answer}");
}

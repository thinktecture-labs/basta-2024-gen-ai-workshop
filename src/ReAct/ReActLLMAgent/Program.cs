using SimpleLLMAgents;
using SimpleLLMAgents.Tools;

var llm = new ChatLlm();

var agent = new ReActAgent(llm, new List<ITool> { new CalculatorTool() });
var response = await agent.Run("Calculate sqrt(3 + 5 / 7 * 9) ?");

Console.WriteLine("### " + response);
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnblogs.DashScope.Core;
using Cnblogs.DashScope.Sdk.QWen;

public class ChatService
{
    private readonly IDashScopeClient _client;

    public ChatService(IDashScopeClient client)
    {
        _client = client;
    }

    public async Task<string> GetResponseAsync(string message)
    {
        var completion = await _client.GetQWenCompletionAsync(QWenLlm.QWenMax, message);
        return completion.Output.Text;
    }
}

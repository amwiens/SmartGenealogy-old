using LLama.Common;
using LLama;

namespace SmartGenealogy.ViewModels;

public partial class ChatDetailPageViewModel : BaseViewModel
{
    ChatSession _session;

    public ChatDetailPageViewModel()
    {
        LoadData();
        InitializeChatSession();
    }

    void LoadData()
    {
        IsBusy = true;
        Task.Run(async () =>
        {
            // await api call;
            await Task.Delay(1000);
            //Application.Current.Dispatcher.Dispatch(() =>
            //{
            //});
        });
    }

    private void InitializeChatSession()
    {
        string modelPath = Path.Combine(FileSystem.Current.AppDataDirectory, "wizardLM-7B.ggmlv3.q4_1.bin"); //AppSettings.AppSettings.ModelPath; //@"C:\Users\m075542\Downloads\wizardLM-7B.ggmlv3.q4_1.bin"; // change it to your own model path
        var prompt = "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.\r\n\r\nUser: Hello, Bob.\r\nBob: Hello. How may I help you today?\r\nUser: Please tell me the largest city in Europe.\r\nBob: Sure. The largest city in Europe is Moscow, the capital of Russia."; // use the "chat-with-bob" prompt here.

        // Initialize a chat session
        var ex = new InteractiveExecutor(new LLamaModel(new ModelParams(modelPath, contextSize: 1024, seed: 1337, gpuLayerCount: 5)));
        _session = new ChatSession(ex);

        Messages.Add(new SocialMessage()
        {
            Text = prompt,
            Time = DateTime.Now.ToString(),
            Sender = new SocialUser { Name = "Bob", Status = "Online" }
        });
    }

    [RelayCommand]
    private async Task SendMessageAsync()
    {
        Messages.Add(new SocialMessage()
        {
            Text = Message,
            Time = DateTime.Now.ToString()
        });

        GetMessageResponse(Message);
        Message = string.Empty;
    }

    [ObservableProperty]
    string _message;

    [ObservableProperty]
    SocialUser _user;

    [ObservableProperty]
    ObservableCollection<SocialMessage> _messages = new ObservableCollection<SocialMessage>();

    private void GetMessageResponse(string message)
    {
        var textString = string.Empty;

        // run the inference in a loop to chat with LLM
        foreach (var text in _session.Chat(message, new InferenceParams() { Temperature = 0.6f, AntiPrompts = new List<string> { "User:" } }))
        {
            if (textString.Length == 0 && text == "\n")
                continue;
            textString = string.Concat(textString, text);
        }

        textString = textString.Substring(0, textString.Length - 7);

        Messages.Add(new SocialMessage()
        {
            Text = textString,
            Time = DateTime.Now.ToString(),
            Sender = new SocialUser { Name = "Bob", Status = "Online" }
        });
    }
}
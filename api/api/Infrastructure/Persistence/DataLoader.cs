namespace api.Infrastructure.Persistence;

public class DataLoader
{
    private readonly KreitekfyContext _kreitekfyContext;

    public DataLoader(KreitekfyContext kreitekfyContext)
    {
        _kreitekfyContext = kreitekfyContext;
    }

    public void LoadData()
    {
    }
}
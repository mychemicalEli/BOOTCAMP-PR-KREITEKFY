namespace api.Domain.Services;

public interface IImageVerifier
{
    bool IsImage(byte[] bytes);
}
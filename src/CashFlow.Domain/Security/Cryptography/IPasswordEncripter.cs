namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    public string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}

using Enigma5.Message.Contracts;
using Enigma5.Message.DataProviders.Contracts;
using Enigma5.Crypto.DataProviders;
using Enigma5.Crypto;

namespace Enigma5.Message.DataProviders;

public class TestOnion : ITestOnion
{
    private IOnion onion;

    public TestOnion(ISetMessageContent builder)
    {
        ExpectedContent = new byte[128];
        ExpectedNextAddress = PKey.Address2;
        new Random().NextBytes(ExpectedContent);

        onion = builder
            .SetMessageContent(ExpectedContent)
            .SetNextAddress(HashProvider.FromHexString(ExpectedNextAddress))
            .Seal(PKey.PublicKey1)
            .Build();
    }

    public string ExpectedNextAddress { get; set; }

    public byte[] ExpectedContent { get; set; }

    public byte[] Content { get => onion.Content; set => onion.Content = value; }
}

namespace BestGuide.UnitTests;

// Nur zum Prüfen, dass das Test-Setup läuft. Darf gelöscht werden.
public class SanityTests
{
    [Fact]
    public void TestSetup_Works()
    {
        (1 + 1).Should().Be(2);
    }
}

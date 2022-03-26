using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeTest()
    {
        axe = new Axe(10, 2);
        dummy = new Dummy(40, 5);
    }

    [Test]
    public void AxeLosesDurabilityAfterEachAttack()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe doesn't change after attack.");
    }

    [Test]
    public void AttackWithABrokenAxe()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}
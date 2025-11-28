using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Modifiers;

public class MagicShieldModifierTests
{
    [Fact]
    public void MagicShieldModifier_FirstDamage_ShouldBeBlocked()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var modifier = new MagicShieldModifier();
        ICreature modifiedCreature = modifier.ApplyModifier(creature);

        // Act
        modifiedCreature.TakeDamage(100);

        // Assert
        Assert.Equal(10, creature.Health);
    }

    [Fact]
    public void MagicShieldModifier_SecondDamage_ShouldNotBeBlocked()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var modifier = new MagicShieldModifier();
        ICreature modifiedCreature = modifier.ApplyModifier(creature);

        // Act
        modifiedCreature.TakeDamage(3);
        modifiedCreature.TakeDamage(4);

        // Assert
        Assert.Equal(6, creature.Health);
    }
}


using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Spells;

public class SpellTests
{
    [Fact]
    public void StrengthPotion_ShouldIncreaseAttack()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var spell = new StrengthPotion();

        // Act
        spell.Apply(creature);

        // Assert
        Assert.Equal(10, creature.Attack);
    }

    [Fact]
    public void StaminaPotion_ShouldIncreaseHealth()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var spell = new StaminaPotion();

        // Act
        spell.Apply(creature);

        // Assert
        Assert.Equal(15, creature.Health);
    }

    [Fact]
    public void ProtectionAmulet_ShouldApplyMagicShield()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var spell = new ProtectionAmulet();
        var attacker = new Creature(100, 10);

        // Act
        ICreature? modifiedCreature = spell.Apply(creature);
        Assert.NotNull(modifiedCreature);
        ICreature decoratedCreature = modifiedCreature ?? throw new InvalidOperationException("Protection amulet must return a decorated creature.");
        attacker.AttackCreature(decoratedCreature);

        // Assert
        Assert.Equal(10, creature.Health);
    }

    [Fact]
    public void MagicMirror_ShouldSwapAttackAndHealth()
    {
        // Arrange
        var creature = new Creature(5, 10);
        var spell = new MagicMirror();

        // Act
        spell.Apply(creature);

        // Assert
        Assert.Equal(10, creature.Attack);
        Assert.Equal(5, creature.Health);
    }
}


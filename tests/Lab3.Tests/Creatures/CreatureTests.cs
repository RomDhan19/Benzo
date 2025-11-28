using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Creatures;

public class CreatureTests
{
    [Fact]
    public void Creature_Initialization_ShouldSetAttackAndHealth()
    {
        // Arrange
        const int attack = 5;
        const int health = 10;

        // Act
        var creature = new Creature(attack, health);

        // Assert
        Assert.Equal(attack, creature.Attack);
        Assert.Equal(health, creature.Health);
    }

    [Fact]
    public void Creature_AttackCreature_ShouldDealDamage()
    {
        // Arrange
        var attacker = new Creature(5, 10);
        var defender = new Creature(3, 8);

        // Act
        attacker.AttackCreature(defender);

        // Assert
        Assert.Equal(3, defender.Health);
    }

    [Fact]
    public void Creature_TakeDamage_ShouldReduceHealth()
    {
        // Arrange
        var creature = new Creature(5, 10);

        // Act
        creature.TakeDamage(3);

        // Assert
        Assert.Equal(7, creature.Health);
    }

    [Fact]
    public void Creature_ModifyAttack_ShouldChangeAttack()
    {
        // Arrange
        var creature = new Creature(5, 10);

        // Act
        creature.ModifyAttack(3);

        // Assert
        Assert.Equal(8, creature.Attack);
    }

    [Fact]
    public void Creature_ModifyHealth_ShouldChangeHealth()
    {
        // Arrange
        var creature = new Creature(5, 10);

        // Act
        creature.ModifyHealth(5);

        // Assert
        Assert.Equal(15, creature.Health);
    }
}


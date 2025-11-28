using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Modifiers;

public class AttackMasteryModifierTests
{
    [Fact]
    public void AttackMasteryModifier_ShouldAttackTwice_WhenHealthRemainsPositive()
    {
        // Arrange
        var attacker = new Creature(5, 10);
        var defender = new Creature(2, 20);
        var modifier = new AttackMasteryModifier();
        ICreature modifiedAttacker = modifier.ApplyModifier(attacker);

        // Act
        modifiedAttacker.AttackCreature(defender);

        // Assert
        Assert.Equal(10, defender.Health);
    }

    [Fact]
    public void AttackMasteryModifier_ShouldNotAttackTwice_WhenAttackerDies()
    {
        // Arrange
        var attacker = new SelfSacrificingCreature(5, 1);
        var defender = new Creature(10, 20);
        var modifier = new AttackMasteryModifier();
        ICreature modifiedAttacker = modifier.ApplyModifier(attacker);

        // Act
        modifiedAttacker.AttackCreature(defender);

        // Assert
        Assert.Equal(15, defender.Health);
    }

    private sealed class SelfSacrificingCreature : Creature
    {
        public SelfSacrificingCreature(int attack, int health)
            : base(attack, health)
        {
        }

        public override void AttackCreature(ICreature target)
        {
            base.AttackCreature(target);
            ModifyHealth(-Health);
        }
    }
}


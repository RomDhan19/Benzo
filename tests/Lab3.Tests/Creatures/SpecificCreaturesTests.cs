using Itmo.ObjectOrientedProgramming.Lab3.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Creatures;

public class SpecificCreaturesTests
{
    [Fact]
    public void BattleAnalyst_ShouldIncreaseAttack_OnFirstAttack()
    {
        // Arrange
        var analyst = new BattleAnalyst();
        var target = new Creature(1, 10);

        // Act
        analyst.AttackCreature(target);

        // Assert
        Assert.Equal(4, analyst.Attack);
        Assert.Equal(6, target.Health);
    }

    [Fact]
    public void ViciousFighter_ShouldDoubleAttack_WhenTakingNonLethalDamage()
    {
        // Arrange
        var fighter = new ViciousFighter();
        var attacker = new Creature(2, 10);

        // Act
        attacker.AttackCreature(fighter);

        // Assert
        Assert.Equal(2, fighter.Attack);
        Assert.Equal(4, fighter.Health);
    }

    [Fact]
    public void MimicChest_ShouldCopyStats_WhenAttacking()
    {
        // Arrange
        var mimic = new MimicChest();
        var target = new Creature(5, 10);

        // Act
        mimic.AttackCreature(target);

        // Assert
        Assert.Equal(5, mimic.Attack);
        Assert.Equal(10, mimic.Health);
    }

    [Fact]
    public void ImmortalHorror_ShouldRevive_OnFirstDeath()
    {
        // Arrange
        var horror = new ImmortalHorror();
        var attacker = new Creature(10, 10);

        // Act
        attacker.AttackCreature(horror);

        // Assert
        Assert.Equal(1, horror.Health);
        Assert.Equal(4, horror.Attack);
    }

    [Fact]
    public void AmuletMaster_ShouldHaveMagicShield_OnFirstDamage()
    {
        // Arrange
        ICreature master = CreatureFactories.CreateAmuletMasterFactory().Create();
        var attacker = new Creature(100, 10);

        // Act
        attacker.AttackCreature(master);

        // Assert
        Assert.Equal(2, master.Health);
    }

    [Fact]
    public void AmuletMaster_ShouldAttackTwice_WhenHealthRemains()
    {
        // Arrange
        ICreature master = CreatureFactories.CreateAmuletMasterFactory().Create();
        var target = new Creature(1, 20);

        // Act
        master.AttackCreature(target);

        // Assert
        Assert.Equal(10, target.Health);
    }
}


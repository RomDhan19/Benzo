using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.PlayerTable;

public class PlayerTableTests
{
    [Fact]
    public void PlayerTable_AddCreature_ShouldAddCreature()
    {
        // Arrange
        var table = new PlayerTableImplementation();
        var creature = new Creature(5, 10);

        // Act
        table.AddCreature(creature);

        // Assert
        Assert.Equal(1, table.CreatureCount);
    }

    [Fact]
    public void PlayerTable_AddCreature_ShouldThrow_WhenExceedingMax()
    {
        // Arrange
        var table = new PlayerTableImplementation();
        for (int i = 0; i < 7; i++)
        {
            table.AddCreature(new Creature(1, 1));
        }

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => table.AddCreature(new Creature(1, 1)));
    }

    [Fact]
    public void PlayerTable_GetAttackingCreatures_ShouldReturnOnlyValidAttackers()
    {
        // Arrange
        var table = new PlayerTableImplementation();
        table.AddCreature(new Creature(5, 10));
        table.AddCreature(new Creature(0, 10));
        table.AddCreature(new Creature(5, 1));
        table.ApplySpell(2, new KillSpell());

        // Act
        var attackers = table.GetAttackingCreatures().ToList();

        // Assert
        Assert.Single(attackers);
    }

    [Fact]
    public void PlayerTable_ApplySpell_ShouldModifyCreature()
    {
        // Arrange
        var table = new PlayerTableImplementation();
        var creature = new Creature(5, 10);
        table.AddCreature(creature);
        var spell = new StrengthPotion();

        // Act
        table.ApplySpell(0, spell);

        // Assert
        Assert.Equal(5, creature.Attack);
        ICreature modifiedCreature = table.GetAttackingCreatures().Single();
        Assert.Equal(10, modifiedCreature.Attack);
    }

    private sealed class KillSpell : ISpell
    {
        public ICreature? Apply(ICreature creature)
        {
            creature.ModifyHealth(-creature.Health);
            return null;
        }
    }
}


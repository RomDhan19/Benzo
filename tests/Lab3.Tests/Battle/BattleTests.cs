using Itmo.ObjectOrientedProgramming.Lab3.Battle;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Battle;

public class BattleTests
{
    [Fact]
    public void Battle_Player1Win_WhenPlayer2HasNoDefenders()
    {
        // Arrange
        var player1Table = new PlayerTableImplementation();
        player1Table.AddCreature(new Creature(10, 10));
        var player2Table = new PlayerTableImplementation();
        var battle = new BattleSystem();

        // Act
        BattleResult result = battle.Fight(player1Table, player2Table);

        // Assert
        Assert.Equal(BattleResult.Player1Win, result);
    }

    [Fact]
    public void Battle_ShouldNotModifyOriginalCreatures()
    {
        // Arrange
        var player1Table = new PlayerTableImplementation();
        var creature1 = new Creature(10, 10);
        player1Table.AddCreature(creature1);
        var player2Table = new PlayerTableImplementation();
        var creature2 = new Creature(5, 5);
        player2Table.AddCreature(creature2);
        var battle = new BattleSystem();

        // Act
        battle.Fight(player1Table, player2Table);

        // Assert
        Assert.Equal(10, creature1.Health);
        Assert.Equal(5, creature2.Health);
    }

    [Fact]
    public void Battle_Draw_WhenBothPlayersHaveNoAttackers()
    {
        // Arrange
        var player1Table = new PlayerTableImplementation();
        var player2Table = new PlayerTableImplementation();
        var battle = new BattleSystem();

        // Act
        BattleResult result = battle.Fight(player1Table, player2Table);

        // Assert
        Assert.Equal(BattleResult.Draw, result);
    }
}


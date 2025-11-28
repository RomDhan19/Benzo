using Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battle;

public enum BattleResult
{
    Player1Win,
    Player2Win,
    Draw,
}

public interface IBattle
{
    BattleResult Fight(IPlayerTable player1Table, IPlayerTable player2Table);
}
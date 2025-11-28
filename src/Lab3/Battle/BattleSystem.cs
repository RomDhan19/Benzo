using Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battle;

public class BattleSystem : IBattle
{
    public BattleResult Fight(IPlayerTable player1Table, IPlayerTable player2Table)
    {
        ArgumentNullException.ThrowIfNull(player1Table);
        ArgumentNullException.ThrowIfNull(player2Table);

        var player1BattleCreatures = player1Table.GetAttackableCreatures()
            .Select(c => new BattleCreature(c))
            .ToList();
        var player2BattleCreatures = player2Table.GetAttackableCreatures()
            .Select(c => new BattleCreature(c))
            .ToList();

        bool player1Turn = true;

        while (true)
        {
            List<BattleCreature> attackingCreatures = player1Turn ? player1BattleCreatures : player2BattleCreatures;
            List<BattleCreature> defendingCreatures = player1Turn ? player2BattleCreatures : player1BattleCreatures;

            var availableAttackers = attackingCreatures
                .Where(c => c.Attack > 0 && c.Health > 0)
                .ToList();
            var availableDefenders = defendingCreatures
                .Where(c => c.Health > 0)
                .ToList();

            if (availableAttackers.Count == 0 && availableDefenders.Count == 0)
            {
                return BattleResult.Draw;
            }

            if (availableAttackers.Count > 0 && availableDefenders.Count == 0)
            {
                return player1Turn ? BattleResult.Player1Win : BattleResult.Player2Win;
            }

            if (availableAttackers.Count == 0)
            {
                player1Turn = !player1Turn;
                continue;
            }

            int attackerIndex = RandomNumberGenerator.GetInt32(availableAttackers.Count);
            int defenderIndex = RandomNumberGenerator.GetInt32(availableDefenders.Count);
            BattleCreature attacker = availableAttackers[attackerIndex];
            BattleCreature defender = availableDefenders[defenderIndex];

            attacker.AttackCreature(defender);

            player1Turn = !player1Turn;
        }
    }
}
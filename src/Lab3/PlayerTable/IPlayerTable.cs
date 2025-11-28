using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;

public interface IPlayerTable
{
    void AddCreature(ICreature creature);

    void ApplySpell(int creatureIndex, ISpell spell);

    IEnumerable<ICreature> GetAttackingCreatures();

    IEnumerable<ICreature> GetAttackableCreatures();

    int CreatureCount { get; }
}
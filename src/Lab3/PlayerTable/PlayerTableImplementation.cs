using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.PlayerTable;

public class PlayerTableImplementation : IPlayerTable
{
    private const int MaxCreatures = 7;
    private readonly List<ICreature> _creatures = new();

    public int CreatureCount => _creatures.Count;

    public void AddCreature(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        if (_creatures.Count >= MaxCreatures)
        {
            throw new InvalidOperationException($"Cannot add more than {MaxCreatures} creatures to the table");
        }

        // Create a copy to ensure isolation between catalog and table creatures
        // Changes to creatures on the table should not affect creatures in the catalog
        ICreature creatureCopy = creature.Clone();
        _creatures.Add(creatureCopy);
    }

    public void ApplySpell(int creatureIndex, ISpell spell)
    {
        ArgumentNullException.ThrowIfNull(spell);

        if (creatureIndex < 0 || creatureIndex >= _creatures.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(creatureIndex), "Creature index is out of range");
        }

        ICreature creature = _creatures[creatureIndex];
        ICreature? modifiedCreature = spell.Apply(creature);

        if (modifiedCreature != null)
        {
            _creatures[creatureIndex] = modifiedCreature;
        }
    }

    public IEnumerable<ICreature> GetAttackingCreatures()
    {
        return _creatures.Where(c => c.Attack > 0 && c.Health > 0);
    }

    public IEnumerable<ICreature> GetAttackableCreatures()
    {
        return _creatures.Where(c => c.Health > 0);
    }
}
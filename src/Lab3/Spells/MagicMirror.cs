using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature? Apply(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        int currentAttack = creature.Attack;
        int currentHealth = creature.Health;

        int attackDelta = currentHealth - currentAttack;
        int healthDelta = currentAttack - currentHealth;

        creature.ModifyAttack(attackDelta);
        creature.ModifyHealth(healthDelta);

        return null;
    }
}
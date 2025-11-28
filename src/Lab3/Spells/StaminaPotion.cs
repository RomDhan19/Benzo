using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StaminaPotion : ISpell
{
    private const int HealthBonus = 5;

    public ICreature? Apply(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        creature.ModifyHealth(HealthBonus);
        return null;
    }
}
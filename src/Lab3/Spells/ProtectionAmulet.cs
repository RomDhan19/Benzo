using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionAmulet : ISpell
{
    public ICreature? Apply(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        var modifier = new MagicShieldModifier();
        return modifier.ApplyModifier(creature);
    }
}
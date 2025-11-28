using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShieldModifier : IModifierApplier
{
    public ICreature ApplyModifier(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        return new MagicShieldCreature(creature);
    }

    private class MagicShieldCreature : ICreature
    {
        private readonly ICreature _creature;
        private bool _shieldActive = true;

        public MagicShieldCreature(ICreature creature)
            : this(creature, true)
        {
        }

        private MagicShieldCreature(ICreature creature, bool shieldActive)
        {
            ArgumentNullException.ThrowIfNull(creature);
            _creature = creature;
            _shieldActive = shieldActive;
        }

        public int Attack => _creature.Attack;

        public int Health => _creature.Health;

        public void AttackCreature(ICreature target)
        {
            _creature.AttackCreature(target);
        }

        public void TakeDamage(int damage)
        {
            if (_shieldActive)
            {
                _shieldActive = false;
                return;
            }

            _creature.TakeDamage(damage);
        }

        public void ModifyAttack(int delta)
        {
            _creature.ModifyAttack(delta);
        }

        public void ModifyHealth(int delta)
        {
            _creature.ModifyHealth(delta);
        }

        public ICreature Clone()
        {
            return new MagicShieldCreature(_creature.Clone(), _shieldActive);
        }
    }
}
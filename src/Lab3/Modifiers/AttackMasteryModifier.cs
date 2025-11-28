using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMasteryModifier : IModifierApplier
{
    public ICreature ApplyModifier(ICreature creature)
    {
        ArgumentNullException.ThrowIfNull(creature);

        return new AttackMasteryCreature(creature);
    }

    private class AttackMasteryCreature : ICreature
    {
        private readonly ICreature _creature;

        public AttackMasteryCreature(ICreature creature)
        {
            ArgumentNullException.ThrowIfNull(creature);
            _creature = creature;
        }

        public int Attack => _creature.Attack;

        public int Health => _creature.Health;

        public void AttackCreature(ICreature target)
        {
            ArgumentNullException.ThrowIfNull(target);

            if (_creature.Attack <= 0 || _creature.Health <= 0)
            {
                return;
            }

            if (target.Health <= 0)
            {
                return;
            }

            _creature.AttackCreature(target);

            if (_creature.Health > 0)
            {
                _creature.AttackCreature(target);
            }
        }

        public void TakeDamage(int damage)
        {
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
            return new AttackMasteryCreature(_creature.Clone());
        }
    }
}
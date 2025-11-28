namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class Creature : ICreature
{
    public Creature(int attack, int health)
    {
        if (attack < 0)
        {
            throw new ArgumentException("Attack cannot be negative", nameof(attack));
        }

        if (health <= 0)
        {
            throw new ArgumentException("Health must be positive", nameof(health));
        }

        Attack = attack;
        Health = health;
    }

    public int Attack { get; private set; }

    public int Health { get; private set; }

    public virtual void AttackCreature(ICreature target)
    {
        ArgumentNullException.ThrowIfNull(target);

        if (Attack <= 0 || Health <= 0)
        {
            return;
        }

        if (target.Health <= 0)
        {
            return;
        }

        target.TakeDamage(Attack);
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage cannot be negative", nameof(damage));
        }

        if (Health <= 0)
        {
            return;
        }

        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public virtual void ModifyAttack(int delta)
    {
        Attack += delta;
        if (Attack < 0)
        {
            Attack = 0;
        }
    }

    public virtual void ModifyHealth(int delta)
    {
        Health += delta;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    public virtual ICreature Clone()
    {
        return new Creature(Attack, Health);
    }
}
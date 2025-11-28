namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : Creature
{
    private const int InitialAttack = 1;
    private const int InitialHealth = 1;

    public MimicChest()
        : base(InitialAttack, InitialHealth)
    {
    }

    public override void AttackCreature(ICreature target)
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

        int newAttack = Math.Max(Attack, target.Attack);
        int newHealth = Math.Max(Health, target.Health);

        if (newAttack != Attack)
        {
            ModifyAttack(newAttack - Attack);
        }

        if (newHealth != Health)
        {
            ModifyHealth(newHealth - Health);
        }

        base.AttackCreature(target);
    }

    public override ICreature Clone()
    {
        var clone = new MimicChest();
        int attackDelta = Attack - InitialAttack;
        int healthDelta = Health - InitialHealth;

        if (attackDelta != 0)
        {
            clone.ModifyAttack(attackDelta);
        }

        if (healthDelta != 0)
        {
            clone.ModifyHealth(healthDelta);
        }

        return clone;
    }
}
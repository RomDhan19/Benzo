namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ViciousFighter : Creature
{
    private const int InitialAttack = 1;
    private const int InitialHealth = 6;

    public ViciousFighter()
        : base(InitialAttack, InitialHealth)
    {
    }

    public override void TakeDamage(int damage)
    {
        int healthBefore = Health;
        base.TakeDamage(damage);

        if (healthBefore > 0 && Health > 0 && Health < healthBefore)
        {
            ModifyAttack(Attack);
        }
    }

    public override ICreature Clone()
    {
        var clone = new ViciousFighter();
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
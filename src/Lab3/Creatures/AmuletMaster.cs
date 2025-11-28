namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : Creature
{
    private const int InitialAttack = 5;
    private const int InitialHealth = 2;

    public AmuletMaster()
        : base(InitialAttack, InitialHealth)
    {
    }

    public override ICreature Clone()
    {
        var clone = new AmuletMaster();
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
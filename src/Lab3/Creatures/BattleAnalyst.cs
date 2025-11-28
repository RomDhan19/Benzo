namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BattleAnalyst : Creature
{
    private const int InitialAttack = 2;
    private const int InitialHealth = 4;
    private const int AttackBonus = 2;

    public BattleAnalyst()
        : base(InitialAttack, InitialHealth)
    {
    }

    public override void AttackCreature(ICreature target)
    {
        ModifyAttack(AttackBonus);
        base.AttackCreature(target);
    }

    public override ICreature Clone()
    {
        var clone = new BattleAnalyst();
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
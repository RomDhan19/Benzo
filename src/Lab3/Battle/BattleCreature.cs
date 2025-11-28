using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battle;

public class BattleCreature
{
    private readonly ICreature _battleInstance;

    public BattleCreature(ICreature originalCreature)
    {
        ArgumentNullException.ThrowIfNull(originalCreature);

        _battleInstance = originalCreature.Clone();
    }

    public int Attack => _battleInstance.Attack;

    public int Health => _battleInstance.Health;

    public void AttackCreature(BattleCreature target)
    {
        ArgumentNullException.ThrowIfNull(target);

        _battleInstance.AttackCreature(target._battleInstance);
    }

    public void TakeDamage(int damage)
    {
        _battleInstance.TakeDamage(damage);
    }

    public void ModifyAttack(int delta)
    {
        _battleInstance.ModifyAttack(delta);
    }

    public void ModifyHealth(int delta)
    {
        _battleInstance.ModifyHealth(delta);
    }
}
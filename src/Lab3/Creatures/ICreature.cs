namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    int Attack { get; }

    int Health { get; }

    void AttackCreature(ICreature target);

    void TakeDamage(int damage);

    void ModifyAttack(int delta);

    void ModifyHealth(int delta);

    ICreature Clone();
}
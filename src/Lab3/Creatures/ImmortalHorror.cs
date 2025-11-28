namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : Creature
{
    private const int InitialAttack = 4;
    private const int InitialHealth = 4;
    private const int RevivalHealth = 1;
    private bool _hasRevived = false;

    public ImmortalHorror()
        : base(InitialAttack, InitialHealth)
    {
    }

    private ImmortalHorror(int attack, int health, bool hasRevived)
        : base(attack, health)
    {
        _hasRevived = hasRevived;
    }

    public override void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage cannot be negative", nameof(damage));
        }

        if (Health <= 0)
        {
            return;
        }

        int healthBefore = Health;
        base.TakeDamage(damage);

        if (Health <= 0 && !_hasRevived)
        {
            ModifyHealth(RevivalHealth - Health);
            _hasRevived = true;
        }
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(Attack, Health, _hasRevived);
    }
}
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public static class CreatureFactories
{
    public static ICreatureFactory CreateBattleAnalystFactory()
    {
        return new BattleAnalystFactory();
    }

    public static ICreatureFactory CreateViciousFighterFactory()
    {
        return new ViciousFighterFactory();
    }

    public static ICreatureFactory CreateMimicChestFactory()
    {
        return new MimicChestFactory();
    }

    public static ICreatureFactory CreateImmortalHorrorFactory()
    {
        return new ImmortalHorrorFactory();
    }

    public static ICreatureFactory CreateAmuletMasterFactory()
    {
        return new AmuletMasterFactory();
    }

    public static ICreatureFactory CreateCreatureFactory(int attack, int health)
    {
        return new CreatureFactory(attack, health);
    }

    private class BattleAnalystFactory : ICreatureFactory
    {
        public ICreature Create()
        {
            return new BattleAnalyst();
        }
    }

    private class ViciousFighterFactory : ICreatureFactory
    {
        public ICreature Create()
        {
            return new ViciousFighter();
        }
    }

    private class MimicChestFactory : ICreatureFactory
    {
        public ICreature Create()
        {
            return new MimicChest();
        }
    }

    private class ImmortalHorrorFactory : ICreatureFactory
    {
        public ICreature Create()
        {
            return new ImmortalHorror();
        }
    }

    private class AmuletMasterFactory : ICreatureFactory
    {
        public ICreature Create()
        {
            ICreature baseCreature = new AmuletMaster();
            return ApplyDefaultAmuletMasterModifiers(baseCreature);
        }
    }

    private class CreatureFactory : ICreatureFactory
    {
        private readonly int _attack;
        private readonly int _health;

        public CreatureFactory(int attack, int health)
        {
            _attack = attack;
            _health = health;
        }

        public ICreature Create()
        {
            return new Creature(_attack, _health);
        }
    }

    private static ICreature ApplyDefaultAmuletMasterModifiers(ICreature creature)
    {
        var magicShield = new MagicShieldModifier();
        var attackMastery = new AttackMasteryModifier();
        return attackMastery.ApplyModifier(magicShield.ApplyModifier(creature));
    }
}
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class CreatureCatalog
{
    private readonly Dictionary<string, ICreatureFactory> _factories = new();

    public void RegisterCreature(string name, ICreatureFactory factory)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(factory);

        _factories[name] = factory;
    }

    public ICreature CreateCreature(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace", nameof(name));
        }

        if (!_factories.TryGetValue(name, out ICreatureFactory? factory))
        {
            throw new KeyNotFoundException($"Creature '{name}' not found in catalog");
        }

        return factory.Create();
    }

    public IEnumerable<string> GetAvailableCreatures()
    {
        return _factories.Keys;
    }
}
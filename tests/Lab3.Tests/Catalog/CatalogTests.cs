using Itmo.ObjectOrientedProgramming.Lab3.Catalog;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Catalog;

public class CatalogTests
{
    [Fact]
    public void CreatureCatalog_RegisterAndCreate_ShouldWork()
    {
        // Arrange
        var catalog = new CreatureCatalog();
        ICreatureFactory factory = CreatureFactories.CreateBattleAnalystFactory();
        catalog.RegisterCreature("BattleAnalyst", factory);

        // Act
        ICreature creature = catalog.CreateCreature("BattleAnalyst");

        // Assert
        Assert.IsType<BattleAnalyst>(creature);
    }

    [Fact]
    public void CreatureCatalog_CreateCreature_ShouldThrow_WhenNotFound()
    {
        // Arrange
        var catalog = new CreatureCatalog();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => catalog.CreateCreature("NonExistent"));
    }
}


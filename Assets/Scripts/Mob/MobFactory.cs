using System;
namespace MobSystem
{
    public static class MobFactory
    {
        public static IMob Create(MobDefinition definition)
        {
            return definition.type switch
            {
                MobType.Aggressive => new AggressiveMob(definition),
                MobType.Friendly => new FriendlyMob(definition),
                MobType.Neutral => new NeutralMob(definition),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
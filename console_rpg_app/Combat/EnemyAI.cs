public enum EnemyAI
{
    SimpleAggressive,
    None
}

public static class AIFactory // Renamed for clarity
{
    public static ICombatAI Create(EnemyAI aiType)
    {
        switch (aiType)
        {
            case EnemyAI.SimpleAggressive:
                // Return a new instance of the aggressive AI
                return new SimpleAgressiveAI();
            case EnemyAI.None:
            default:
                // Return null or a "do nothing" AI if the type is None
                return null;
        }
    }
}
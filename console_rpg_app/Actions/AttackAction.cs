public class AttackAction : IGameAction
{
    public string Description { get; }
    private readonly CharacterManager _characterManager;
    private readonly Guid _attacker;
    private readonly Guid _target;

    public AttackAction(Guid attacker, Guid target, CharacterManager characterManager)
    {
        //TODO: Make the constructor grab the Guids for all enemies and all allies in the current Location/player's party
        //      This will make it so it's super easy to build a CombatState and pass it to the CombatScene Constructor
        _attacker = attacker;
        _target = target;
        Description = $"Attack {characterManager.GetCharacterById(_target).Name}";
        _characterManager = characterManager;
    }

    public SceneTransition? Execute()
    {
        // TODO: Build combatState for CombatScene
        // var combatScene = new CombatScene(_characterManager, combatState);
        // return combatScene;
        // _characterManager.GetCharacterById(_attacker).Attack(_characterManager.GetCharacterById(_target));
        Console.WriteLine("Combat would start now");
        return null;
    }
}
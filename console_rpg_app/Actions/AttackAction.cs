public class AttackAction : IGameAction
{
    public string Description { get; }
    private readonly CharacterManager _characterManager;
    private readonly Guid _attacker;
    private readonly Guid _target;

    public AttackAction(Guid attacker, Guid target, CharacterManager characterManager)
    {
        _attacker = attacker;
        _target = target;
        Description = $"Attack {characterManager.GetCharacterById(_target).Name}";
        _characterManager = characterManager;
    }

    public void Execute()
    {
        _characterManager.GetCharacterById(_attacker).Attack(_characterManager.GetCharacterById(_target));
    }
}
public class CombatScene : IScene
{

    public CombatScene()
    {
        //TODO: Accept the CharacterManager and assign it to a readonly variable
        //TODO: Accept a CombatState record, the CombatState.Self will be the player, the lists of Guids will be for the player's party (or friendly NPCs in the location) and for the Enemies in the location
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public SceneTransition Run()
    {
        while (true)
        {
            // Step 1- Determine Turn Order, run through each character and make an Inititive call, ordering them in a list/array
            // Step 2- Process turns, This will be where you let the enemy(s), ally(s), and the player take their turns.
            //           Build some private helper functions so that this Run can be cleaner and more readable, They can be something like "private void PlayerTurn()" and "private void EnemyTurn()"
            // Step 3- Check if the battle is over (i.e. all the enemies are dead, the enemies have all fled, the player is dead, or the player has fled. If it is over, break
        }

        return new SceneTransition(SceneAction.POP, null);
    }
}
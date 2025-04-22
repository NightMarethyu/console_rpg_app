public static class GameStrings
{
    public static class General
    {
        public const string Prompt = "> ";
        public const string InvalidCommand = "Invalid command\n";
        public const string GameOver = "Game Over.";
        public const string YouHaveDied = "You have died.";
    }

    public static class Commands
    {
        public const string Help = "Displays a list of available commands.";
        public const string Move = "Move to a connected location or down a connected path";
        public const string Look = "Describes the current location";
        public const string Take = "Add an item to your inventory";
        public const string Drop = "Remove an item from your inventory and drop it in your current location";
        public const string Open = "Access the contents of a container";
        public const string Attack = "Hit the enemy with an attack";
        public const string Quit = "Close the game";
        public const string Teleport = "Teleport to a connected location or down a connected path";

        public const string MoveUsage = "move {location name}";
        public const string LookUsage = "look";
        public const string TakeUsage = "take {item name}";
        public const string DropUsage = "drop {item name} {optional: quantity}";
        public const string OpenUsage = "open {item name}";
        public const string AttackUsage = "attack {enemy name}";
        public const string QuitUsage = "quit";
        public const string TeleportUsage = "teleport";
        public const string HelpUsage = "help";

        public static readonly List<string> AttackAliases = ["attack", "hit", "strike", "fight", "a", "atk"];
        public static readonly List<string> HelpAliases = ["help", "?", "info", "commands", "h"];
        public static readonly List<string> DropAliases = ["drop", "discard", "throw", "remove", "leave", "d"];
        public static readonly List<string> LookAliases = ["look", "examine", "inspect", "l", "view", "observe"];
        public static readonly List<string> MoveAliases = ["move", "go", "walk", "travel", "m", "run"];
        public static readonly List<string> OpenAliases = ["open", "o"];
        public static readonly List<string> QuitAliases = ["quit", "exit", "leave", "q", "bye"];
        public static readonly List<string> TakeAliases = ["take", "get", "grab", "pick", "collect", "t"];
        public static readonly List<string> TeleportAliases = ["teleport", "tp", "warp", "blink", "fasttravel", "portal"];
    }

    public static class Inventory
    {
        public const string ItemNotFound = "Item not found in inventory!";
        public const string NotEnoughQuantity = "You can't drop that many, not enough in your inventory";
        public const string QuestItemDropWarning = "You can't drop quest items!";
        public const string ItemAddedToInventory = "You have added {0} to your inventory";
        public const string YouDroppedItem = "You dropped {0}";
        public const string CannotTakeItem = "Can't take {0}";
        public const string InventoryEmpty = "Inventory is empty.";
        public const string InventoryFull = "Inventory is full";
    }

    public static class LocationMsgs
    {
        public const string EnemyNotFound = "Enemy with name {0} not found in current location";
        public const string BaseDescribe = "You are currently at location {0}";
        public const string ConnectedLocals = "There are paths connected to the following locations: ";
        public const string Characters = "The following characters can be found here";
        public const string LocationItems = "This area contains the following items:";
    }

    public static class Container
    {
        public const string Locked = "It's Locked";
        public const string Opened = "It's already open.";
        public const string OpenMessage = "You open the {0}.\n";
        public const string UnlockMessage = "You have unlocked the {0}.\n";
        public const string MissingKey = "You don't have the key!";
    }

    public static class Battle
    {
        public const string WhatWillYouDo = "-- What will you do? --";
        public const string AttackOption = "1. Attack";
        public const string DefendOption = "2. Defend";
        public const string UseItemOption = "3. Use Item";
        public const string FleeOption = "4. Flee";
        public const string YouAttack = "You attack the enemy for {0} damage";
        public const string EnemyAttack = "You take {0} damage from the enemy attack";
        public const string EnemyKilled = "You have killed {0}";
        public const string EndOfTurn = "--- End of Turn ---";
    }

    public static class Teleport
    {
        public static string TeleporterExists = "This room has a teleporter!";
        public static readonly string[] ZapLines = new[]
        {
            "     ⚡⚡⚡ ✨✨✨ ⚡⚡⚡",
            "  > The runes shimmer as your body begins to fade...",
            "     ✨✨✨",
            "  > You vanish in a swirl of arcane energy...",
            "     ⚡⚡⚡ WHOOSH ⚡⚡⚡"
        };

        public const string TeleportArrival = "You feel your body reassemble in a new location...";
    }

    public static class SceneMsgs
    {
        public const string EnterScene = "Entering Scene...";
        public const string ExitScene = "Exiting Scene...";
    }

    public static class ErrorMsgs
    {
        public const string NoScene = "No active scene.";
        public const string NoLocation = "Location not found";
        public const string TeleportUnset = "Teleport is not set";
    }
}

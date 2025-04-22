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
    }

    public static class UI
    {
        public const string ItemNotFound = "Item not found in inventory!";
        public const string NotEnoughQuantity = "You can't drop that many, not enough in your inventory";
        public const string QuestItemDropWarning = "You can't drop quest items!";
        public const string ItemAddedToInventory = "You have added {0} to your inventory";
        public const string YouDroppedItem = "You dropped {0}";
        public const string CannotTakeItem = "Can't take {0}";
        public const string InventoryEmpty = "Inventory is empty.";
    }

    public static class Battle
    {
        public const string WhatWillYouDo = "-- What will you do? --";
        public const string AttackOption = "1. Attack";
        public const string YouAttack = "You attack the enemy for {0} damage";
        public const string EnemyAttack = "You take {0} damage from the enemy attack";
        public const string EnemyKilled = "You have killed {0}";
        public const string EndOfTurn = "--- End of Turn ---";
    }

    public static class Teleport
    {
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
}

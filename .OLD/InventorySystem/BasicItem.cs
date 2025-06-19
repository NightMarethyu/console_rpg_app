namespace OLD
{

    public class BasicItem : Item
    {
        public BasicItem(string id, string name, string description, ItemType type, int value)
            : base(id, name, description, value, type)
        {
        }

        public override Item Clone(int quantity)
        {
            var item = new BasicItem(ID, Name, Description, Type, Value ?? 0);
            item.Quantity = quantity;
            item.IsTakeable = IsTakeable;
            item.IsStackable = IsStackable;
            return item;
        }
    }
}
namespace Models.Inventory.Items
{
    public abstract class ActivatableItem : InventoryItem
    {
        private bool IsActivated { get; set; }
        private bool CanBeActivated { get; set; }

        public override void Use()
        {
            if (IsActivated)
            {
                IsActivated = false;
                DeactivateItem();
            }
            else if (CanBeActivated)
            {
                IsActivated = true;
                ActivateItem();
            }
        }

        protected abstract void ActivateItem();
        protected abstract void DeactivateItem();

        protected ActivatableItem(int id, string name) : base(id, name)
        {
            IsActivated = false;
            CanBeActivated = true;
        }

        protected ActivatableItem(int id, string name, bool isActivated) : base(id, name)
        {
            IsActivated = isActivated;
        }
    }
}
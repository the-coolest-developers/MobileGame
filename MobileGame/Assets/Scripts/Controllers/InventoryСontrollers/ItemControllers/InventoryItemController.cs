using System;
using Models.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.InventoryСontrollers.ItemControllers
{
    public class InventoryItemController : MonoBehaviour
    {
        private InventoryItem _inventoryItem;

        public InventoryItem InventoryItem
        {
            get => _inventoryItem;
            private set
            {
                _inventoryItem = value;
                gameObject.name = value.Name;

                ButtonComponent.onClick.AddListener(_inventoryItem.OnClicked);
            }
        }

        private Button _buttonComponent;

        private Button ButtonComponent
        {
            get
            {
                if (_buttonComponent == null)
                {
                    _buttonComponent = GetComponent<Button>();
                }

                return _buttonComponent;
            }
        }
        
        public void SetItem(InventoryItem item)
        {
            InventoryItem = item;
        }
    }
}
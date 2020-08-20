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
            set
            {
                _inventoryItem = value;
                ButtonComponent.onClick.AddListener(_inventoryItem.OnClicked);
            }
        }

        private Button ButtonComponent { get; set; }

        private void Start()
        {
            ButtonComponent = GetComponent<Button>();
        }
    }
}
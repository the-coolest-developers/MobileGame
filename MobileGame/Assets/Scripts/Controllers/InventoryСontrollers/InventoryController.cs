using System.Collections.Generic;
using Controllers.InventoryСontrollers.ItemControllers;
using Models.Inventory.Items;
using UnityEngine;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        private GameObject _itemSpawnPosition;

        public GameObject ItemSpawnPosition
        {
            get
            {
                if (_itemSpawnPosition == null)
                {
                    _itemSpawnPosition = GameObject.Find("Inventory");
                }

                return _itemSpawnPosition;
            }
        }

        public GameObject itemPrefab;

        private List<GameObject> ItemUiObjects { get; set; }

        void Start()
        {
            ItemUiObjects = new List<GameObject>();

            SetItems(new List<InventoryItem>()
            {
                new Potion(1, "SomePotion"),
                new Potion(2, "AnotherPotion")
            });
        }

        public void AddItem(InventoryItem item)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, ItemSpawnPosition.transform, true);

            var itemController = instantiatedItem.GetComponent<InventoryItemController>();
            itemController.SetItem(item);

            ItemUiObjects.Add(instantiatedItem);
        }

        public void SetItems(List<InventoryItem> items)
        {
            items.ForEach(AddItem);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
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
            instantiatedItem.transform.position = _itemSpawnPosition.transform.position;

            var itemController = instantiatedItem.GetComponent<InventoryItemController>();
            itemController.SetItem(item);

            ItemUiObjects.Add(instantiatedItem);
        }

        public void RemoveItem(InventoryItem item)
        {
            var itemGameObject = ItemUiObjects.FirstOrDefault(i =>
                i.GetComponent<InventoryItemController>().InventoryItem == item);

            RemoveItem(itemGameObject);
        }

        public void RemoveItemById(int id)
        {
            var itemGameObject = ItemUiObjects.FirstOrDefault(i =>
                i.GetComponent<InventoryItemController>().InventoryItem.Id == id);

            RemoveItem(itemGameObject);
        }

        public void RemoveItem(GameObject itemGameObject)
        {
            ItemUiObjects.Remove(itemGameObject);
            Destroy(itemGameObject);
        }

        public void SetItems(List<InventoryItem> items)
        {
            items.ForEach(AddItem);
        }
    }
}
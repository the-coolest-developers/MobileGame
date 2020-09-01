using System.Collections.Generic;
using System.Linq;
using Controllers.InventoryСontrollers.ItemControllers;
using Models.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        public GameObject itemPrefab;
        public GameObject itemSpawnPosition;
        public string itemAssetsPath;
        public float itemSpacing;

        private float _itemPrefabHeight;

        public float ItemPrefabHeight
        {
            get
            {
                if (_itemPrefabHeight == 0)
                {
                    var rectTransform = itemPrefab.GetComponent<RectTransform>();
                    _itemPrefabHeight = rectTransform.sizeDelta.x;
                }

                return _itemPrefabHeight;
            }
        }

        private List<GameObject> ItemUiObjects { get; set; }

        void Start()
        {
            ItemUiObjects = new List<GameObject>();

            SetItems(new List<InventoryItem>()
            {
                new Potion(1, "HealthPotion"),
                new Potion(1, "HealthPotion"),
                new Potion(1, "HealthPotion"),
            });
        }

        public void AddItem(InventoryItem item)
        {
            GameObject instantiatedItem = Instantiate(itemPrefab, itemSpawnPosition.transform, true);
            var itemController = instantiatedItem.GetComponent<InventoryItemController>();
            itemController.SetItem(item);

            ItemUiObjects.Add(instantiatedItem);

            var imageComponent = instantiatedItem.transform.GetChild(0).GetComponent<Image>();
            var path = GetImagePath(item);
            var sprite = Resources.Load<Sprite>(path);
            imageComponent.sprite = sprite;

            ArrangeItems();
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

            ArrangeItems();
        }

        public void SetItems(List<InventoryItem> items)
        {
            items.ForEach(AddItem);
        }

        private void ArrangeItems()
        {
            for (int i = 0; i < ItemUiObjects.Count; i++)
            {
                var spawnPosition = itemSpawnPosition.transform.position;
                spawnPosition.y -= (itemSpacing + ItemPrefabHeight) * i;

                ItemUiObjects[i].transform.position = spawnPosition;
            }
        }

        private string GetImagePath(IInventoryItem item)
        {
            return $"{itemAssetsPath}/{item.ImagePathInFolder}";
        }
    }
}
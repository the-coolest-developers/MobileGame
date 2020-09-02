using System.Collections.Generic;
using Controllers.InventoryСontrollers.ItemControllers;
using Models.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI_Controllers.Inventory
{
    public class InventoryUiController : MonoBehaviour
    {
        private Image _selectedItemImage;

        private Image SelectedItemImage
        {
            get
            {
                if (_selectedItemImage == null)
                {
                    _selectedItemImage = GameObject.Find("SelectedItemImage").GetComponent<Image>();
                }

                return _selectedItemImage;
            }
        }

        private GameObject ItemNameText { get; set; }

        public InventoryItemController SelectedItem { get; private set; }

        //Из редактора
        public GameObject itemSpawnPosition;
        public GameObject itemPrefab;
        public string itemAssetsPath;
        public float itemSpacing;

        private float _itemPrefabHeight;

        private float ItemPrefabHeight
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

        private string GetImagePath(IInventoryItem item) => $"{itemAssetsPath}/{item.ImagePathInFolder}";

        private void HandleOnItemSelected(InventoryItemController itemController)
        {
            Debug.Log("It has been triggered!");

            SetSelectedItem(itemController);
            UpdateSelectedItemUiInformation();
        }

        void UpdateSelectedItemUiInformation()
        {
            if (SelectedItem != null)
            {
                SelectedItemImage.sprite = SelectedItem.ImageComponent.sprite;
            }
        }

        public void SetSelectedItem(InventoryItemController itemController)
        {
            SelectedItem = itemController;
        }

        /// <summary>
        /// Создаёт экземпляр префаба и устанавливает предмет 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public GameObject InstantiateItem(InventoryItem item)
        {
            var itemGameObject = Instantiate(itemPrefab, itemSpawnPosition.transform, true);

            var itemController = itemGameObject.GetComponent<InventoryItemController>();
            itemController.InventoryItem = item;
            itemController.ImageComponent.sprite = Resources.Load<Sprite>(GetImagePath(item));

            itemController.OnItemSelected += HandleOnItemSelected;

            return itemGameObject;
        }

        public void RefreshItemArrangement(List<GameObject> itemObjects)
        {
            for (var i = 0; i < itemObjects.Count; i++)
            {
                var spawnPosition = itemSpawnPosition.transform.position;
                spawnPosition.y -= (itemSpacing + ItemPrefabHeight) * i;

                itemObjects[i].transform.position = spawnPosition;
            }
        }

        public void OnEnable()
        {
            UpdateSelectedItemUiInformation();
        }
    }
}
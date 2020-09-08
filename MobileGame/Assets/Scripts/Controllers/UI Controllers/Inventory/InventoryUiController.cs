using System;
using System.Collections.Generic;
using Controllers.InventoryСontrollers;
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

        private Text _selecteditemNameText;

        private Text SelectedItemNameText
        {
            get
            {
                if (_selecteditemNameText == null)
                {
                    _selecteditemNameText = GameObject.Find("ItemNameText").GetComponent<Text>();
                }

                return _selecteditemNameText;
            }
        }

        private Text _selecteditemDescriptionText;

        private Text SelectedItemDescriptionText
        {
            get
            {
                if (_selecteditemDescriptionText == null)
                {
                    _selecteditemDescriptionText = GameObject.Find("ItemDescriptionText").GetComponent<Text>();
                }

                return _selecteditemDescriptionText;
            }
        }

        public event Action OnUseButtonClick = () => { };
        public event Action OnDropButtonClick = () => { };
        public event Action<InventoryItemController> OnItemSelected = itemController => { };

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

        public void UpdateSelectedItemUiInformation(InventoryItemController selectedItem)
        {
            if (selectedItem != null)
            {
                SelectedItemImage.sprite = selectedItem.ImageComponent.sprite;
                SelectedItemNameText.text = selectedItem.InventoryItem.Name;
                SelectedItemDescriptionText.text = selectedItem.InventoryItem.Description;
            }
        }

        /// <summary>
        /// Создаёт экземпляр префаба и устанавливает предмет 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public GameObject InstantiateItem(IInventoryItem item)
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

        public void UseButton_Click()
        {
            OnUseButtonClick();
        }

        public void DropButton_Click()
        {
            OnDropButtonClick();
        }

        private void HandleOnItemSelected(InventoryItemController itemController)
        {
            OnItemSelected(itemController);
        }
    }
}
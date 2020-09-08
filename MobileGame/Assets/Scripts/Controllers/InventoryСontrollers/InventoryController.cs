using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.InventoryСontrollers.ItemControllers;
using Controllers.UI_Controllers.Inventory;
using Models.Inventory.Items;
using UnityEngine;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryUiController InventoryUiController { get; set; }
        private List<GameObject> ItemUiObjects { get; set; }

        private InventoryItemController _selectedItem;

        private InventoryItemController SelectedItem
        {
            get
            {
                if (_selectedItem == null)
                {
                    _selectedItem = DefaultItem;
                }

                return _selectedItem;
            }
            set => _selectedItem = value;
        }

        /// <summary>
        /// Возвращает первый предмет, если он есть. В противном случае - выбрасывает exception 
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        private InventoryItemController DefaultItem
        {
            get
            {
                var first = ItemUiObjects.FirstOrDefault();

                if (first == null)
                {
                    throw new NullReferenceException();
                }

                return first.GetComponent<InventoryItemController>();
            }
        }

        private void Start()
        {
            InventoryUiController = GetComponent<InventoryUiController>();
            InventoryUiController.OnItemSelected += Handle_OnItemSelected;
            InventoryUiController.OnUseButtonClick += Handle_OnUseButtonClick;
            InventoryUiController.OnDropButtonClick += Handle_OnDropButtonClick;

            ItemUiObjects = new List<GameObject>();

            SetItems(new List<InventoryItem>()
            {
                new Potion(1, "HealthPotion", "Супер крутое зелье здоровья"),
                new Potion(2, "Test", "Тестовое зелье"),
                new Potion(1, "HealthPotion", "Ещё более крутое зелье здоровья с очень очень очень длинным описанием"),
            });
        }

        private void SelectItem(InventoryItemController itemController)
        {
            SelectedItem = itemController;
            InventoryUiController.UpdateSelectedItemUiInformation(itemController);
        }

        private void AddItem(IInventoryItem item)
        {
            var instantiatedItem = InventoryUiController.InstantiateItem(item);
            ItemUiObjects.Add(instantiatedItem);
            InventoryUiController.RefreshItemArrangement(ItemUiObjects);
        }

        private void RemoveItem(IInventoryItem item)
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

        private void RemoveItem(GameObject itemGameObject)
        {
            ItemUiObjects.Remove(itemGameObject);
            Destroy(itemGameObject);
            InventoryUiController.RefreshItemArrangement(ItemUiObjects);
        }

        private void SetItems(List<InventoryItem> items)
        {
            items.ForEach(AddItem);
        }

        private void Handle_OnItemSelected(InventoryItemController itemController)
        {
            SelectItem(itemController);
        }

        private void Handle_OnUseButtonClick()
        {
            SelectedItem.InventoryItem.Use();
        }

        private void Handle_OnDropButtonClick()
        {
            RemoveItem(SelectedItem.InventoryItem);
            if (ItemUiObjects.Count > 0)
            {
                SelectItem(DefaultItem);
            }

            InventoryUiController.RefreshItemArrangement(ItemUiObjects);
        }

        private void OnEnable()
        {
            if (InventoryUiController != null)
            {
                InventoryUiController.UpdateSelectedItemUiInformation(SelectedItem);
            }
        }
    }
}
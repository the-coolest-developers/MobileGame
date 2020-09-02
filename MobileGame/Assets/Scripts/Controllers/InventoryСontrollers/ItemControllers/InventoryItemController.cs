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
                gameObject.name = value.Name;
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

        private Image _imageComponent;

        public Image ImageComponent
        {
            get
            {
                if (_imageComponent == null)
                {
                    _imageComponent = transform.GetChild(0).GetComponent<Image>();
                }

                return _imageComponent;
            }
        }

        public event Action<InventoryItemController> OnItemSelected = i => { };

        public void OnClicked()
        {
            OnItemSelected?.Invoke(this);
        }
    }
}
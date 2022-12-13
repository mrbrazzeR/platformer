using System.Collections.Generic;
using CollectionObject;
using DataBase;
using UnityEngine;
using Utils;

namespace GamePlay
{
    public class MonoSprite : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        [SerializeField] private List<ItemSprite> data;
        private int _current;
        private PlayerViewData _playerViewData;
        [SerializeField] private ItemType itemType;


        private void Awake()
        {
            _playerViewData = PlayerViewerData.GetAllView();
            var itemCollections = Resources.Load<ItemCollection>(UtilsCollection.ItemCollection);
            foreach (var item in itemCollections.itemSprites)
            {
                if (item.itemType == itemType)
                {
                    data.Add(item);
                }
            }

            switch (itemType)
            {
                case ItemType.Head:
                {
                    var dataBase = _playerViewData.headData;
                    for (var i = 0; i < data.Count; i++)
                    {
                        if (data[i].id != dataBase) continue;
                        _current = i;
                        break;
                    }

                    break;
                }
                case ItemType.Body:
                {
                    var dataBase = _playerViewData.bodyData;
                    for (var i = 0; i < data.Count; i++)
                    {
                        if (data[i].id != dataBase) continue;
                        _current = i;
                        break;
                    }

                    break;
                }
                case ItemType.Weapon:
                {
                    var dataBase = _playerViewData.weaponData;
                    for (var i = 0; i < data.Count; i++)
                    {
                        if (data[i].id != dataBase) continue;
                        _current = i;
                        break;
                    }

                    break;
                }
            }

            SetSprite(data[_current]);
        }

        private void SetSprite(ItemSprite itemSprite)
        {
            spriteRenderer.sprite = itemSprite.icon;
        }
    }
}
using System.Collections.Generic;
using CollectionObject;
using DataBase;
using UnityEngine;
using Utils;

namespace GamePlay
{
    public class SecondSprite:MonoBehaviour
    {
        public SpriteRenderer leftRenderer;
        public SpriteRenderer rightRenderer;

        [SerializeField] private List<ItemSprite> data;
        private PlayerViewData _playerViewData;
        private int _current;
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

            var dataBase = _playerViewData.glovesData;
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i].id != dataBase) continue;
                _current = i;
                break;
            }
            SetSprite(data[_current], data[_current + 1]);
        }

        private void SetSprite(ItemSprite left, ItemSprite right)
        {
            leftRenderer.sprite = left.icon;
            rightRenderer.sprite = right.icon;
        }
    }
}
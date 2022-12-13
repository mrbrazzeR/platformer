using System.Collections.Generic;
using CollectionObject;
using DataBase;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace PlayerViewer
{
    public class MonoPlayerView : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        [SerializeField] private List<ItemSprite> data;
        private int _current;
        private PlayerViewData _playerViewData;
        [SerializeField] private ItemType itemType;

        [SerializeField] private Button backButton;
        [SerializeField] private Button nextButton;

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

            backButton.onClick.AddListener(BackSprite);
            nextButton.onClick.AddListener(NextSprite);
            SetSprite(data[_current]);
        }

        private void SetSprite(ItemSprite itemSprite)
        {
            spriteRenderer.sprite = itemSprite.icon;
        }

        private void SaveSprite()
        {
            switch (itemType)
            {
                case ItemType.Body:
                {
                    PlayerViewerData.SetBody(data[_current].id);
                    break;
                }
                case ItemType.Head:
                {
                    PlayerViewerData.SetHead(data[_current].id);
                    break;
                }
                case ItemType.Weapon:
                {
                    PlayerViewerData.SetWeapon(data[_current].id);
                    break;
                }
            }
        }

        private void BackSprite()
        {
            _current--;
            if (_current == -1)
            {
                _current = data.Count - 1;
            }

            SetSprite(data[_current]);
            SaveSprite();
        }

        private void NextSprite()
        {
            _current++;
            if (_current == data.Count)
            {
                _current = 0;
            }

            SetSprite(data[_current]);
            SaveSprite();
        }
    }
}
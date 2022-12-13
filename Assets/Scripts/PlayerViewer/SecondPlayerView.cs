using System.Collections.Generic;
using CollectionObject;
using DataBase;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace PlayerViewer
{
    public class SecondPlayerView : MonoBehaviour
    {
        public SpriteRenderer leftRenderer;
        public SpriteRenderer rightRenderer;

        [SerializeField] private List<ItemSprite> data;
        private PlayerViewData _playerViewData;
        private int _current;
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

            var dataBase = _playerViewData.glovesData;
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i].id != dataBase) continue;
                _current = i;
                break;
            }

            backButton.onClick.AddListener(BackSprite);
            nextButton.onClick.AddListener(NextSprite);
            SetSprite(data[_current], data[_current + 1]);
        }

        private void SetSprite(ItemSprite left, ItemSprite right)
        {
            leftRenderer.sprite = left.icon;
            rightRenderer.sprite = right.icon;
        }

        private void SaveSprite()
        {
            PlayerViewerData.SetGloves(data[_current].id);
        }

        private void BackSprite()
        {
            _current -= 2;
            if (_current < 0)
            {
                _current = data.Count - 2;
            }

            SetSprite(data[_current], data[_current + 1]);
            SaveSprite();
        }

        private void NextSprite()
        {
            _current += 2;
            if (_current >= data.Count)
            {
                _current = 0;
            }

            SetSprite(data[_current], data[_current + 1]);
            SaveSprite();
        }
    }
}
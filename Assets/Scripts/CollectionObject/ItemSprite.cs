using System;
using UnityEngine;

namespace CollectionObject
{
    [Serializable]
    public class ItemSprite
    {
        public int id;
        public Sprite icon;
        public string name;
        public ItemType itemType;
    }

    [Serializable]
    public enum ItemType
    {
        Weapon = 0,
        Gloves = 1,
        Body = 2,
        Head = 3,
    }
}
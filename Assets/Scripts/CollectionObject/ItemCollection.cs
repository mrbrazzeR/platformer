using UnityEngine;

namespace CollectionObject
{
    [CreateAssetMenu(fileName = "ItemCollection",menuName = "ItemCollection",order = 0)]
    public class ItemCollection:ScriptableObject
    {
        public ItemSprite[] itemSprites;

        private void OnValidate()
        {
            for (var i = 0; i < itemSprites.Length; i++)
            {
                itemSprites[i].id = i;
            }
        }
    }
}
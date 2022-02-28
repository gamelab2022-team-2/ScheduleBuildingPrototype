using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShape : InventoryItem
{
    [SerializeField] private GameObject itemPixelPrefab;
    public int[] shapeMatrix;

    internal void SetItemWithPixel(ItemData itemData)
    {
        this.itemData = itemData;
        this.shapeMatrix = itemData.shapeMatrix;

        Transform parent = GetComponent<RectTransform>().transform;

        for (int i = 0; i < itemData.height; i++)
        {
            for (int j = 0; j < itemData.width; j++)
            {
                if (shapeMatrix[i * itemData.width + j] == 1)
                {
                    Image image = Instantiate(itemPixelPrefab).GetComponent<Image>();

                    Vector2 sizePixel = new Vector2();
                    sizePixel.x = 1 * ItemGrid.tileSizeWidth;
                    sizePixel.y = 1 * ItemGrid.tileSizeHeight;
                    image.GetComponent<RectTransform>().sizeDelta = sizePixel;

                    image.transform.position = new Vector2(j * ItemGrid.tileSizeWidth, -i * ItemGrid.tileSizeHeight);
                    image.sprite = itemData.itemIcon;

                    image.gameObject.name = "pixel" + i * itemData.width + j;
                    image.transform.SetParent(parent);
                }
            }
        }

        Vector2 size = new Vector2();
        size.x = itemData.width * ItemGrid.tileSizeWidth;
        size.y = itemData.height * ItemGrid.tileSizeHeight;
        GetComponent<RectTransform>().sizeDelta = size;

    }


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    public const float tileSizeWidth = 32;
    public const float tileSizeHeight = 32;

    RectTransform rectTransform;

    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();

    InventoryItem[,] inventoryItemSlot;

    [SerializeField] private int gridSizeWidth = 20;
    [SerializeField] private int gridSizeHeight = 10;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Init(gridSizeWidth, gridSizeHeight);

    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);

        return tileGridPosition;
    }

    private void Init(int width, int height)
    {
        inventoryItemSlot = new InventoryItem[width, height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
    }

    internal InventoryItem GetItem(int x, int y)
    {
        return inventoryItemSlot[x, y];
    }

    public bool PlaceItem(InventoryItem item, int posX, int posY, ref InventoryItem overlapItem)
    {
        if (!BoundryCheck(posX, posY, item.itemData.width, item.itemData.height))
            return false;

        if (!OverlapCheck(posX, posY, item.itemData.width, item.itemData.height, ref overlapItem))
        {
            overlapItem = null;
            return false;
        }

        if (overlapItem != null)
        {
            CleanGridReference(overlapItem);
        }

        RectTransform rectTransform = item.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);

        for (int x = 0; x < item.itemData.width; x++)
        {
            for (int y = 0; y < item.itemData.height; y++)
            {
                inventoryItemSlot[posX + x, posY + y] = item;
            }
        }

        item.onGridPositionX = posX;
        item.onGridPositionY = posY;
        Vector2 position = CaculatePositionOnGrid(item, posX, posY);

        rectTransform.localPosition = position;

        return true;
    }

    public Vector2 CaculatePositionOnGrid(InventoryItem item, int posX, int posY)
    {
        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth + tileSizeWidth * item.itemData.width / 2;
        position.y = -(posY * tileSizeHeight + tileSizeHeight * item.itemData.height / 2);
        return position;
    }

    private bool OverlapCheck(int posX, int posY, int width, int height, ref InventoryItem overlapItem)
    {
       for (int x = 0; x < width; x++)
       {
            for (int y = 0; y < height; y++)
            {
                if (inventoryItemSlot[posX +x, posY + y] != null)
                {
                    if (overlapItem == null)
                    {
                        overlapItem = inventoryItemSlot[posX +x, posY + y];
                    }
                    else
                    {
                        if (overlapItem != inventoryItemSlot[posX +x, posY + y])
                        {
                            return false;
                        }
                    }
                }
            }
       }

       return true;
    }

    public InventoryItem PickUpItem(int x, int y)
    {
        InventoryItem item = inventoryItemSlot[x, y];

        if (item == null)
            return null;
        CleanGridReference(item);

        //inventoryItemSlot[x, y] = null;
        return item;
    }

    private void CleanGridReference(InventoryItem item)
    {
        for (int ix = 0; ix < item.itemData.width; ix++)
        {
            for (int iy = 0; iy < item.itemData.height; iy++)
            {
                inventoryItemSlot[item.onGridPositionX + ix, item.onGridPositionY + iy] = null;
            }
        }
    }

    bool PositionCheck(int posX, int posY)
    {
        if (posX < 0 || posY < 0)
            return false;

        if (posX >= gridSizeWidth || posY >= gridSizeHeight)
            return false;

        return true;
    }

    public bool BoundryCheck(int posX, int posY, int width, int height)
    {
        if (!PositionCheck(posX, posY))
            return false;

        posX += width - 1;
        posY += height - 1;

        if (!PositionCheck(posX, posY))
            return false;

        return true;
    }
}

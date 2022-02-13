using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHighlight : MonoBehaviour
{
    [SerializeField] RectTransform hightlighter;

    public void Show(bool b)
    {
        hightlighter.gameObject.SetActive(b);
    }

    public void SetSize(InventoryItem targetItem)
    {
        Vector2 size = new Vector2();
        size.x = targetItem.WIDTH * ItemGrid.tileSizeWidth;
        size.y = targetItem.HEIGHT * ItemGrid.tileSizeHeight;
        hightlighter.sizeDelta = size;
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem)
    {
        Vector2 position = targetGrid.CaculatePositionOnGrid(targetItem, targetItem.onGridPositionX, targetItem.onGridPositionY);
        hightlighter.localPosition = position;
    }

    public void SetParent(ItemGrid targetGrid)
    {
        if (targetGrid == null)
            return;
        hightlighter.SetParent(targetGrid.GetComponent<RectTransform>());
    }

    public void SetPosition(ItemGrid targetGrid, InventoryItem targetItem, int posX, int posY)
    {
        Vector2 pos = targetGrid.CaculatePositionOnGrid(targetItem, posX, posY);
        hightlighter.localPosition = pos;
    }
}



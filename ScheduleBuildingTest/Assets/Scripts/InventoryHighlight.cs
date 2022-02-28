using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryHighlight : MonoBehaviour
{
    [SerializeField] RectTransform hightlighter;
    [SerializeField] GameObject hightlightPixel;
    List<RectTransform> highlightPixelsBuffer = new List<RectTransform>();

    private void Start()
    {
        highlightPixelsBuffer.Add(hightlightPixel.GetComponent<RectTransform>());
    }

    public void Show(bool b)
    {
        hightlighter.gameObject.SetActive(b);
    }

    public void SetSize(InventoryItem targetItem)
    {
        if (targetItem is ItemShape)
        {
            hightlighter.GetComponent<Image>().enabled = false;
            hightlighter.sizeDelta = new Vector2(targetItem.itemData.width * ItemGrid.tileSizeWidth, targetItem.itemData.height * ItemGrid.tileSizeHeight);
            int index = 0;
            for (int i = 0; i < targetItem.itemData.height; i++)
            {
                for (int j = 0; j < targetItem.itemData.width; j++)
                {
                    if (targetItem.itemData.shapeMatrix[i * targetItem.itemData.width + j] == 1)
                    {
                        if (index < highlightPixelsBuffer.Count)
                        {
                            float minX = hightlighter.GetComponent<RectTransform>().position.x + hightlighter.GetComponent<RectTransform>().rect.xMin;
                            float maxY = hightlighter.GetComponent<RectTransform>().position.y + hightlighter.GetComponent<RectTransform>().rect.yMax;
                            float z = hightlighter.GetComponent<RectTransform>().position.z;
                            Vector3 pos = new Vector3(minX, maxY, z);
                            highlightPixelsBuffer[index].transform.position = pos + new Vector3(j * ItemGrid.tileSizeWidth, (-i * ItemGrid.tileSizeHeight));
                            highlightPixelsBuffer[index].gameObject.SetActive(true);
                        }
                        else
                        {
                            var newPixel = Instantiate(hightlightPixel);
                            Vector2 sizePixel = new Vector2();
                            sizePixel.x = 1 * ItemGrid.tileSizeWidth;
                            sizePixel.y = 1 * ItemGrid.tileSizeHeight;
                            newPixel.GetComponent<RectTransform>().sizeDelta = sizePixel;

                            newPixel.transform.position = new Vector2(j * ItemGrid.tileSizeWidth, -i * ItemGrid.tileSizeHeight);
                            newPixel.transform.SetParent(hightlighter);
                            highlightPixelsBuffer.Add(newPixel.GetComponent<RectTransform>());
                        }
                        index++;
                    }
                }
            }
            if (index < highlightPixelsBuffer.Count)
            {
                for (int i = index; i < highlightPixelsBuffer.Count; i++)
                    highlightPixelsBuffer[i].gameObject.SetActive(false);
            }
        }
        else
        {
            hightlighter.GetComponent<Image>().enabled = true;
            foreach (RectTransform rt in highlightPixelsBuffer)
                rt.gameObject.SetActive(false);

            Vector2 size = new Vector2();
            size.x = targetItem.WIDTH * ItemGrid.tileSizeWidth;
            size.y = targetItem.HEIGHT * ItemGrid.tileSizeHeight;
            hightlighter.sizeDelta = size;
        }
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



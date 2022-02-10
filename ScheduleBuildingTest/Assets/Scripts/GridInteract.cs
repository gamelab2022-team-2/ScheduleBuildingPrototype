using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemGrid))]

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InventoryController inventoryController;
    ItemGrid itemGrid;

    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryController.SelectedItemGrid = itemGrid;
        //Debug.Log("Pointer enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventoryController.SelectedItemGrid = null;
        //Debug.Log("Pointer exit");
    }

    private void Awake()
    {
        inventoryController = FindObjectOfType(typeof(InventoryController)) as InventoryController;
        itemGrid = GetComponent<ItemGrid>();
    }
}

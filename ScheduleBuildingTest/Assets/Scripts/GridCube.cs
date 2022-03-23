using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCube : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponentInParent<GridObject>().mouseClick();
    }
    private void OnMouseEnter()
    {
        GetComponentInParent<GridObject>().mouseEnters();
    }
    private void OnMouseExit()
    {
        GetComponentInParent<GridObject>().mouseExits();
    }
    private void OnMouseUp()
    {
        GetComponentInParent<GridObject>().mouseRelease();
    }

    public bool canRelease()
    {

        return true;
    }
    public bool checkIfFits()
    {
        LayerMask mask = LayerMask.GetMask("ScheduleSlot");
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f, mask);
        foreach (Collider c in cols)
            return c.transform.GetComponent<ScheduleSlot>().isSlotFree();
        return false;
    }
    public void occupySlot()
    {
        LayerMask mask = LayerMask.GetMask("ScheduleSlot");
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f, mask);
        foreach (Collider c in cols)
            c.transform.GetComponent<ScheduleSlot>().takeSlot();

    }
    public void releaseSlot()
    {
        LayerMask mask = LayerMask.GetMask("ScheduleSlot");
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.5f, mask);
        foreach (Collider c in cols)
            c.transform.GetComponent<ScheduleSlot>().releaseSlot();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3dGrid : MonoBehaviour
{

    [SerializeField] GameObject gridObjectPrefab;
    Schedule schedule;
    // Start is called before the first frame update
    void Start()
    {
        schedule = FindObjectOfType<Schedule>();
        schedule.blockRandomSlot();
        schedule.blockRandomSlot();
        schedule.blockRandomSlot();
        GameObject theThing = Instantiate(gridObjectPrefab);
        theThing.GetComponent<GridObject>().init("34111010010010", transform.position);
        GameObject newThing = Instantiate(gridObjectPrefab);
        newThing.GetComponent<GridObject>().init("33101101101", transform.position + Vector3.right*8);
        GameObject anotherThing = Instantiate(gridObjectPrefab);
        anotherThing.GetComponent<GridObject>().init("551010101010101010101010101", transform.position + Vector3.right * 16);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

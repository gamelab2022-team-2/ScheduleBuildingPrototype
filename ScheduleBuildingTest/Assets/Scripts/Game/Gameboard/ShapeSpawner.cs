using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{

    [SerializeField] GameObject gridObjectPrefab;

    List<GameObject> shapes = new List<GameObject>();

    Schedule schedule;
    // Start is called before the first frame update
    void Start()
    {
        //schedule = FindObjectOfType<Schedule>();
       // schedule.blockColumn(1);
        //schedule.blockRandomSlot();
        //schedule.blockRandomSlot();
        //schedule.blockRandomSlot();

        
        
       // SpawnShape(transform.position, "34111010010010");       
       // SpawnShape(transform.position + Vector3.right * 8, "33101101101");
       // SpawnShape(transform.position + Vector3.right * 16, "551010101010101010101010101");
    }

    public void SpawnShape(Vector3 position, string shapeString, Color color)
    {
        var shape = Instantiate(gridObjectPrefab);
        shapes.Add(shape);
        //shape.transform.parent = transform;
        shape.GetComponent<GridObject>().Initialize(shapeString, position, color);
    }

    public void Clear()
    {
        foreach(GameObject shape in shapes)
        {
            Destroy(shape);
        }
    }

}

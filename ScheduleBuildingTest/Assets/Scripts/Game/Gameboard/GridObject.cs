using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridObject : MonoBehaviour
{

    private int _width;
    private int _height;
    private Vector3 _home;

    [SerializeField] public GameObject gridCubePrefab;
    private Color mouseOverColor = Color.magenta;
    private Color originalColor = Color.red;
    private bool dragging = false;
    private float distance;
    private Vector3 startDist;
    bool mouseOver;
    public bool isInGrid = false;

    Schedule schedule;

    private List<GridCube> cubes = new List<GridCube>();

    public void Awake()
    {
        schedule = FindObjectOfType<Schedule>();
    }

    public void init(string s, Vector3 home, Color color)
    {
        _home = home;
        transform.position = _home;
        _width = s[0] - '0';
        _height = s[1] - '0';
        originalColor = color;

        for (int h = 0; h < _height; h++)
        {
            for (int w = 0; w < _width; w++)
            {
                if (s[(2+(h*_width)+w)] == '1')
                {
                    
                    GameObject obj = Instantiate(gridCubePrefab);
                    obj.transform.parent = transform;
                    Vector3 pos = new Vector3(transform.position.x + 2*w, transform.position.y + h, transform.position.z);
                    obj.transform.position = pos;
                    GridCube newCube = obj.GetComponent<GridCube>();
                    cubes.Add(newCube);
                    
                }
            }
        }


    }
    public void mouseEnters()
    {
        foreach (GridCube gc in cubes)
            gc.transform.GetComponent<Renderer>().material.color = mouseOverColor;
    }

    public void mouseExits()
    {
        foreach (GridCube gc in cubes)
            gc.transform.GetComponent<Renderer>().material.color = originalColor;
    }

    public void mouseClick()
    {
        if (isInGrid)
        {
            foreach (GridCube gc in cubes)
            {
                gc.releaseSlot();
            }
        }
        isInGrid = false;
        transform.position -= Vector3.forward/2;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;



    }

    public void mouseRelease()
    {
        transform.position += Vector3.forward / 2;
        dragging = false;
        if (!validPosition())
            transform.position = _home;
        else
            isInGrid = true;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
        }
    }

    public bool onGrid()
    {
        return isInGrid;
    }

    public bool validPosition()
    {
        Vector3 newPosition = new Vector3(0f, 0f, 0f);
        if (Math.Abs(transform.position.x + 4f) < 0.75f) newPosition.x = -4f;
        else if (Math.Abs(transform.position.x + 2f) < 0.75f && _width < 5) newPosition.x = -2f;
        else if (Math.Abs(transform.position.x) < 0.75f && _width < 4) newPosition.x = 0f;
        else if (Math.Abs(transform.position.x - 2f) < 0.75f && _width < 3) newPosition.x = 2f;
        else if (Math.Abs(transform.position.x - 4f) < 0.75f && _width < 2) newPosition.x = 4f;
        else return false;
        if (Math.Abs(transform.position.y + 3.5f) < 0.45f) newPosition.y = -3.5f;
        else if (Math.Abs(transform.position.y + 2.5f) < 0.45f && _height < 8) newPosition.y = -2.5f;
        else if (Math.Abs(transform.position.y + 1.5f) < 0.45f && _height < 7) newPosition.y = -1.5f;
        else if (Math.Abs(transform.position.y + 0.5f) < 0.45f && _height < 6) newPosition.y = -0.5f;
        else if (Math.Abs(transform.position.y - 0.5f) < 0.45f && _height < 5) newPosition.y = 0.5f;
        else if (Math.Abs(transform.position.y - 1.5f) < 0.45f && _height < 4) newPosition.y = 1.5f;
        else if (Math.Abs(transform.position.y - 2.5f) < 0.45f && _height < 3) newPosition.y = 2.5f;
        else if (Math.Abs(transform.position.y - 3.5f) < 0.45f && _height < 2) newPosition.y = 3.5f;
        else return false;
        transform.position = newPosition;

        foreach (GridCube gc in cubes)
        {
            if (!gc.checkIfFits()) return false;
        }
        foreach (GridCube gc in cubes)
        {
            gc.occupySlot();
        }
        return true;
    }

}




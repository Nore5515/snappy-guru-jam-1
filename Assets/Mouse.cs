using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{

    public Tilemap world;
    public SAP2D.SAP2DPathfinder sapPF;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3Int mousePos = GetMousePosition();

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0))
        {
            world.SetTile(mousePos, null);
            sapPF.CalculateColliders();
        }
    }

    // :)
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return world.WorldToCell(mouseWorldPos);
    }
}

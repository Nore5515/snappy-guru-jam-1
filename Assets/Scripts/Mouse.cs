using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour
{

    public Tilemap world;
    public SAP2D.SAP2DPathfinder sapPF;
    public GameObject trap;
    public GameObject spiketrap;
    public Player player;

    public Tile dirtTile;

    public bool isSpike = false;
    public bool isTile = false;
    public bool isBomb = false;

    public Dictionary<string, bool> optionList = new Dictionary<string, bool>();
    int UILayer;

    // Start is called before the first frame update
    void Start()
    {
        UILayer = LayerMask.NameToLayer("BlockClickUI");
        optionList["isSpike"] = false;
        optionList["isTile"] = false;
        optionList["isBomb"] = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3Int mousePos = GetMousePosition();

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0) && !IsPointerOverUIElement())
        {
            world.SetTile(mousePos, null);
            sapPF.CalculateColliders();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0.0f);
            if (optionList["isSpike"])
            {
                if (player.getSouls() >= 5)
                {
                    player.setSouls(player.getSouls() - 5);
                    SpikeTrap st = Instantiate(spiketrap, newPos, Quaternion.identity).GetComponent<SpikeTrap>();
                    st.player = player;
                    sapPF.CalculateColliders();
                }
            }
            else if (optionList["isTile"])
            {
                // Debug.Log(world.GetUsedTilesCount());
                world.SetTile(mousePos, dirtTile);
            }
            else if (optionList["isBomb"])
            {
                if (player.getSouls() >= 1)
                {
                    player.setSouls(player.getSouls() - 1);
                    Trap t = Instantiate(trap, newPos, Quaternion.identity).GetComponent<Trap>();
                    t.player = player;
                    sapPF.CalculateColliders();
                }

            }
        }
    }


    // Function calls that handle what button to shop you have selected last.
    public void setOneOptionTrue(string optionName)
    {
        Debug.Log("Seting only " + optionName + " as true.");
        foreach (string key in optionList.Keys)
        {
            if (key == optionName)
            {
                optionList[key] = true;
            }
            else
            {
                optionList[key] = false;
            }
        }
    }
    public void selectingSpike()
    {
        setOneOptionTrue("isSpike");
    }
    public void selectingTile()
    {
        setOneOptionTrue("isTile");
    }
    public void selectingBomb()
    {
        setOneOptionTrue("isBomb");
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    // :)
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return world.WorldToCell(mouseWorldPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{

    public Tilemap world;
    public SAP2D.SAP2DPathfinder sapPF;
    public GameObject trap;
    public GameObject spiketrap;
    public Player player;
    
    public bool isSpike = false;

    public void isSpikeTrue(){
        isSpike = true;
    }
    public void isSpikeFalse(){
        isSpike = false;
    }

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
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0.0f);
            if (isSpike){
                if (player.getSouls() >= 5){
                    player.setSouls(player.getSouls()-5);
                SpikeTrap st = Instantiate(spiketrap, newPos, Quaternion.identity).GetComponent<SpikeTrap>();
                st.player = player;
                }
            }
            else
            {
                if (player.getSouls() >= 1){
                    player.setSouls(player.getSouls()-1);
                    Trap t = Instantiate(trap, newPos, Quaternion.identity).GetComponent<Trap>();
                    t.player = player;
                }
                
            }
        }
    }

    // :)
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return world.WorldToCell(mouseWorldPos);
    }
}

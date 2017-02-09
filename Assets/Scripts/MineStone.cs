using UnityEngine;
using System.Collections;

public class MineStone : MonoBehaviour {
    Camera camera;
    public int stones;
    float upgradeCostPick;
    float upgradeCostInventory;
    public float stonePerHit;
    public float inventorySize;
    public float mineRate = 1F;
    private float timestamp = 0F;
    private float credits;
    
    public Stone rayHit;
    public bool addStones;
    public RaycastHit hit;
    public Color textColor;

    void Start () {
        camera = GetComponent<Camera>();
        stones = 0;
        upgradeCostPick = 10F;
        upgradeCostInventory = 30F;
        stonePerHit = 1F;
        inventorySize = 10;
        credits = 0;
    }
    
    void Update () {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = camera.ScreenPointToRay(new Vector3(x, y, 0));
            if (Time.time >= timestamp && stones < inventorySize)
            {
                timestamp = Time.time + mineRate;
                
                if (Physics.Raycast(ray, out hit, 2))
                {
                    rayHit = hit.collider.GetComponentInParent<Stone>();
                    if (rayHit != null && addStones)
                    {
                        rayHit.UpdateStone();
                        rayHit.amountStones -= stonePerHit;
                    }
                }
                else
                {
                    hit = new RaycastHit();
                    rayHit = null;
                }
            }
            if(Physics.Raycast(ray, out hit, 2) && stones > 0)
            {
                if (hit.collider.GetComponentInParent<Forge>())
                {
                    stones--;
                    credits++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && credits >= upgradeCostPick)
        {
            credits -= (int)(Mathf.Floor(upgradeCostPick));
            stonePerHit += 1F;
            upgradeCostPick *= 1.1F;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && credits >= upgradeCostInventory)
        {
            credits -= (int)(Mathf.Floor(upgradeCostInventory));
            inventorySize += 10F;
            upgradeCostInventory *= 1.2F;
        }

    }
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        GUI.Label(rect, "Inventory: " + stones + "/" + inventorySize + "\nCredits: " + credits + "\n(1)Upgrade Pick: " + upgradeCostPick + "\n(2)Upgrade Inventory: " + upgradeCostInventory + "\n\nHold E at forge to turn stones into credits", style);
    }
}

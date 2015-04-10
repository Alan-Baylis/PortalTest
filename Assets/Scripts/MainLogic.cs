using UnityEngine;
using System.Collections;

public class MainLogic : MonoBehaviour {

    public Texture2D crosshair;

    private Rect screenCenter;
    private GameObject portalEntrance;
    private GameObject portalExit;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;

        screenCenter = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2, crosshair.width, crosshair.height);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void onGUI()
    {
        GUI.DrawTexture(screenCenter, crosshair);
    }

    public GameObject GetPortalEntrance()
    {
        return portalEntrance;
    }

    public void SetPortalEntrance(GameObject portal)
    {
        portalEntrance = portal;
    }

    public GameObject GetPortalExit()
    {
        return portalExit;
    }

    public void SetPortalExit(GameObject portal)
    {
        portalExit = portal;
    }

    public void DestroyPortalExit()
    {
        Destroy(portalExit);
    }

    public void DestroyPortalEntrance()
    {
        Destroy(portalEntrance);
    }
}

using UnityEngine;
using System.Collections;

public class PortalEntranceScript : MonoBehaviour
{

    private GameObject player;
    private Transform playerCamera;
    private Transform dummyRotator;
    private GameObject portalExit;
    private Transform portalExitCamera;
    private MainLogic mainLogic;

    // Use this for initialization
    void Start()
    {
        mainLogic = GameObject.Find("MainLogic").GetComponent<MainLogic>();

        if(mainLogic != null)
        {
            mainLogic.SetPortalEntrance(this.gameObject);

            portalExit = mainLogic.GetPortalExit();

            player = GameObject.Find("FPSController");
            dummyRotator = transform.FindChild("DummyRotator");

            if (portalExit)
            {
                portalExitCamera = portalExit.transform.FindChild("PortalExitCamera");

                portalExit.GetComponent<PortalExitScript>().SetPortalEntranceCamera(this.transform.FindChild("PortalEntranceCamera"));
                portalExit.GetComponent<PortalExitScript>().SetPortalEntrance(this.gameObject);
            }
        }
    }

    public void SetPortalExitCamera(Transform camera)
    {
        portalExitCamera = camera;
    }

    public void SetPortalExit(GameObject portal)
    {
        portalExit = portal;
    }

    // Update is called once per frame
    void Update()
    {
        if (portalExit != null)
        {
            Vector3 localPortalDirection = player.transform.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(localPortalDirection);

            dummyRotator.rotation = rotation;

            portalExitCamera.localRotation = dummyRotator.localRotation;
        }
    }
}
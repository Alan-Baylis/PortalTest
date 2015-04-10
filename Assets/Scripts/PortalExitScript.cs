using UnityEngine;
using System.Collections;

public class PortalExitScript : MonoBehaviour
{

    private GameObject player;
    private Transform playerCamera;
    private Transform dummyRotator;
    private GameObject portalEntrance;
    private Transform portalEntranceCamera;
    private MainLogic mainLogic;

    // Use this for initialization
    void Start()
    {
        mainLogic = GameObject.Find("MainLogic").GetComponent<MainLogic>();

        if(mainLogic != null)
        {
            mainLogic.SetPortalExit(this.gameObject);

            portalEntrance = mainLogic.GetPortalEntrance();

            player = GameObject.Find("FPSController");
            dummyRotator = transform.FindChild("DummyRotator");

            if (portalEntrance)
            {
                portalEntranceCamera = portalEntrance.transform.FindChild("PortalEntranceCamera");

                portalEntrance.GetComponent<PortalEntranceScript>().SetPortalExitCamera(this.transform.FindChild("PortalExitCamera"));
                portalEntrance.GetComponent<PortalEntranceScript>().SetPortalExit(this.gameObject);
            }
        }
    }

    public void SetPortalEntranceCamera(Transform camera)
    {
        portalEntranceCamera = camera;
    }

    public void SetPortalEntrance(GameObject portal)
    {
        portalEntrance = portal;
    }

    // Update is called once per frame
    void Update()
    {
        if (portalEntrance != null)
        {
            Vector3 localPortalDirection = player.transform.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(localPortalDirection);

            dummyRotator.rotation = rotation;

            portalEntranceCamera.localRotation = dummyRotator.localRotation;
        }
    }
}
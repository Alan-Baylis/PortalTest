using UnityEngine;
using System.Collections;

public class PortalEntranceScript : MonoBehaviour
{

    public GameObject player;
    public GameObject portalExit;
    public Camera portalExitCamera;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (portalExit != null)
        {
            Quaternion angle = Quaternion.Inverse(transform.rotation) * player.transform.rotation;

            Quaternion newAngle = angle * portalExit.transform.rotation;

            portalExitCamera.transform.localEulerAngles = new Vector3(newAngle.eulerAngles.x, newAngle.eulerAngles.y - 180, 0);

            
        }
    }
}
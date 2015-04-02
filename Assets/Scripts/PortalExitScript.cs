using UnityEngine;
using System.Collections;

public class PortalExitScript : MonoBehaviour
{

    public GameObject player;
    public GameObject portalEntrance;
    public Camera portalEntranceCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (portalEntrance != null)
        {
            Quaternion angle = Quaternion.Inverse(transform.rotation) * player.transform.rotation;

            Quaternion newAngle = angle * portalEntrance.transform.rotation;

            portalEntranceCamera.transform.localEulerAngles = new Vector3(newAngle.eulerAngles.x, newAngle.eulerAngles.y - 180, 0);
        }
    }
}
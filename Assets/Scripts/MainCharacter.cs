using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

    private Rigidbody pickedUpObject;
    private bool isHoldingObject = false;
    private float objectHoldDistance = 100.0f;
    public GameObject portalEntrancePrefab;
    public GameObject portalExitPrefab;
    public GameObject portalEntrance { get; private set; }
    public GameObject portalExit { get; private set; }
    private MainLogic mainLogic;

	// Use this for initialization
	void Start () 
    {
        mainLogic = GameObject.Find("MainLogic").GetComponent<MainLogic>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // Invert it
        layerMask = ~layerMask;

        if (Input.GetButtonDown("PickUpDrop")) 
        {
            if (isHoldingObject)
            {
                DropObject();
            }
            else
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, 200.0f, layerMask))
                {
                    if (hit.rigidbody != null)
                    {
                        PickupObject(hit.rigidbody);
                    }
                }
            }
        }
        if(Input.GetButtonDown("Fire1"))
        {
            // Makes portal entrance
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 2000.0f, layerMask))
            {
                if (hit.collider)
                {
                    mainLogic.DestroyPortalEntrance();

                    GameObject portal = Instantiate(portalEntrancePrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal)) as GameObject;

                    mainLogic.SetPortalEntrance(portal);
                }
            }
        }

        if(Input.GetButtonDown("Fire2"))
        {
            // Make portal exit
            // Makes portal entrance
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 2000.0f))
            {
                if (hit.collider)
                {
                    mainLogic.DestroyPortalExit();

                    GameObject portal = Instantiate(portalExitPrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal)) as GameObject;

                    mainLogic.SetPortalExit(portal);
                }
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 300.0f, Color.red);
	}

    void FixedUpdate()
    {
        // Update position of holding object
        if (pickedUpObject != null)
        {
            UpdatePickupObjectPosition();
        }
    }

    public void PickupObject(Rigidbody myObject)
    {
        pickedUpObject = myObject;
        pickedUpObject.useGravity = false;

        isHoldingObject = true;
    }

    private void DropObject()
    {
        pickedUpObject.useGravity = true;

        // Drops object
        pickedUpObject = null;

        isHoldingObject = false;
    }

    private void UpdatePickupObjectPosition()
    {
        pickedUpObject.MovePosition(transform.position + (transform.forward * objectHoldDistance) * Time.deltaTime);

        pickedUpObject.MoveRotation(transform.rotation);
    }
}

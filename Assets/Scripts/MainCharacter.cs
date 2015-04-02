using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

    private Rigidbody pickedUpObject;
    private bool isHoldingObject = false;
    private float objectHoldDistance = 100.0f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetButtonDown("PickUpDrop")) 
        {
            if (isHoldingObject)
            {
                DropObject();
            }
            else
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, 200.0f))
                {
                    Debug.Log(hit);
                    if (hit.rigidbody != null)
                    {
                        PickupObject(hit.rigidbody);
                    }
                }
            }
        }
        if(Input.GetButtonDown("Fire1"))
        {
            // Make portal entrance

            /**
             * Raycast to surface
             * If surface has enough space, make portal object
             * If exists, Destroy previous portal entrance
             * **/
        }

        if(Input.GetButtonDown("Fire2"))
        {
            // Make portal exit
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

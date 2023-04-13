using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    public float distance = 100;    
    public Transform pos;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    /*void On()
    {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
                //if (Physics.Raycast(ray, distance))
                {
                rb.isKinematic = true;
                rb.MovePosition(pos.position);
                }
            }
            
    }*/
    /*void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("��� ������");
        if(Physics.Raycast(ray, distance))
        {
            Debug.Log("��� ������");
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
            Debug.Log("��� ������2");
        }
    }*/
    /* void FixedUpdate()
     {
         if (rb.isKinematic == true)
         {
             this.gameObject.transform.position = pos.position;
             if (Input.GetKeyDown(KeyCode.G))
             {
                 rb.useGravity = true;
                 rb.isKinematic = false;
                 rb.AddForce(Camera.main.transform.forward * 500);
             }
         }
    RaycastHit hit;
         Debug.Log("��� ������");
         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
         {
             Debug.Log("��� ������");
             rb.isKinematic = true;
             rb.MovePosition(pos.position);
         }
     }*/

    // Update is called once per frame

    void PickUp()
    {
        RaycastHit hit;
        Debug.Log("1");
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.Log("2");
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }
    }

    void Update()
    {
        //FixedUpdate();

        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.G))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
            
    }
}

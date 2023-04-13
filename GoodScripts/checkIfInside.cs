using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfInside : MonoBehaviour
{
    public bool inside;
    public GameObject snow;

    private float randNum1;
    private float randNum2;
    private float randNum3;
    //private FindItem player;

    void Start()
    {
        inside = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            print("inside");
            inside = true;
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            spawnSnow();
            //}  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("outside");
            inside = false;
        }
    }
    void Update()
    {

    }
    void spawnSnow()
    {
        GameObject copy = Instantiate(snow);
        print("created");
        randNum1 = Random.Range(-10F, 10F);
        randNum2 = Random.Range(300F, 600F);
        randNum3 = Random.Range(-10F, 10F);
        copy.transform.position = gameObject.transform.position + new Vector3(0, 3, 0);
        
        copy.GetComponent<Rigidbody>().AddForce(randNum1, randNum2, randNum3);
        /*
        if (snow.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = snow; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = snow.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.position = holdPos.transform.position; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
        */
    }
    /*
    void spawnSnow()
    {
        if (snow.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = snow; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = snow.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.position = playerActions.holdPos.transform.position; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), playerActions.player.GetComponent<Collider>(), true);
        }
    }
    */
}

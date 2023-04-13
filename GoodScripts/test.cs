using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //private FindItem player;
    // Start is called before the first frame update
    public float lifeTime = 10F;
    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        CancelInvoke("DestroySelf");
        Invoke("DestroySelf", lifeTime);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //print(player.heldObj);
        //print(gameObject);
        //print(player.heldObj);
    }
}

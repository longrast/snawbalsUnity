using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    const float time1 = 1F;
    public float time;
    private GameObject gameObject;
    private FindItem player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject);
        if (player.heldObj == gameObject)
        {
            print("ok");
            Debug.Log(player.heldObj);
            if (gameObject == player.heldObj)
            {
                time = time1;
            }
            else if (gameObject != player.heldObj)
            {
                Destroy(gameObject, time);
            }
        }
        else
        {
            Destroy(gameObject, time);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

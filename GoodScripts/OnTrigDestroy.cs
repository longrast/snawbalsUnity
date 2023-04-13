using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigDestroy : MonoBehaviour
{
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube2")
        {
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = trans.transform.position + Vector3.forward * -1.0f;
    }
}

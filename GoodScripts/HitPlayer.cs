using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public AudioSource audio;
    public SkinnedMeshRenderer temp;
    private bool x;
    // Start is called before the first frame update
    void Start()
    {
        x = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cube1")
        {
            audio.Play();
            temp.enabled = false;
            x = true;
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((audio.isPlaying == false) && (x == true))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}

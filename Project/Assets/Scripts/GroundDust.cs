using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDust : MonoBehaviour
{
    
    public GameObject dustCloud;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag.Equals("Finish"))
        {
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
        }
    }
}

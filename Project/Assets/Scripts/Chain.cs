using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public float moveSpeed = 5f;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0 ,moveSpeed);
        }else if(other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveSpeed);
        } else{
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }
}

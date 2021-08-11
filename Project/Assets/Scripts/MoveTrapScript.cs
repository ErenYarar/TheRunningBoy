using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrapScript : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    //////////////
    private Vector2 screenBounds;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update() 
    {
        /*
        if(transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        } */
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
    }


}

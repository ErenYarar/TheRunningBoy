using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public GameObject SnowHavaHafif;
    //public GameObject SnowHavaOrta;
    //public GameObject SnowHava;
    public GameObject SnowStarHava;
    public GameObject RainHava;

    void Update()
    {
        
        transform.position -= new Vector3(6f * Time.deltaTime,0,0);
        if(transform.position.x <= -17.77)
        {
            transform.position = new Vector3 (35.54f, transform.position.y, 0f);
        }
        
        if(ScoreScript.scoreAmount >= 500)
        {
            //SoundManager.PlaySound("snow");
            SnowHavaHafif.SetActive(true);
        } 
        
        if(ScoreScript.scoreAmount >= 1000)
        {
            SnowHavaHafif.SetActive(false);
            //SnowHava.SetActive(true);
            //SnowStarHava.SetActive(true);
        } 
        if(ScoreScript.scoreAmount >= 1500)
        {    
            //SoundManager.PlaySound("rain");
            RainHava.SetActive(true);
        } 
        if(ScoreScript.scoreAmount >= 2000)
        {
            RainHava.SetActive(false);
        } 
    } 

    /*
    void TimeSkip2()
    {
        transform.position -= new Vector3(6f * Time.deltaTime,0,0);
        if(transform.position.x <= -17.77)
        {
            transform.position = new Vector3 (35.54f, transform.position.y, 0f);
        }
    } */

}

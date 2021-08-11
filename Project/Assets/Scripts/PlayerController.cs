using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    //Run, Jump
    public float moveSpeed = 5f, jumpSpeed = 13f, jumpFreq = 1f, nextJumpTime;    
    //FlipFace
    bool facingRight = true;
    //[SerializeField] Collider2D standingCollider;
    //float crouchMove = 0.5f;
    // Crouch
    [SerializeField] bool ceiled;
    public Transform ceilPoint;
    private float crouch;
    public bool crouching;
    //Jump & ground
    public bool isGrounded = false;
    public Transform onGroundCheckPosition;
    public float onGroundCheckRadius;
    public LayerMask onGroundCheckLayer;
    //Restart
    public GameObject gameOverUI;
    [SerializeField]
    private bool FinishPlane = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        FinishPlane = false;
    }

    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        ceiled = Physics2D.OverlapCircle(ceilPoint.position, onGroundCheckRadius, onGroundCheckLayer);
        playerAnimator.SetBool("IsCrouching", crouching);

        if(playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        if(playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            SoundManager.PlaySound("playerJump");
            nextJumpTime = Time.timeSinceLevelLoad + jumpFreq;
            Jump();
        }

        crouch = Input.GetAxisRaw("Crouch");
        CrouchFunction();
    }

    void CrouchFunction()
    {
        if((crouch != 0 || ceiled == true) && isGrounded == true)
        {
            crouching = true;
        }else{
            crouching = false;
        }
    }
  
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(onGroundCheckPosition.position, onGroundCheckRadius, onGroundCheckLayer);
        playerAnimator.SetBool("Jump", isGrounded);
    }

    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Respawn")
        {
            //soundManager.PlaySound("gameOver");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            FinishPlane = true;
        } 
    } 

    

}

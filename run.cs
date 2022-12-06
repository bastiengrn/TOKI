using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class run : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groudedDistance = 2f;
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] private GameObject dot;
    private SpriteRenderer spr;
    public Animator animator;  
    private Rigidbody2D rB2D;
    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    private void jump()

    {
        int nbJump = 2;
        int maxJump = 2;

        if (nbJump > 0)
        {
            nbJump--;
        }
        if (IsGrounded())
        {
            nbJump = maxJump;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rB2D.velocity = new Vector2(0, jumpForce);
            }

        }

    }

    private void move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("IsRunning", true);
            spr.flipX = false;
            transform.position = transform.position + Time.deltaTime * speed * Vector3.right;
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))

        {
            spr.flipX = true;
            animator.SetBool("IsRunning", true);

            transform.position = transform.position + Time.deltaTime * speed * Vector3.left;   
        }  
        else animator.SetBool("IsRunning", false);
        
            
        
       
    }
    

    void Awake()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groudedDistance, groundedLayer);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            dot.SetActive(true);
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed ;
    public float maxspeed = 5f;
    public float jumpforce = 9f;
    public bool tocar_suel;
    public bool alt;
    public bool doblealt;
    private bool flag;

    public Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", Math.Abs(rb2d.velocity.x));
        anim.SetBool("Tocar_suel", tocar_suel);
        if (tocar_suel) {
            doblealt = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && tocar_suel) {
            alt = true;
            
            doblealt = true;

        } else if (Input.GetKeyDown(KeyCode.UpArrow) && doblealt)
        {
            alt = true;
            doblealt = false;
        }
       
    }
    void FixedUpdate()
    {
        Vector3 freno = rb2d.velocity;
        freno.x *= 0.9f;
       
  
        float h = Input.GetAxis("Horizontal");
       if (alt ) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,0f);
            rb2d.AddForce(Vector2.up *jumpforce ,ForceMode2D.Impulse);
            alt = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
      
            rb2d.AddForce(Vector2.right * speed * h,(flag)?ForceMode2D.Force:ForceMode2D.Impulse);
            flag = true;

        } else if(flag){
            flag = false;
        }
       
            rb2d.AddForce( new Vector2 (- rb2d.velocity.x*5f,0f) );
        
       
        if (rb2d.velocity.x > maxspeed ) {
            rb2d.velocity = new Vector2(maxspeed,rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxspeed)
        {
            rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.y < -maxspeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -maxspeed);
        }
        if (rb2d.velocity.y > maxspeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxspeed);
        }
        if (h < 0.0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (h > 0.0f)
           {
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(0,0,0);  
    }
    
}

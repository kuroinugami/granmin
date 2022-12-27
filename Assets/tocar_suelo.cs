using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class tocar_suelo : MonoBehaviour
{
    public player play;
    private Rigidbody2D rb2d;
    private Vector2 force ;

    
    // Start is called before the first frame update
    void Start()
    {
        play = GetComponentInParent<player>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            rb2d.velocity = new UnityEngine.Vector2(rb2d.velocity.x, - collision.relativeVelocity.y);
           
        }
       
    }
    void OnCollisionStay2D(Collision2D collision2d){
        if (collision2d.gameObject.tag == "suelo") {
            
            play.tocar_suel = true;
        }
        if (collision2d.gameObject.tag == "plataforma")
        {
            play.transform.parent = collision2d.transform;
           
            force = new Vector2(0f, -10f);
            play.rb2d.AddForce(force);
            
            play.tocar_suel = true;
          
        }
    }
 
    void OnCollisionExit2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "suelo")
        {
            play.tocar_suel = false;
        }
        if (collision2d.gameObject.tag == "plataforma")
        {
            play.transform.parent = null;
            

            play.tocar_suel = false;
        }
    }
}
        
   



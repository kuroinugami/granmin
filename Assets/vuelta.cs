using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vuelta : MonoBehaviour
{
  public bool flag= true;
    private Rigidbody2D rb2d;
    private enemi_controler con;
    public void setflag(bool fla) {
        flag = fla;

    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        con = GetComponentInParent<enemi_controler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (flag)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
        else {
         
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        con.setrefleccontrol(true);
        flag = true;
    }
}

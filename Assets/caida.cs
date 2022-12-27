using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caida : MonoBehaviour
{
    private Transform lol;
    private Rigidbody2D rb2d;
   private Vector3 posi2;
    private PolygonCollider2D poli;
    private string nam;
    private bool flag;
    public float time1 = 1f;
    public float time2 = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
        rb2d=GetComponent<Rigidbody2D>();
        poli=GetComponent<PolygonCollider2D>();

        
        posi2 = transform.position;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
       
            if (collision.gameObject.CompareTag("Player")) {
            nam = collision.gameObject.name;
            flag = true;
            Invoke("caidad", time1);
           



        }

    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        flag = false;
    }
    void caidad() {
      
        rb2d.isKinematic = false;
        poli.isTrigger = true;
        Invoke("restablecer", time2);
        if (flag)
        {
            lol = transform.Find(nam);
            lol.parent = null;
        }


        
    }
    private void restablecer()
    {
        transform.position = posi2;
        rb2d.velocity = Vector3.zero;
        rb2d.isKinematic = true;
        poli.isTrigger = false;
       
      
        
    }
}

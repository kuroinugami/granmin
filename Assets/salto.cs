using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    private bool control =true;
    private enemi_controler sal;
    // Start is called before the first frame update
    public void setcontrol(bool flag) {
        control = flag;
    }
    void Start()
    {
        sal = GetComponentInParent<enemi_controler>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sal.setdetec(true);
            sal.sentido_d = (-Mathf.Sign(collision.transform.position.x - transform.position.x) == -1f) ? true : false;
        }
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow)&&control)
        {
            
            sal.setsalt(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sal.setdetec(false);
        }
    }
}
  

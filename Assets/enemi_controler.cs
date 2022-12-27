using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemi_controler : MonoBehaviour
{
    public float maxspeed = 5f, speed = 2f;
    private Vector3 inicio;
    public bool sentido_d;
    private float sentido;
    public float reaparicion_caida, reaparicion_muerte, retrazo=0f;


    private Rigidbody2D rb2d;
    private bool retra, Dflag = false;
    public bool Death = false;
    private Animator anim;
    private GameObject de;
   private bool salt = false,detec = false;
    private vuelta vuelta;
    private salto sa;

    // Start is called before the first frame update
    public void setsalt(bool flag) {
        salt = flag;
    
    }
    public void setdetec(bool flag)
    {
        detec = flag;

    }
    public void setrefleccontrol(bool flag)
    {
        sa.setcontrol(flag);
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sentido = (sentido_d) ? 1f : -1f;
        inicio = transform.position;
        anim = GetComponent<Animator>();
        de = GetComponent<GameObject>();
        vuelta = GetComponentInChildren<vuelta>();
        sa = GetComponentInChildren<salto>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", math.abs(rb2d.velocity.x));

    }
    private void FixedUpdate()
    {
        if (salt) {
            rb2d.AddForce(new Vector2(0f, speed * 1f), ForceMode2D.Impulse);
            vuelta.setflag(false);
            sa.setcontrol (false);
            salt = false;
        }
        if (sentido > 0.0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (sentido < 0.0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (retra) { 
        bool flag = (rb2d.velocity.x < 0.1 && rb2d.velocity.x > -0.1) ? true : false;
            if (flag)
            {
                rb2d.velocity = new Vector2(-1f * sentido, rb2d.velocity.y);
            }
            rb2d.AddForce(new Vector2(speed * sentido, rb2d.velocity.y));
            if (!detec) { sentido = (flag  ) ? -sentido : sentido; }
        rb2d.velocity = new Vector2(math.clamp(rb2d.velocity.x, -maxspeed, maxspeed), rb2d.velocity.y);
    }else { 
Invoke("retrazod", retrazo); }
    }
    void retrazod()
    {
        retra = true;
    }
    void OnBecameInvisible()
    {
        if (!Death)
        {
            Invoke("Resed", (Dflag) ? reaparicion_muerte : reaparicion_caida);
        }
        else {
            Destroy(gameObject );
           
        }
    }
    
    private void Resed()
    {
        rb2d.velocity = new Vector2(0f, 0f);
        transform.position = inicio;
    }
}

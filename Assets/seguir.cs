using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class seguir : MonoBehaviour
{
    public UnityEngine.Vector2 minposition, maxposition;
    private UnityEngine.Vector2 refle;
    private UnityEngine.Vector3 ob;
    
    public GameObject objetivo;
    public float retrazo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ob = objetivo.transform.position;
        transform.position = new UnityEngine.Vector3(
            Mathf.SmoothDamp(
                transform.position.x,
                math.clamp(ob.x,minposition.x,maxposition.x),
                ref refle.x,
                retrazo),
            Mathf.SmoothDamp(
                transform.position.y,
                math.clamp(ob.y,minposition.y,maxposition.y),
                ref refle.y,
                retrazo),
            transform.position.z);
            }
}

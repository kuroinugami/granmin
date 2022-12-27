using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Transform posi;
    public Vector3 inicio, fin;
    public float speed;

    // Start is called before the first frame update
    
    
    void Start()
    {
        
         
      
        if (posi != null) {
            posi.parent = null;
            inicio = posi.position;
            fin = transform.position;
        }
      



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float fixspeed = speed * Time.deltaTime;
        if (posi != null) {
            if (posi.position != transform.position )
            {
                transform.position = Vector3.MoveTowards(transform.position,posi.position, fixspeed);

            }
            if (posi.position == transform.position ) { 
            posi.position = (posi.position== fin ) ? inicio : fin;
            }

            

        }
    }
}

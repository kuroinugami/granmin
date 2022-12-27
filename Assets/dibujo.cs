using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dibujo : MonoBehaviour
{
    public Transform inicio;
    public Transform fin;
    private void OnDrawGizmosSelected()
    {
        if (inicio != null && fin != null )
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(inicio.position, fin.position);

        }
    }
    
}

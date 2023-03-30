using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealy : MonoBehaviour
{
    [SerializeField] private float flt_Delay;
    void Start()
    {
        Destroy(gameObject, flt_Delay);
    }

   
}

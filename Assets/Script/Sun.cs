using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
 
    void Update () 
    {
      transform.Rotate(0, -25f * Time.deltaTime,0);
    }
}
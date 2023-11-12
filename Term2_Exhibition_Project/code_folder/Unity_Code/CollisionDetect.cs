using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
      if(other.gameObject.tag == "DestrucTrig")
      {
        Destroy(other.gameObject);
      }
    }
}

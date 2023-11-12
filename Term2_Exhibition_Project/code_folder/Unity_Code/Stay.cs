using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    public GameObject movePlatform;

    private void OnTriggerStay()
    {
      movePlatform.transform.position += movePlatform.transform.forward * Time.deltaTime;
    }
}

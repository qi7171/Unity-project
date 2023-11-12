using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
  public GameObject movePlatform;

    private void OnTriggerEnter()
    {
      movePlatform.SetActive(true);
    }
}

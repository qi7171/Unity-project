using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  public GameObject movePlatform;

  private void OnTriggerExit()
  {
    movePlatform.SetActive(false);
  }
}

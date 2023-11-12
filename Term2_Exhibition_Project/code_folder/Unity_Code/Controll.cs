//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
  float x, y, b;
  void OnMessageArrived(string msg)
  {
      Debug.Log("Message arrived: " + msg);
      var array = msg.Split("|" [0]);
      x= float.Parse(array[0]);
      y= float.Parse(array[1]);
      b= float.Parse(array[2]);

      if(x > 607)
      {
        transform.position += new Vector3(0.3f, 0f, 0);
      }
      if(x < 407)
      {
        transform.position -= new Vector3(0.3f, 0f, 0);
      }


      if(y > 607)
      {
        transform.position += new Vector3(0f, 0.3f, 0);
      }
      if(y < 407)
      {
        transform.position -= new Vector3(0f, 0.3f, 0);
      }
  }


  void OnConnectionEvent(bool success)
  {
      if (success)
          Debug.Log("Connection established");
      else
          Debug.Log("Connection attempt failed or disconnection detected");
  }
}

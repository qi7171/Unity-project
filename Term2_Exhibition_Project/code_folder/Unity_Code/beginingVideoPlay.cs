using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class beginingVideoPlay : MonoBehaviour
{

    private VideoPlayer MyVideoPlayer;
    //public VideoClip videoClip;

    //myVideoPlay = gameObject.GetComponent.<VideoPlayer>();
    // Start is called before the first frame update
    private void Start()
    {
      //video player component
      MyVideoPlayer = GetComponent<VideoPlayer>();
      // assign video clip
      MyVideoPlayer.clip = Resources.Load<VideoClip>("BeginingScene");

    }
    void OnMessageArrived(string msg){
      double value = double.Parse(msg);
      if(value > 1500){

        MyVideoPlayer.Play();
      }
    }


}

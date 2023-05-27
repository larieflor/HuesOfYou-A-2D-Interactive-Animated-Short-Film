using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GameObject camera = GameObject.Find("Main Camera");
         var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
          videoPlayer.url = "Assets/video.webm";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

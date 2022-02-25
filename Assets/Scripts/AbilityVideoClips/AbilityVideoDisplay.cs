using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AbilityVideoDisplay : MonoBehaviour
{


    public VideoClip[] vids = new VideoClip[2];

    private int currentClipIndex;

    private RawImage rawImage;

    private VideoPlayer vp;

    public double time;
    public double currentTime;

    void Start()
    {
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
        vp = gameObject.GetComponent<VideoPlayer>();
        currentClipIndex = 0;
    }

   /* void Update()
    {
        if (vp.texture == null)
        {
            return;
        }
        rawImage.texture = vp.texture;
    }*/


    public GameObject panel;

    public void PlayAbilityVideo()
    {
        if(currentTime > time)
        {
            panel.SetActive(true);

        }
        else
        {
            panel.SetActive(false);
        }
       
    }
}

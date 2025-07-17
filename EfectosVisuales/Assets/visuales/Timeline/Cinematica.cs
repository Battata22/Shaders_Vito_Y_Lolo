using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cinematica : MonoBehaviour
{
    public PlayableDirector timeline;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Stop();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Play();
        }
    }
    //public PlayableDirector director;
    //public LayerMask playerLayer;
    //public GameObject controlPanel;
    ////TimelineClip clip;
    //// Start is called before the first frame update
    //void Awake()
    //{

    //    director = GetComponent<PlayableDirector>();
    //    director.played += Director_Played;
    //    director.stopped += Director_Stopped;
    //}
    //private void Director_Played(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(false);
    //}
    //private void Director_Stopped(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(true);
    //}
    //public void StartTimeLine()
    //{
    //    director.Play();
    //}
    ////private void ontriggerenter(collider other)
    ////{
    ////    if (other.gameobject.layer == 3)
    ////    {
    ////        timeline.play();
    ////    }
    ////}
    //// Update is called once per frame
    //void Update()
    //{

    //}
}

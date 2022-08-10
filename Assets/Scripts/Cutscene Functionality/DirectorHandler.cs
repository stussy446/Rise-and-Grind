using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class DirectorHandler : MonoBehaviour
{
    PlayableDirector director;

    public UnityEvent onSceneOver;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();

        if (onSceneOver == null)
        {
            onSceneOver = new UnityEvent();
        }
    }



    // Update is called once per frame
    void Update()
    {
        CheckIfSceneOver();
    }

    bool CheckIfSceneOver()
    {
        if (director.time == director.duration)
        {
            onSceneOver?.Invoke();
        }
        return true;
    }
}

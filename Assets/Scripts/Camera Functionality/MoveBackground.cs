using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        cam = GameObject.Find("MainCamera");
        startPos = transform.position.y;
    }

    void Update()
    {
        float distance = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.x, transform.position.z);
    }
}

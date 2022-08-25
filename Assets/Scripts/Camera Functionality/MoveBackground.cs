/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos;
    private GameObject MainCamera;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        startPos = transform.position.y;
    }

    void Update()
    {
        float distance = (MainCamera.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.x, transform.position.z);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionHandler : MonoBehaviour
{
    [SerializeField] int pointValue = 1;
    UIManager uiManager;

    public int GetPointValue() { return pointValue;  }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollection();
    }


    public void HandleCollection()
    {
        // do animation
        // play sound
        Debug.Log("collection handled");
        gameObject.SetActive(false);
        uiManager.UpdateScore(pointValue);
    }

    

}

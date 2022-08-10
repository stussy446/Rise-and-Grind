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
        StartCoroutine(DelaySingleton());
    }

    IEnumerator DelaySingleton()
    {
        yield return new WaitForSeconds(.25f);
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
        gameObject.SetActive(false);
        uiManager.UpdateScore(pointValue);
    }

    

}

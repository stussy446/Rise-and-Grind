using System.Collections;
using UnityEngine;

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
        yield return new WaitForSeconds(.5f);
        uiManager = FindObjectOfType<UIManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollection();
    }


    public void HandleCollection()
    {
        SoundManager.instance.Play("Collectible");
        gameObject.SetActive(false);
        uiManager.UpdateScore(pointValue);
    }
    
}

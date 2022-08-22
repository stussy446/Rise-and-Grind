using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] Image arrowUpImage;
    [SerializeField] float arrowDisableDelay = 3f;
    bool isHorizontal = false;

    private void Start()
    {
        StartCoroutine(DisableUpArrow());
    }

    IEnumerator DisableUpArrow()
    {
        arrowUpImage.enabled = true;
        if (isHorizontal)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(arrowDisableDelay);
        arrowUpImage.enabled = false;
     
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            isHorizontal = true;
            arrowUpImage.rectTransform.Rotate(0, 0, -90);
            StartCoroutine(DisableUpArrow());

        }
    }
}

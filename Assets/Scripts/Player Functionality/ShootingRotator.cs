using UnityEngine;

public class ShootingRotator : MonoBehaviour
{
    private Vector3 mousePos;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject crossHairs;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crossHairs.transform.position = new Vector2(mousePos.x, mousePos.y);

        Vector3 difference = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRotator : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    private Vector3 touchPos;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject crossHairs;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            crossHairs.transform.position = new Vector2(mousePos.x, mousePos.y);

            Vector3 difference = mousePos - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z));
            crossHairs.transform.position = new Vector2(touch.position.x, touch.position.y);

            Vector3 difference = (Vector3)touch.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
       

}


using UnityEngine;

public class BrownBeanAnimator : MonoBehaviour
{
    Transform beanTransform;
    float startingYPos;
    float maxY;
    float minY;
    bool isMovingUp = true;

    [SerializeField] float animationSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        beanTransform = GetComponent<Transform>();
        startingYPos = beanTransform.position.y;
        maxY = startingYPos + 0.25f;
        minY = startingYPos - 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (beanTransform.position.y < maxY && isMovingUp)
        {
            MoveBeanUp();
        }
        else if (beanTransform.position.y > minY && !isMovingUp)
        {
            MoveBeanDown();
        }

        IsMovingUp();
    }

    void MoveBeanUp()
    {
        beanTransform.position += Vector3.up * animationSpeed * Time.deltaTime;
    }

    void MoveBeanDown()
    {
        beanTransform.position += Vector3.down * animationSpeed * Time.deltaTime;

    }

    void IsMovingUp()
    {
        if (beanTransform.position.y >= maxY && isMovingUp == true)
        {
            isMovingUp = false;
        }
        else if(beanTransform.position.y <= minY && isMovingUp == false)
        {
            isMovingUp = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenBossSM : MonoBehaviour
{
    KarenStatePattern karenUpdateStateTo;

    // Start is called before the first frame update
    void Start()
    {
        karenUpdateStateTo = gameObject.AddComponent<KarenStatePattern>();
        
    }

    // Update is called once per frame
    void Update()
    {
        KarenMove();
        KarenAttack();
    }

    void KarenMove()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            karenUpdateStateTo.Moving();
        }
    }

    void KarenAttack()
    {
        if (Input.GetKey(KeyCode.L))
        {
            karenUpdateStateTo.Attacking();
        }
    }
}

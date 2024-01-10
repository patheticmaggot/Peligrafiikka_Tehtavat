using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumBottleActivator : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                anim.SetTrigger("Active");
            }
        }
    }
}

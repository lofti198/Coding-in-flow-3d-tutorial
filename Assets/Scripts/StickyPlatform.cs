using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
           
            // transform.position = target.position;
            // https://answers.unity.com/questions/187317/a-child-object-that-inherits-only-position-from-pa.html

            // collision.gameObject.transform.parent = transform.parent;
//transform.localPosition = Vector3.zero или transform.position = parent.position

            collision.gameObject.transform.SetParent(transform,true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}

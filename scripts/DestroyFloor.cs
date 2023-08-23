using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyFloor : MonoBehaviour
{
    [SerializeField] AudioSource floordestroysound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "floor (3)")
        {
            Destroy(other.gameObject);
            floordestroysound.Play();
        }
    }
}

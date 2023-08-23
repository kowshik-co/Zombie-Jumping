using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{

    bool dead = false;

    [SerializeField] AudioSource deathsound;
    private void Update()
    {
        if (transform.position.y < -2.5f && !dead)
        {
            death();
            
        }
    }

    public GameObject deactiveobject;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            death();
        }
    }

    void death()
    {
        /*gameObject.SetActiveRecursively(false);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;*/

        Invoke(nameof(reload), 0.8f);
        dead = true;
        deathsound.Play();
    }

    void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

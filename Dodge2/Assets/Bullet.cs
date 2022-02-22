using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigdbody;

    void Start()
    {
        bulletRigdbody = GetComponent<Rigidbody>();
        bulletRigdbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
     void OnTriggerEnter(Collider other)
    {
        PlayerCotroller playerCotroller = other.GetComponent<PlayerCotroller>();


        if (playerCotroller != null)
        {
            playerCotroller.Die();
        }
    }


}

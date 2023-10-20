using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float lifespan;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right;
        Destroy(gameObject, lifespan);
    }
}
    
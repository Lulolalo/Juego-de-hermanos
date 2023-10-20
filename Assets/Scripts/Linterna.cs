using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private float vertical;
    private float horizontal;
    [SerializeField]
    private float rotate;

    private Rigidbody2D rb;
    public Transform shootingPosition;
    public float velocidadRotacion = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        Debug.Log(direction);
        //rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
        shootingPosition.localPosition = direction;
        Debug.Log(rotate);
        rb.MoveRotation(rb.rotation + rotate * rotationSpeed * Time.fixedDeltaTime);
    }


}
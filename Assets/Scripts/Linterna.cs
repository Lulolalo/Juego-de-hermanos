using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Linterna : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    private float vertical;
    private float horizontal;
    [SerializeField]
    private Quaternion targetRotation;

    private Rigidbody2D rb;
    public Transform shootingPosition;
    public float velocidadRotacion = 5f;
    public Rigidbody2D player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    //private void FixedUpdate()
    //{
    //    //Vector2 direction = shootingPosition.transform.position - transform.position;
    //    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    //    //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    //    Quaternion rotation = transform.rotation;
    //    rotation = Quaternion.Euler(0f, 0f, rb.rotation);
    //    Vector3 direction = shootingPosition.transform.position;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    targetRotation = Quaternion.LookRotation(Vector3.forward, shootingPosition.position - player.transform.position);
    //    rb.position = player.position;
    //    rb.MoveRotation(Quaternion.LerpUnclamped(rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
    //}

    private void FixedUpdate()
    {
        //Quaternion rotation = transform.rotation;
       Quaternion rotation = Quaternion.Euler(0f, 0f, rb.rotation);
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0f, 0f, angle);
        rb.position = player.position;
        rb.MoveRotation(Quaternion.RotateTowards(rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
    }


    private void OnTriggerEnter2D(Collider2D Other)
    {
        SeguimientoEnemigo seguimientoEnemigo = Other.GetComponent<SeguimientoEnemigo>();
        if ( seguimientoEnemigo != null)
        {
            seguimientoEnemigo.RecibirDaño(10);
        }
        EnemigoDivide enemigoDivide = Other.GetComponent<EnemigoDivide>();
        if ( enemigoDivide != null )
        {
            enemigoDivide.Recibirdamage(10);
        }

    }

    

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform shootingPosition;

    private Rigidbody2D rb;

    private float vertical;
    private float horizontal;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float shootCooldown;

    private float cooldown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical != 0 || horizontal != 0)
        {
            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            shootingPosition.localPosition = direction;
            shootingPosition.right = direction;
        }

        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                cooldown = shootCooldown;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);

                /*RaycastHit2D raycastHit2D = Physics2D.Raycast(
                    shootingPosition.position,
                    shootingPosition.right,
                    float.PositiveInfinity,
                    Physics2D.AllLayers
                );
                if (raycastHit2D.collider != null)
                {
                    PatrollingEnemy enemy = raycastHit2D.collider.GetComponent<PatrollingEnemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(1);
                    }
                }*/
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }
}
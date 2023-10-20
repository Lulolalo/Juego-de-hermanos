using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorguitoMovimiento : MonoBehaviour
{
    
    public int maxHealth = 100; // Vida máxima del jugador
    public int currentHealth;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform shootingPosition;



    private Rigidbody2D rb;

    private float vertical;
    private float horizontal;
    private float rotate;
    [SerializeField]
    private GameObject linternaPJ;
    /*void Start()
    //{
        //currentHealth = maxHealth; // Inicializa la vida actual a la máxima al comienzo
    }
    */

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce la vida por la cantidad de daño recibido

        if (currentHealth <= 0)
        {
            Die(); // Si la vida llega a cero o menos, llama a la función Die
        }
        Debug.Log("Recibi daño");
    }

    // Método para manejar la muerte del jugador
    void Die()
    {
        // Puedes agregar aquí acciones como reproducir una animación de muerte, mostrar un mensaje de Game Over, reiniciar el nivel, etc.
        Debug.Log("¡El jugador ha muerto!");
        // Aquí podrías reiniciar el nivel, desactivar el personaje, mostrar un mensaje de Game Over, etc.
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        //if (Input.GetKey(KeyCode.Q))
        //    rotate = -1;
        //else if (Input.GetKey(KeyCode.E))
        //    rotate = 1;
        //else
        //    rotate = 0;
        //linternaPJ.transform.rotation = Quaternion.LookRotation(Input.acceleration.normalized, Vector3.up);

    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
        shootingPosition.localPosition = direction;
        rb.MoveRotation(rb.rotation + rotate * rotationSpeed * Time.fixedDeltaTime);
    }
}
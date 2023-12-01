using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    Animator animator;
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
            animator.SetBool("IsDead", true);
            Die(); // Si la vida llega a cero o menos, llama a la función Die
        }
        Debug.Log("Recibi daño");
    }

    // Método para manejar la muerte del jugador
    void Die()
    {
        
        Debug.Log("¡El jugador ha muerto!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    animator.SetBool("IsDead", true);
        //}

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

    private void LateUpdate()
    {
        animator.SetFloat("AxisX", horizontal);
        animator.SetFloat("AxisY", vertical);
        if (horizontal == 0 &&  vertical == 0)
        {
            animator.SetBool("IsMoving",false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }
}
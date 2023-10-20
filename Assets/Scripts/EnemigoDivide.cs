using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDivide : MonoBehaviour
{
    public GameObject Enemigo;
    public Transform jugador;
    public float velocidad = 5f;
    public float rangoSpawn = 10f;


    public int maxHealth = 20;
    public int currentHealth;

    void Update()
    {
        if (jugador == null)
            return;


        // Calcula la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);

    }
    public void Recibirdamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Dividir();
        }

    }

    void Dividir()
    {
        Vector3 posicionSpawn = transform.position + new Vector3(Random.Range(-rangoSpawn, rangoSpawn), 0, Random.Range(-rangoSpawn, rangoSpawn));
        Instantiate(Enemigo, posicionSpawn, Quaternion.identity);
        Instantiate(Enemigo, posicionSpawn, Quaternion.identity);
    }
}

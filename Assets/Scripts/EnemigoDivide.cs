using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDivide : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 5f;
    public GameObject enemigoPrefab;  // Prefab del enemigo a generar al morir
    public int cantidadDeNuevosEnemigos = 2;  // Cantidad de nuevos enemigos a generar

    void Update()
    {
        if (jugador == null)
            return;


        // Calcula la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Mueve al enemigo en la dirección del jugador
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
    void Morir()
    {
        for (int i = 0; i < cantidadDeNuevosEnemigos; i++)
        {
            // Genera un nuevo enemigo en una posición cercana al enemigo que murió
            Vector3 nuevaPosicion = transform.position + Random.insideUnitSphere;
            Instantiate(enemigoPrefab, nuevaPosicion, Quaternion.identity);
        }

        // Destruye el enemigo actual
        Destroy(gameObject);
    }
}

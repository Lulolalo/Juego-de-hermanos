using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideEnemigo : MonoBehaviour
{
    public GameObject enemigoPrefab;  // Prefab del enemigo a generar al morir
    public int cantidadDeNuevosEnemigos = 2;  // Cantidad de nuevos enemigos a generar

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
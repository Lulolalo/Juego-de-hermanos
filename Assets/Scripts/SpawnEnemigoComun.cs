using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigoComun : MonoBehaviour
{
    public Transform jugador;
    public SeguimientoEnemigo Enemigo;
    public float tiempoEntreSpawns = 3f;
    public float rangoSpawn = 10f;

    private float tiempoUltimoSpawn;

    void Start()
    {
        tiempoUltimoSpawn = Time.time;
    }

    void Update()
    {
        if (Time.time - tiempoUltimoSpawn > tiempoEntreSpawns)
        {
            SpawnearEnemigo();
            tiempoUltimoSpawn = Time.time;
        }
    }

    void SpawnearEnemigo()
    {
        Vector3 posicionSpawn = transform.position + new Vector3(Random.Range(-rangoSpawn, rangoSpawn), 0, Random.Range(-rangoSpawn, rangoSpawn));
        SeguimientoEnemigo enemigo = Instantiate(Enemigo, posicionSpawn, Quaternion.identity);
        enemigo.jugador = jugador;
    }
}

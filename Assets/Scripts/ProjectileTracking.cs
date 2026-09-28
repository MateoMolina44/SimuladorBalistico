using System.Collections.Generic;
using UnityEngine;

public class ProjectileTracking : MonoBehaviour
{
    private Vector3 startPosition;
    private float startTime;
    private bool hasHitGround = false;
    private bool acierto = false;
    private HashSet<GameObject> objetosGolpeados = new HashSet<GameObject>();

    [HideInInspector] public float anguloX, anguloY, anguloZ, fuerzaDisparo, masaDisparo;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        TargetCube cubo = collision.gameObject.GetComponent<TargetCube>();
        if (cubo != null)
        {
            acierto = true;
            objetosGolpeados.Add(collision.gameObject);
        }

        if (hasHitGround) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            hasHitGround = true;

            float distancia = Vector3.Distance(startPosition, transform.position);
            float tiempoVuelo = Time.time - startTime;

            DisparoData data = new DisparoData
            {
                numero = RegistroDisparos.Instance.CantidadDisparos() + 1,
                anguloX = anguloX,
                anguloY = anguloY,
                anguloZ = anguloZ,
                fuerza = fuerzaDisparo,
                masa = masaDisparo,
                distancia = distancia,
                tiempoVuelo = tiempoVuelo,
                acierto = acierto,
                objetosAfectados = objetosGolpeados.Count
            };

            RegistroDisparos.Instance.RegistrarDisparo(data);
        }
    }
}
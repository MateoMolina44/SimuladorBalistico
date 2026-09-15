using UnityEngine;

public class ProjectileTracking : MonoBehaviour
{
    private Vector3 startPosition;
    private float startTime;
    private bool hasHitGround = false;

    [HideInInspector] public float anguloX, anguloY, anguloZ, fuerzaDisparo, masaDisparo;

    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
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
                distancia = distancia,
                tiempoVuelo = tiempoVuelo,
                masa = masaDisparo
            };

            RegistroDisparos.Instance.RegistrarDisparo(data);
        }
    }
}

using UnityEngine;

public class TargetCube : MonoBehaviour
{
    [SerializeField]
    private float anguloDerribo = 45f;

    private bool derribado = false;

    void Update()
    {
        if (derribado) return;

        float angulo = Vector3.Angle(transform.up, Vector3.up);

        if (angulo > anguloDerribo)
        {
            derribado = true;
            RegistroDisparos.Instance.CuboDerribado();
        }
    }
}
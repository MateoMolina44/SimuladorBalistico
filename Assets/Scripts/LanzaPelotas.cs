using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{

    [SerializeField]
    Transform SpawnPoint;

    [SerializeField]
    GameObject Proyectil;

    [SerializeField]
    Slider ForceSlider;

    [SerializeField]
    float Force = 1f;

    [SerializeField]
    TextMeshProUGUI ForceText;

    [SerializeField]
    Slider angleSliderY;

    [SerializeField]
    Slider angleSliderZ;

    [SerializeField]
    TextMeshProUGUI angleTextY;

    [SerializeField]
    TextMeshProUGUI angleTextZ;

    [SerializeField]
    TextMeshProUGUI angleText;

    [SerializeField]
    Slider massSlider;

    [SerializeField]
    TextMeshProUGUI massText;

    [SerializeField]
    float Mass = 1f;

    void Start()
    {
        massSlider.value = Mass;
        massText.text = "Masa: " + Mass.ToString("F1") + " kg";

        ForceSlider.value = Force;
        ForceText.text = "Fuerza: " + Force.ToString("F1");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Disparar();
            }
        }
    }

    private void Disparar()
    {
        GameObject newProyectil = Instantiate(Proyectil, SpawnPoint.position, SpawnPoint.rotation);
        newProyectil.GetComponent<Rigidbody>().AddForce(SpawnPoint.up * Force, ForceMode.Impulse);
        Rigidbody rb = newProyectil.GetComponent<Rigidbody>();

        rb.mass = Mass;
        rb.AddForce(SpawnPoint.up * Force, ForceMode.Impulse);

        ProjectileTracking pelotaScript = newProyectil.GetComponent<ProjectileTracking>();
        if (pelotaScript != null)
        {
            pelotaScript.anguloY = angleSliderY.value;
            pelotaScript.anguloZ = angleSliderZ.value;
            pelotaScript.fuerzaDisparo = Force;
            pelotaScript.masaDisparo = Mass;
        }

        Destroy(newProyectil, 5f);
    }

    public void ChangeForce()
    {
        Force = ForceSlider.value;
        ForceText.text = "Fuerza: " + Force.ToString("F1");
    }

    public void ChangeAngleY()
    {
        UpdateRotation();
        angleTextY.text = "Y: " + angleSliderY.value.ToString("F1") + "°";
    }

    public void ChangeAngleZ()
    {
        UpdateRotation();
        angleTextZ.text = "Z: " + angleSliderZ.value.ToString("F1") + "°";
    }

    private void UpdateRotation()
    {
        float y = angleSliderY.value;
        float z = angleSliderZ.value;

        transform.rotation = Quaternion.Euler(0, y, z);
    }
    public void ChangeMass()
    {
        Mass = massSlider.value;
        massText.text = "Masa: " + Mass.ToString("F1") + " kg";
    }
}

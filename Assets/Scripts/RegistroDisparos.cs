using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegistroDisparos : MonoBehaviour
{
    public static RegistroDisparos Instance;

    [SerializeField]
    TextMeshProUGUI historialText;

    [SerializeField]
    TextMeshProUGUI historialGuardadoText;

    private int cubosDerribados = 0;

    public int CubosDerribados => cubosDerribados;

    private List<DisparoData> historial = new List<DisparoData>();

    void Awake()
    {
        Instance = this;
    }

    public int CantidadDisparos()
    {
        return historial.Count;
    }

    public async void RegistrarDisparo(DisparoData data)
    {
        historial.Add(data);
        ActualizarTexto();

        await CloudSaveManager.Instance.GuardarDisparo(data);
    }

    public void CuboDerribado()
    {
        cubosDerribados++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        string texto = "Cubos derribados: " + cubosDerribados + "\n";

        foreach (var d in historial)
        {
            texto += "\n" + "#" + d.numero +
                " | X:" + d.anguloX.ToString("F1") + "° Y:" + d.anguloY.ToString("F1") + "° Z:" + d.anguloZ.ToString("F1") +
                "° F:" + d.fuerza.ToString("F1") +
                " M:" + d.masa.ToString("F1") + "kg" +
                " | Dist: " + d.distancia.ToString("F2") + "m" +
                " | T: " + d.tiempoVuelo.ToString("F2") + "s\n";
        }

        historialText.text = texto;

        LayoutRebuilder.ForceRebuildLayoutImmediate(historialText.rectTransform.parent.GetComponent<RectTransform>());
    }

    public async void MostrarHistorialGuardado()
    {
        List<DisparoData> guardados = await CloudSaveManager.Instance.CargarHistorial();

        string texto = "Resultados guardados (" + guardados.Count + "):\n\n";

        foreach (var d in guardados)
        {
            texto += "#" + d.numero +
                " | X:" + d.anguloX.ToString("F1") + "° Y:" + d.anguloY.ToString("F1") + "° Z:" + d.anguloZ.ToString("F1") +
                "° F:" + d.fuerza.ToString("F1") +
                " M:" + d.masa.ToString("F1") + "kg" +
                " | Dist: " + d.distancia.ToString("F2") + "m" +
                " | T: " + d.tiempoVuelo.ToString("F2") + "s" +
                " | " + (d.acierto ? "Acierto" : "Fallo") +
                " | Obj: " + d.objetosAfectados + "\n";
        }

        historialGuardadoText.text = texto;
        LayoutRebuilder.ForceRebuildLayoutImmediate(historialGuardadoText.rectTransform.parent.GetComponent<RectTransform>());
    }

    public async void BorrarHistorialGuardado()
    {
        await CloudSaveManager.Instance.BorrarHistorial();
        historialGuardadoText.text = "Resultados guardados (0):";
    }
}
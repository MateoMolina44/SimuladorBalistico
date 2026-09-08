using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegistroDisparos : MonoBehaviour
{
    public static RegistroDisparos Instance;

    [SerializeField]
    TextMeshProUGUI historialText;

    private List<DisparoData> historial = new List<DisparoData>();

    void Awake()
    {
        Instance = this;
    }

    public int CantidadDisparos()
    {
        return historial.Count;
    }

    public void RegistrarDisparo(DisparoData data)
    {
        historial.Add(data);
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        string texto = "";

        foreach (var d in historial)
        {
            texto += "#" + d.numero +
                " | X:" + d.anguloX.ToString("F1") + "° Y:" + d.anguloY.ToString("F1") + "° Z:" + d.anguloZ.ToString("F1") +
                "° F:" + d.fuerza.ToString("F1") +
                " | Dist: " + d.distancia.ToString("F2") + "m" +
                " | T: " + d.tiempoVuelo.ToString("F2") + "s\n";
        }

        historialText.text = texto;

        LayoutRebuilder.ForceRebuildLayoutImmediate(historialText.rectTransform.parent.GetComponent<RectTransform>());
    }
}
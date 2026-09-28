using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSaveManager : MonoBehaviour
{
    public static CloudSaveManager Instance;

    private const string KEY_HISTORIAL = "historialDisparos";

    void Awake()
    {
        Instance = this;
    }

    public async Task GuardarDisparo(DisparoData nuevoDisparo)
    {
        try
        {
            List<DisparoData> historial = await CargarHistorial();
            historial.Add(nuevoDisparo);

            var data = new Dictionary<string, object>
            {
                { KEY_HISTORIAL, historial }
            };

            await CloudSaveService.Instance.Data.Player.SaveAsync(data);
            Debug.Log("Disparo guardado en UGS Cloud Save.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error guardando en Cloud Save: " + e.Message);
        }
    }

    public async Task BorrarHistorial()
    {
        try
        {
            await CloudSaveService.Instance.Data.Player.DeleteAsync(KEY_HISTORIAL);
            Debug.Log("Historial de Cloud Save borrado.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error borrando historial: " + e.Message);
        }
    }

    public async Task<List<DisparoData>> CargarHistorial()
    {
        try
        {
            var claves = new HashSet<string> { KEY_HISTORIAL };
            var resultado = await CloudSaveService.Instance.Data.Player.LoadAsync(claves);

            if (resultado.TryGetValue(KEY_HISTORIAL, out var item))
            {
                return item.Value.GetAs<List<DisparoData>>();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error cargando desde Cloud Save: " + e.Message);
        }

        return new List<DisparoData>();
    }
}
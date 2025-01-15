using UnityEngine;

public class TestUI : MonoBehaviour
{
    public ResourceManager manager;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.B)) Debug.Log("Tecla B presionada: Agregar cerveza");
        if (Input.GetKeyDown(KeyCode.N)) Debug.Log("Tecla N presionada: Quitar cerveza");
        if (Input.GetKeyDown(KeyCode.C)) Debug.Log("Tecla C presionada: Agregar cigarro");
        if (Input.GetKeyDown(KeyCode.M)) Debug.Log("Tecla M presionada: Quitar cigarro");

        // Incrementar cervezas con "B"
        if (Input.GetKeyDown(KeyCode.B))
        {
            manager.AddResource(0, 1);
            Debug.Log("+ Cerveza");
        }

        // Decrementar cervezas con "N"
        if (Input.GetKeyDown(KeyCode.N))
        {
            manager.RemoveResource(0, 1);
            Debug.Log("- Cerveza");
        }

        // Incrementar cigarros con "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            manager.AddResource(1, 1);
            Debug.Log("+ Cigarro");
        }

        // Decrementar cigarros con "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            manager.RemoveResource(1, 1);
            Debug.Log("- Cigarro");
        }
    }
}

using UnityEngine;

public class TestUI : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.B)) Debug.Log("Tecla B presionada: Agregar cerveza");
        if (Input.GetKeyDown(KeyCode.N)) Debug.Log("Tecla N presionada: Quitar cerveza");
        if (Input.GetKeyDown(KeyCode.C)) Debug.Log("Tecla C presionada: Agregar cigarro");
        if (Input.GetKeyDown(KeyCode.M)) Debug.Log("Tecla M presionada: Quitar cigarro");

        // Incrementar cervezas con "B"
        if (Input.GetKeyDown(KeyCode.B))
        {
            ResourceManager.instance.AddResource("Beer", 1);
            Debug.Log("+ Cerveza");
        }

        // Decrementar cervezas con "N"
        if (Input.GetKeyDown(KeyCode.N))
        {
            ResourceManager.instance.RemoveResource("Beer", 1);
            Debug.Log("- Cerveza");
        }

        // Incrementar cigarros con "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResourceManager.instance.AddResource("Cigar", 1);
            Debug.Log("+ Cigarro");
        }

        // Decrementar cigarros con "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            ResourceManager.instance.RemoveResource("Cigar", 1);
            Debug.Log("- Cigarro");
        }
    }
}

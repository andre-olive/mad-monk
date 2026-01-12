using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            // Em runtime, busca inclusive objetos desativados
            _instance = FindObjectOfType<T>(true);

            if (_instance == null)
                Debug.LogError($"Nenhuma instância de {typeof(T)} foi encontrada na cena.");

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
            _instance = this as T;
        else if (_instance != this)
        {
            Debug.LogWarning($"Mais de uma instância de {typeof(T)} foi encontrada. Esta será destruída.");
            Destroy(this);
        }
    }
}

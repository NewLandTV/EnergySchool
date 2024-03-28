using UnityEngine;

public class DontDestroyOnLoadUI : MonoBehaviour
{
    public static DontDestroyOnLoadUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

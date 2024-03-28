using UnityEngine;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<Game>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}

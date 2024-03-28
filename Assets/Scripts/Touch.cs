using System.Collections;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static Touch instance;

    [SerializeField]
    private Canvas dontDestroyOnLoadUI;
    [SerializeField]
    private RectTransform touchEffectRectTransform;

    private Camera mainCamera;

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

        mainCamera = Camera.main;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            // Detect touch and play touch sound.
            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.instance.PlaySFX("Touch");
            }

            // Show touch effect.
            touchEffectRectTransform.position = Input.mousePosition;

            touchEffectRectTransform.gameObject.SetActive(Input.GetMouseButton(0));

            yield return null;
        }
    }
}

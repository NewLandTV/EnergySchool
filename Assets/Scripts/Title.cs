using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject startButton;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    public void OnStartButtonClick()
    {
        startButton.SetActive(false);

        Loading.instance.LoadScene(Scenes.Game);
    }
}

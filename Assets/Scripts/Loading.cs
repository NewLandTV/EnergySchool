using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    EmptyScene = 0,
    Title = 1,
    Game = 2
}

public enum Maps
{
    Game = 2,
    IserionAlley = 3,
    ErergySchool_MainBuilding_Right = 4
}

public class Loading : MonoBehaviour
{
    public static Loading instance;

    // Progress bar, Progress text, loaded text.
    [SerializeField]
    private GameObject progressBarGroup;
    [SerializeField]
    private Image progressBarImage;
    [SerializeField]
    private TextMeshProUGUI progressText;
    [SerializeField]
    private GameObject loadedText;

    // Progress gradient color.
    [SerializeField]
    private Gradient progressBarGradient;

    // Animators
    [SerializeField]
    private Animator loadingAnimator;

    private Color originProgressBarColor;

    // Last loaded scene.
    private Scene lastLoadedScene;

    private int loadingAnimatorStartTrigger;
    private int loadingAnimatorEndTrigger;

    // WaitForSeconds
    private WaitForSeconds waitTime1_5f;

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

        originProgressBarColor = progressBarImage.color;

        loadingAnimatorStartTrigger = Animator.StringToHash("Start");
        loadingAnimatorEndTrigger = Animator.StringToHash("End");

        waitTime1_5f = new WaitForSeconds(1.5f);
    }

    public void LoadScene(Scenes scene)
    {
        StartCoroutine(LoadSceneCoroutine(scene));
    }

    public void LoadMap(Maps map)
    {
        StartCoroutine(LoadMapCoroutine(map));
    }

    public void UnloadMap(Maps map)
    {
        StartCoroutine(UnloadMapCoroutine(map));
    }

    private IEnumerator LoadSceneCoroutine(Scenes scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)scene);

        asyncOperation.allowSceneActivation = false;

        loadingAnimator.gameObject.SetActive(true);
        loadingAnimator.SetTrigger(loadingAnimatorStartTrigger);
        progressBarGroup.SetActive(true);

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress < 0.9f)
            {
                progressBarImage.fillAmount = asyncOperation.progress;
                progressText.text = $"{Mathf.RoundToInt(asyncOperation.progress * 100f)}%";
                progressBarImage.color = progressBarGradient.Evaluate(asyncOperation.progress);
            }
            else
            {
                float timer = 0;

                while (timer < 1f)
                {
                    float value = Mathf.Lerp(0.9f, 1f, timer);

                    progressBarImage.fillAmount = value;
                    progressText.text = $"{Mathf.RoundToInt(value * 100f)}%";
                    progressBarImage.color = progressBarGradient.Evaluate(value);

                    timer += Time.unscaledDeltaTime;

                    yield return null;
                }

                asyncOperation.allowSceneActivation = true;

                progressBarGroup.SetActive(false);
                loadedText.SetActive(true);

                progressBarImage.fillAmount = 0f;
                progressText.text = string.Empty;
                progressBarImage.color = originProgressBarColor;

                yield return waitTime1_5f;

                loadingAnimator.SetTrigger(loadingAnimatorEndTrigger);

                yield return waitTime1_5f;

                loadedText.SetActive(false);
                loadingAnimator.gameObject.SetActive(false);

                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator LoadMapCoroutine(Maps map)
    {
        Scene targetScene = SceneManager.GetSceneByBuildIndex((int)map);

        if (!targetScene.isLoaded)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)map, LoadSceneMode.Additive);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            lastLoadedScene = SceneManager.GetSceneByBuildIndex((int)map);
        }
    }

    private IEnumerator UnloadMapCoroutine(Maps map)
    {
        Scene targetScene = SceneManager.GetSceneByBuildIndex((int)map);

        if (targetScene.isLoaded)
        {
            if (lastLoadedScene.buildIndex != (int)map)
            {
                SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("Game"), lastLoadedScene);
            }

            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(targetScene);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}

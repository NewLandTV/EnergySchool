using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    [SerializeField]
    private GameObject talkGroup;
    [SerializeField]
    private TextMeshProUGUI talkText;

    [SerializeField]
    private int cps;

    private bool isTalking;

    private WaitForSeconds waitTimeCPS;

    private void Awake()
    {
        waitTimeCPS = new WaitForSeconds(cps / 1000.0f);
    }

    public void Talk(string[] data)
    {
        if (isTalking)
        {
            return;
        }

        isTalking = true;

        talkGroup.SetActive(true);

        StartCoroutine(TalkCoroutine(data));
    }

    private IEnumerator TalkCoroutine(string[] data)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    talkText.text = data[i];

                    yield return waitTimeCPS;

                    break;
                }

                stringBuilder.Append(data[i][j]);

                talkText.text = stringBuilder.ToString();

                yield return waitTimeCPS;
            }

            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }

            yield return null;

            stringBuilder.Clear();
        }

        talkGroup.SetActive(false);

        isTalking = false;
    }
}

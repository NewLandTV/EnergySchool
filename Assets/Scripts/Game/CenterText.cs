using TMPro;
using UnityEngine;

public class CenterText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void SetText(string message)
    {
        text.text = message;
    }
}

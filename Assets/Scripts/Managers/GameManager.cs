using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;

    private void Awake()
    {
        // TODO Load saved data.
    }

    private IEnumerator Start()
    {
        while (true)
        {
            UpdateUI();

            yield return null;
        }
    }

    private void UpdateUI()
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }

    #region FPS
    private float deltaTime;private int fpsSize=25;private bool isShow;private void Update(){deltaTime+=(Time.unscaledDeltaTime-deltaTime)*0.1f;if(Input.GetKeyDown(KeyCode.F1))isShow=!isShow;}private void OnGUI(){if (isShow){GUIStyle style=new GUIStyle();Rect rect=new Rect(30f,30f,Screen.width,Screen.height);style.alignment=TextAnchor.UpperLeft;style.fontSize=fpsSize;style.normal.textColor=Color.green;float ms=deltaTime*1000f;float fps=1.0f/deltaTime;string text=string.Format("{0:0.} FPS ({1:0.0} ms)",fps,ms);GUI.Label(rect,text,style);}}
    #endregion
}

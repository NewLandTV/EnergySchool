using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject settingScreen;

    public void ControlSettingScreenActive(bool active)
    {
        settingScreen.SetActive(active);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] controlLButtonSprite;
    [SerializeField]
    private Sprite[] controlRButtonSprite;
    [SerializeField]
    private Image controlLButtonImage;
    [SerializeField]
    private Image controlRButtonImage;

    public void SetControlLButtonSprite(bool pointerDown)
    {
        controlLButtonImage.sprite = controlLButtonSprite[pointerDown ? 1 : 0];
    }

    public void SetControlRButtonSprite(bool pointerDown)
    {
        controlRButtonImage.sprite = controlRButtonSprite[pointerDown ? 1 : 0];
    }
}

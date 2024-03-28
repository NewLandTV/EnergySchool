using UnityEngine;

public class MapTurningPoint : MonoBehaviour
{
    [SerializeField]
    private Maps target;
    [SerializeField]
    private bool leftLoadRightUnload;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>().flipX == leftLoadRightUnload)
        {
            Loading.instance.UnloadMap(target);
        }
        else
        {
            Loading.instance.LoadMap(target);
        }
    }
}

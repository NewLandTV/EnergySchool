using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // follow x position and follow y position flag.
    [SerializeField]
    private bool x;
    [SerializeField]
    private bool y;

    [SerializeField]
    private Transform target;

    private IEnumerator Start()
    {
        while (true)
        {
            if (target)
            {
                transform.position = new Vector3(x ? target.position.x : transform.position.x, y ? target.position.y : transform.position.y, transform.position.z);
            }

            yield return null;
        }
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector tutorialTimelinePlayable;

    public void ShowTutorialTimelinw()
    {
        tutorialTimelinePlayable.gameObject.SetActive(true);
        tutorialTimelinePlayable.Play();
    }
}

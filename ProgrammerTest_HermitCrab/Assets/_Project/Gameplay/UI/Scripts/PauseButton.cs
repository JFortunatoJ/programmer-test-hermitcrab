using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        DataEvent.DataEvent.Notify(new OnGamePauseEvent(true));
    }
}

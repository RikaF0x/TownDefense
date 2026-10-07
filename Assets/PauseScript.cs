using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] Button pauseButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(ChangePaused);
    }

    private void ChangePaused()
    {
        isPaused = !isPaused;
    }
}

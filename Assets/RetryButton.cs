using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    [SerializeField] Button retryButton;

    private void Awake()
    {
        retryButton.onClick.AddListener(LoadGame);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}

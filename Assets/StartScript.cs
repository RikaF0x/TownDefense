using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    [SerializeField] Button startButton;
    private void Awake()
    {
        startButton.onClick.AddListener(StartF);
    }

    private void StartF()
    {
        SceneManager.LoadScene(1);
    }
}

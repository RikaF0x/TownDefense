using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EatSystem : MonoBehaviour
{
    [SerializeField] private Image EatBar;
    [SerializeField] private float EatDuration;
    [SerializeField] private FoodSystem foodS;
    [SerializeField] private UnitSystem UnitS;
    [SerializeField] private int KnightE;
    [SerializeField] private int VillageE;
    [SerializeField] private PauseScript pauseS;
    private float _currT;

    private void Update()
    {
        if (!pauseS.isPaused)
        {
            EatUpdate();
        }
    }
    private void EatUpdate()
    {
        if (_currT/EatDuration < 1)
        {
            EatBar.fillAmount = _currT/EatDuration;
            _currT += Time.deltaTime;
        }
        else
        {
            _currT = 0;
            EatBar.fillAmount = 0;
            foodS.food -= UnitS.villager*VillageE + UnitS.knight*KnightE;
            foodS.TextUpdate();
            if (foodS.food <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}

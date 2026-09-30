using UnityEngine;
using UnityEngine.UI;

public class EatSystem : MonoBehaviour
{
    [SerializeField] private Image EatBar;
    [SerializeField] private float EatDuration;
    [SerializeField] private FoodSystem foodS;
    [SerializeField] private UnitSystem UnitS;
    [SerializeField] private int KnightE;
    [SerializeField] private int VillageE;
    private float _currT;

    private void Update()
    {
        EatUpdate();
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
            foodS.food -= UnitS.Villager*VillageE + UnitS.Knight*KnightE;
            foodS.TextUpdate();
        }
    }
}

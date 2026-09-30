using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodSystem : MonoBehaviour
{
    [SerializeField] private Image FoodBar;
    [SerializeField] private float FoodDuration;
    [SerializeField] private TextMeshProUGUI FoodText;
    [SerializeField] private UnitSystem UnitS;
    [SerializeField] private int VillageF;
    public int food = 0;
    
    private float _currT = 0;
    private void Awake()
    {
        _currT = 0;
    }

    private void Update()
    {
        FoodUpdate();
    }
    public void TextUpdate()
    {
        FoodText.text = $"Food: {food}";
        FoodBar.fillAmount = _currT/FoodDuration;
    }

    private void FoodUpdate()
    {
        if (_currT/FoodDuration < 1)
        {
            FoodBar.fillAmount = _currT/FoodDuration;
            _currT += Time.deltaTime;
        }
        else
        {
            _currT = 0;
            FoodBar.fillAmount = 0;
            food += UnitS.Villager*VillageF;
            TextUpdate();
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UnitSystem : MonoBehaviour
{
    [SerializeField] private FoodSystem foodS;
    [FormerlySerializedAs("BuyV")] [SerializeField] private Button buyV;
    [FormerlySerializedAs("BuyK")] [SerializeField] private Button buyK;
    [FormerlySerializedAs("PriceV")] [SerializeField] private int priceV;
    [FormerlySerializedAs("PriceK")] [SerializeField] private int priceK;
    [FormerlySerializedAs("VillageC")] [SerializeField] private TextMeshProUGUI villageC;
    [FormerlySerializedAs("KnightC")] [SerializeField] private TextMeshProUGUI knightC;
    [FormerlySerializedAs("VillageBar")] [SerializeField] private Image villageBar;
    [SerializeField] private Image knightBar;
    [SerializeField] private float durationV;
    [SerializeField] private float durationK;
    [FormerlySerializedAs("Villager")] public int villager;
    [FormerlySerializedAs("Knight")] public int knight;
    private float _currentTimeV;
    private float _currentTimeK;
    private int _villageT;
    private int _knightT;
    private void Awake()
    {
        buyV.onClick.AddListener(OnClickV);
        buyK.onClick.AddListener(OnClickK);
    }

    private void Update()
    {
        if (_villageT == 1|| _knightT == 1)
        {
            TimerRun();
        }
    }

    private void OnClickV()
    {
        _villageT = 1;
    }

    private void OnClickK()
    {
        _knightT = 1;
    }

    private void BuyVSystem()
    {
        if (foodS.food >= priceV)
        {
            villager++;
            foodS.food -= priceV;
            foodS.TextUpdate();
            villageC.text = $"Villager: {villager}";
            _villageT = 0;
        }
    }
    private void BuyKSystem()
    {
        if (foodS.food >= priceK)
        {
            knight++;
            foodS.food -= priceK;
            foodS.TextUpdate();
            knightC.text = $"Knight: {knight}";
            _knightT = 0;
        }
        
    }
    public void ColUpdate()
    {
        knightC.text = $"Knight: {knight}";
        villageC.text = $"Villager: {villager}";
    }

    private void TimerRun()
    {
        _currentTimeV += Time.deltaTime * _villageT;
        _currentTimeK += Time.deltaTime * _knightT;
        villageBar.fillAmount = _currentTimeV / durationV;
        knightBar.fillAmount = _currentTimeK / durationK;
        if (_currentTimeV / durationV >= 1)
        {
            BuyVSystem();
            _currentTimeV = 0;
            
            villageBar.fillAmount = 0;
        }
        if (_currentTimeK / durationK >= 1)
        {
            BuyKSystem();
            _currentTimeK = 0;
            
            knightBar.fillAmount = 0;
        }
    }
}

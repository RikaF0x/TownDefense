using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitSystem : MonoBehaviour
{
    [SerializeField] private FoodSystem foodS;
    [SerializeField] private Button BuyV;
    [SerializeField] private Button BuyK;
    [SerializeField] private int PriceV;
    [SerializeField] private int PriceK;
    [SerializeField] private TextMeshProUGUI VillageC;
    [SerializeField] private TextMeshProUGUI KnightC;
    public int Villager;
    public int Knight;

    private void Awake()
    {
        BuyV.onClick.AddListener(BuyVSystem);
        BuyK.onClick.AddListener(BuyKSystem);
    }

    private void Update()
    {
        //foodS.food -= Villager;
    }

    private void BuyVSystem()
    {
        if (foodS.food >= PriceV)
        {
            Villager++;
            foodS.food -= PriceV;
            foodS.TextUpdate();
            VillageC.text = $"Villager: {Villager}";
        }
    }
    private void BuyKSystem()
    {
        if (foodS.food >= PriceK)
        {
            Knight++;
            foodS.food -= PriceK;
            foodS.TextUpdate();
            KnightC.text = $"Knight: {Knight}";
        }
        
    }
}

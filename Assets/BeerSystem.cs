using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeerSystem : MonoBehaviour
{
    [SerializeField] private UnitSystem UnitS;
    [SerializeField] private FoodSystem foodS;
    [SerializeField] private Button buyBtn;
    [SerializeField] private TextMeshProUGUI beerCol;
    [SerializeField] private int beerMnoz;
    [SerializeField] private float vDur;
    [SerializeField] private float kDur;
    public int beer = 0;
    [SerializeField] private Button buyDuration;
    private void Awake()
    {
        buyBtn.onClick.AddListener(Makebeer);
        buyDuration.onClick.AddListener(DurationDec);
    }

    private void Makebeer()
    {
        (beer, foodS.food) = (beer + beerMnoz, foodS.food - beerMnoz);
        UpdateBeerText();
    }
    private void UpdateBeerText()
    {
        beerCol.text = $"Beer: {beer}";
    }
    public void UpdateBeerBtn()
    {
        buyBtn.interactable = foodS.food >= beerMnoz;
        buyDuration.interactable = beer >= beerMnoz;
    }

    public void Update()
    {
        UpdateBeerBtn();
    }

    private void DurationDec()
    {
        UnitS.durationK *= vDur;
        UnitS.durationV *= kDur;
        beer -= beerMnoz;
        UpdateBeerText();
    }
}

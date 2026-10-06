using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] private UnitSystem UnitS;
    [SerializeField] private Image EnemyBar;
    [SerializeField] private float duration;
    [SerializeField] private int enemy_C;
    [SerializeField] private int mnozK;
    [SerializeField] private int mnozV;
    [SerializeField] private TextMeshProUGUI enemy_text;    
    private float _currT;
    private void Awake()
    {
        _currT = 0;
    }
    private void Update()
    {
        EnemyUpdate();
    }
    private void EnemyUpdate()
    {
        if (_currT/duration < 1)
        {
            EnemyBar.fillAmount = _currT / duration;
            _currT += Time.deltaTime;
        }
        else
        {
            UnitKilled();
            enemy_C = enemy_C*enemy_C;
            _currT = 0;
            EnemyBar.fillAmount = 0;
            enemy_text.text = $"Enemy: {enemy_C}";
        }
    }
    private void UnitKilled()
    {
        if (UnitS.Knight >= enemy_C*mnozK)
        {
            UnitS.Knight -= enemy_C*mnozK;
        }
        else
        {
            UnitS.Knight = 0;
            UnitS.Villager -= (enemy_C - UnitS.Knight/mnozK)*mnozV;
        }
        if (UnitS.Villager <= 0)
        {
            Application.Quit();
        }
        UnitS.ColUpdate();
    }
}

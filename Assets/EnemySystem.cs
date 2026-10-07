using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private PauseScript pauseS;
    [SerializeField] private int enemyModifier;
    private float _currT;
    private void Awake()
    {
        _currT = 0;
    }
    private void Update()
    {
        if (!pauseS.isPaused)
        {
            EnemyUpdate();
        }
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
            enemy_C = enemy_C*enemyModifier;
            _currT = 0;
            EnemyBar.fillAmount = 0;
            enemy_text.text = $"Enemy: {enemy_C}";
        }
    }
    private void UnitKilled()
    {
        if (UnitS.knight >= enemy_C*mnozK)
        {
            UnitS.knight -= enemy_C*mnozK;
        }
        else
        {
            UnitS.knight = 0;
            UnitS.villager -= (enemy_C - UnitS.knight/mnozK)*mnozV;
        }
        if (UnitS.villager <= 0)
        {
            SceneManager.LoadScene(2);
        }
        UnitS.ColUpdate();
    }
}

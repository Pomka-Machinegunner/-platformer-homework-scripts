using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timer;
    [SerializeField] Image _foreGround;
    [SerializeField] Image _backGround;


    public void StartCharge()
    {
        _backGround.color = new Color(1, 1, 1, 0.2f);
        _foreGround.enabled = true;
        _timer.enabled = true;
    }

    public void StopCharge()
    {
        _backGround.color = new Color(1, 1, 1, 1f);
        _foreGround.enabled = false;
        _timer.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreGround.fillAmount = currentCharge/maxCharge;
        _timer.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}


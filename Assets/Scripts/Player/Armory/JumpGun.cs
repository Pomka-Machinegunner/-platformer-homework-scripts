using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRigibody;
    [SerializeField] float _jumpSpeed = 5f;
    [SerializeField] Transform _spawn;
    [SerializeField] Guns _revolver;
    [SerializeField] float _maxCharge;
    [SerializeField] float _currentCharge =3f;
    [SerializeField] bool _isCharged;
    [SerializeField] ChargeIcon _chargeIcon;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRigibody.AddForce(-_spawn.forward * _jumpSpeed, ForceMode.VelocityChange);
                //_revolver.Shoot();
                _isCharged = false;
                _currentCharge = 0;
                _chargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            _chargeIcon.SetChargeValue(_currentCharge, _maxCharge);
            if (_currentCharge >= _maxCharge)
            {
                _isCharged = true;
                _chargeIcon.StopCharge();
            }
        }
        
    }
}

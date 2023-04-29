using UnityEngine;

enum RopeState
{
    Disable,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] Hook _hook;
    [SerializeField] Transform _spawn;
    [SerializeField] float _speed = 15f;
    SpringJoint _spring;
    [SerializeField] float _length;
    [SerializeField] RopeState _currentRopeState;
    [SerializeField] RopeRenderer _ropeRenderer;
    [SerializeField] PlayerMove _playerMove;

    private void Update()
    {
        if(Input.GetMouseButtonDown(2)) Shot();
        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_spawn.position, _hook.transform.position);
            if (distance > 20)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disable;
                _ropeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active)
            {
                if (_playerMove._playerGrounded == false)
                {
                    _playerMove.Jump();
                }
            }
            DestroySpring();
        }
        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
        {
            _ropeRenderer.Draw(_spawn.position, _hook.transform.position, _length);
        }
    }

    void Shot()
    {
        if (_spring) Destroy(_spring);
        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;
        _currentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (_spring == null)
        {
            _spring = gameObject.AddComponent<SpringJoint>();
            _spring.autoConfigureConnectedAnchor = false;
            _spring.connectedBody = _hook.Rigidbody;
            _spring.anchor = Vector3.zero;
            _spring.spring = 100f;
            _spring.damper = 5f;
            _length = Vector3.Distance(_spawn.transform.position, _hook.transform.position);
            _spring.maxDistance = _length;
            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (_spring)
        {
            Destroy(_spring);
            _currentRopeState = RopeState.Disable;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}

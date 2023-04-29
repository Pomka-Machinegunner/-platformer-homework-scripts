using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform _playerHead;
    [SerializeField] Transform _playerHeadTarget;
    [SerializeField] PhysicMaterial _playerOnWallMaterial;
    [SerializeField] PhysicMaterial _playerMaterial;
    [SerializeField] Vector3 _playerPosition;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] float _playerSpeed;
    [SerializeField] float _friction;
    [SerializeField] float _playerJumpPower;
    [SerializeField] float _playerJumpCount = 0;
    [SerializeField] float _playerGravity;
    [SerializeField] bool _playerOnWall;
    public bool _playerGrounded;
    [SerializeField] float _playerMaxSpeed;
    [SerializeField] float _lerpRate;
    Vector3 _startPosition;
    int _jumpFrameCounter = 0;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        PlayerMoveAxisY();
        PlayerWallGrab();
        PlayerRestart();
        PlayerSidDown();
        HeadMoveTotarget();

        if (_playerGrounded)
        {
            _playerPosition = transform.position;
        }
    }

    void FixedUpdate()
    {
        PlayerMoveAxisX();
        BodyRotation();
        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            _playerRigidbody.freezeRotation = false;
            _playerRigidbody.AddRelativeTorque(0, 0, 5f, ForceMode.VelocityChange);
        }
    }



    void HeadMoveTotarget()
    {
        _playerHead.position = _playerHeadTarget.position;
    }

    void PlayerSidDown()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.GetChild(0).transform.localScale = Vector3.Lerp(transform.GetChild(0).transform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 5f);
        }
        else
        {
            transform.GetChild(0).transform.localScale = Vector3.Lerp(transform.GetChild(0).transform.localScale, new Vector3(1, 1f, 1), Time.deltaTime * 5f);
        }
    }

    void PlayerRestart()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = _startPosition;
        }
    }
    void PlayerMoveAxisX()
    {
        float move = Input.GetAxis("Horizontal");
        if (_playerRigidbody.velocity.x > 10 && move != 0)
        {
            move = Mathf.Clamp(move, -1f, 0f);
        }
        if (_playerRigidbody.velocity.x < -10 && move != 0)
        {
            move = Mathf.Clamp(move, 0f, 1f);
        }

        _playerRigidbody.AddForce(move * _playerSpeed * _playerMaxSpeed, 0, 0, ForceMode.Acceleration);
        if (_playerGrounded)
        {
            _playerRigidbody.AddForce(-_playerRigidbody.velocity.x * _friction, 0, 0, ForceMode.Acceleration);
            _playerMaxSpeed = 1f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 35f);
        }
        else
        {
            _playerMaxSpeed = 0.5f;
        }

    }

    void PlayerMoveAxisY()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _playerJumpCount < 1)
        {
            Jump();
            _playerJumpCount += 1;
        }

    }

    public void Jump()
    {
        _playerRigidbody.AddForce(0, _playerJumpPower, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    void PlayerWallGrab()
    {
        if (Input.GetAxis("Horizontal") != 0 && _playerOnWall)
        {
            transform.GetChild(0).GetComponent<Collider>().sharedMaterial = _playerOnWallMaterial;
        }
        else
        {
            transform.GetChild(0).GetComponent<Collider>().sharedMaterial = _playerMaterial;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            float anle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (anle < 45)
            {
                _playerGrounded = true;
                _playerRigidbody.freezeRotation = true;
                _playerJumpCount = 0;
            }
            else
            {
                _playerOnWall = true;
            }
        }
    }

    void BodyRotation()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime * _lerpRate);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -45, 0), Time.deltaTime * _lerpRate);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _playerGrounded = false;
    }
}

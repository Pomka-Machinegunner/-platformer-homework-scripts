using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 _rotateVector;
    void Update()
    {
        transform.Rotate(_rotateVector * Time.deltaTime,Space.Self);
    }
}

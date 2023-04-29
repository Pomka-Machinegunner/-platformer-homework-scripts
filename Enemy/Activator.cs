using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> _objectToActivate = new List<ActivateByDistance>();
    [SerializeField] Transform _transformPlayer;

    private void Update()
    {
        for (int i = 0; i < _objectToActivate.Count; i++)
        {
            _objectToActivate[i].CheckDistance(_transformPlayer.position);
        }
    }

}

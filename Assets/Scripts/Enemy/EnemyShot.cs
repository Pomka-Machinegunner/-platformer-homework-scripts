using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] Animator _shotAnim;
    [SerializeField] string _shotName = "Distance";

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _shotAnim.SetTrigger(_shotName);
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _shotAnim.ResetTrigger(_shotName);
            Debug.Log("Exit");
        }
    }
}

using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] Guns[] _guns;
    [SerializeField] int _currentGun;
    void Start()
    {
        TakeGunByIndex(_currentGun);
    }

    public void TakeGunByIndex(int index)
    {
        _currentGun = index;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == index)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int indexOfBullets)
    {
        _guns[gunIndex].AddBullets(indexOfBullets);
    }
}
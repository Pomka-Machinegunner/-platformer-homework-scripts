using UnityEngine;

public class ButchProjectileCreator : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform[] _spawn;

    [ContextMenu("Create")]
    public void ProjectileSpawn()
    {
        for (int i = 0; i < _spawn.Length; i++)
        {
            Instantiate(_projectilePrefab, _spawn[i].position, _spawn[i].rotation);
        }
    }

}

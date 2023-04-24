using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _spawn;

    public void ProjectileSpawn()
    {
        Instantiate(_projectilePrefab, _spawn.position, _spawn.rotation);
    }

}

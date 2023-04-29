using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        TimeScaler();
    }

    void TimeScaler()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1;
        }

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StarTime()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}

using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer _ropeLine;
    [SerializeField] int _ropeSegments = 10;

    public void Draw(Vector3 a, Vector3 b, float lenth)
    {
        _ropeLine.enabled = true;

        float inerpolant = Vector3.Distance(a, b) / lenth;
        float offset = Mathf.Lerp(lenth / 2, 0f, inerpolant);

        Vector3 c = a + Vector3.down * offset;
        Vector3 d = b + Vector3.down * offset;

        _ropeLine.positionCount = _ropeSegments + 1;
        for (int i = 0; i < _ropeSegments + 1; i++)
        {
            _ropeLine.SetPosition(i, Bezier.GetPoint(a, c, d, b, (float)i / _ropeSegments));
        }

    }

    public void Hide()
    {
        _ropeLine.enabled = false;
    }
}

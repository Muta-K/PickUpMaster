using UnityEngine;

public class JumpSceneGameraController : MonoBehaviour
{
    [SerializeField] private Transform _BallTransform;

    public Vector3 _ViewPosition = new Vector3(0, 2, -6.5f);

    void Update()
    {
        transform.position = _BallTransform.position + _ViewPosition;
    }
}

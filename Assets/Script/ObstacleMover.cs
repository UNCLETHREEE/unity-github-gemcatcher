using UnityEngine;
using Cysharp.Threading.Tasks;

public class ObstacleMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public float height = 1f;

    [Header("Timing")]
    public float startDelay = 0f;
    public float moveDuration = 2f;
    public float pauseDuration = 4f;

    private Vector3 startPosition;
    private bool isMoving = false;
    private float localStartTime = 0f;
    private bool isDestroyed = false;

    void Start()
    {
        Debug.Log("ObstacleMover started.");
        startPosition = transform.position;
        StartMovementCycle().Forget();
    }

    private void OnDestroy()
    {
        isDestroyed = true;
    }

    async UniTaskVoid StartMovementCycle()
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(startDelay));

        while (true)
        {
            if (isDestroyed) return;

            isMoving = true;
            localStartTime = Time.time;

            await UniTask.Delay(System.TimeSpan.FromSeconds(moveDuration));
            if (isDestroyed) return;

            isMoving = false;
            transform.position = startPosition;

            await UniTask.Delay(System.TimeSpan.FromSeconds(pauseDuration));
            if (isDestroyed) return;
        }
    }

    void Update()
    {
        if (isMoving && !isDestroyed)
        {
            MoveObstacle();
        }
    }

    public void MoveObstacle()
    {
        float elapsed = Time.time - localStartTime;
        float newY = startPosition.y + Mathf.Sin(elapsed * speed) * height;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}

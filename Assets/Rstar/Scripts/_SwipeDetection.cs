using System.Collections;
using UnityEngine;

public class _SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField,Range(0f,1f)]
    private float directionThreshold = .9f;
    [SerializeField]
    private GameObject trail; 

    private _InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    private Coroutine coroutine;

    public enum SwipeDirectionType
    {
        Up,
        Down,
        Left,
        Right
    }

    public SwipeDirectionType swipeDirectionType;
    public bool isSwiped;

    private void Awake()
    {
        inputManager = _InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        trail.SetActive(true);
        trail.transform.position = Utils.ScreenToWorld(Camera.main, position);
        coroutine = StartCoroutine("Trail");
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = Utils.ScreenToWorld(Camera.main, inputManager.PrimaryPosition());
            yield return null;
        }
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime) 
        {
            Debug.Log("Swipe Detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 3f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            isSwiped = true;
            swipeDirectionType = SwipeDirectionType.Up;
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            isSwiped = true;
            swipeDirectionType = SwipeDirectionType.Down;
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            isSwiped = true;
            swipeDirectionType = SwipeDirectionType.Left;
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            isSwiped = true;
            swipeDirectionType = SwipeDirectionType.Right;
        }
    }
}

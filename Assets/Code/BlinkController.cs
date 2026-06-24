using UnityEngine;
using System.Collections;

public class BlinkController : MonoBehaviour
{
    private Animator animator;

    private static readonly int BlinkHash = Animator.StringToHash("Blink");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(2f, 5f);

            yield return new WaitForSeconds(waitTime);

            animator.SetTrigger(BlinkHash);
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
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
            float waitTime = Random.Range(3f, 8f);

            yield return new WaitForSeconds(waitTime);

            animator.SetTrigger(BlinkHash);
        }
    }
}

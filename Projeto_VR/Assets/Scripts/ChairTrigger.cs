using UnityEngine;

public class ChairTrigger : MonoBehaviour
{
    private Animator meuAnimator;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();
        Debug.Log("✅ ChairTrigger iniciado!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meuAnimator?.SetBool("isPlayerNear", true);
            Debug.Log("👤 Player entrou - isPlayerNear = TRUE");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meuAnimator?.SetBool("isPlayerNear", false);
            Debug.Log("👤 Player saiu - isPlayerNear = FALSE");
        }
    }
}
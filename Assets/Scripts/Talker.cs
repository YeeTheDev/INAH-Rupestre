using System.Collections;
using UnityEngine;
using INAH.Rupestre.Interactions;

public class Talker : Interactable
{
    [SerializeField] float rotateTime;
    [SerializeField] Transform meshTransform;
    [SerializeField] string[] dialogues;

    int currentDialogue;
    bool rotated;

    private void Awake() => priority = 1;

    public override bool Interact(Transform player)
    {
        if (!rotated) { StartCoroutine(LookAtPlayer(player)); return true; }

        bool talkState = Talk();
        if (!talkState)
        {
            rotated = false;
            currentDialogue = 0;
        }

        return talkState;
    }

    private IEnumerator LookAtPlayer(Transform player)
    {
        float time = 0;
        Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

        while (time < rotateTime)
        {
            time += Time.deltaTime;
            meshTransform.rotation = Quaternion.Lerp(meshTransform.rotation, lookRotation, time / rotateTime);

            yield return new WaitForEndOfFrame();
        }

        rotated = true;

        Talk();
    }

    private bool Talk()
    {
        if (currentDialogue < dialogues.Length) { Debug.Log(dialogues[currentDialogue]); }
        currentDialogue++;

        return currentDialogue <= dialogues.Length;
    }
}

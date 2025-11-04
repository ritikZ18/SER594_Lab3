using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range = 6f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press E to talk
        {
            Debug.Log("E pressed");
            //if (DialogueSystem.Instance.isDialogueActive) return;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log("Hit: " + hit.collider.name);


                var single = hit.collider.GetComponentInParent<NPC_SingleLine>();
                var quest = hit.collider.GetComponentInParent<NPC_QuestGiver>();


                if (single != null)
                {
                    Debug.Log("Talking to single NPC");
                    single.TriggerDialouge();
                }
                else if (quest != null) {
                    Debug.Log("Talking to quest NPC");
                    quest.TriggerDialouge();
                }
            }
                else
                {
                    Debug.Log("Raycast hit nothing");
                }
        }
    }
}

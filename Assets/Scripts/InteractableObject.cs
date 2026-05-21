using UnityEngine;

public class InteractableObject : MonoBehaviour

{

    public string interactionMessage = "You interacted with the object.";

    public void Interact()

    {

        Debug.Log(interactionMessage);

    }

}
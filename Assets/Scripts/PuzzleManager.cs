using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public TextMeshProUGUI hourglassText;
    public TextMeshProUGUI coffeeCupText;
    public TextMeshProUGUI vaseText;
    public TextMeshProUGUI lampText;

    private bool hasHourglass = false;
    private bool hasCoffeeCup = false;
    private bool hasVase = false;
    private bool hasLamp = false;

    public void CollectObject(string objectId)
    {
        if (objectId == "hourglass")
        {
            hasHourglass = true;
            hourglassText.text = "[✓] Hourglass  -  T";
        }
        else if (objectId == "coffee")
        {
            hasCoffeeCup = true;
            coffeeCupText.text = "[✓] Coffee Cup  -  O";
        }
        else if (objectId == "vase")
        {
            hasVase = true;
            vaseText.text = "[✓] Vase  -  N";
        }
        else if (objectId == "lamp")
        {
            hasLamp = true;
            lampText.text = "[✓] Standing Lamp  -  Y";
        }

        CheckPuzzleComplete();
    }

    void CheckPuzzleComplete()
    {
        if (hasHourglass && hasCoffeeCup && hasVase && hasLamp)
        {
            Debug.Log("All objects collected. Letters unlocked: T O N Y");
        }
    }
}
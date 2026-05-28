using UnityEngine;

public class NotebookUIManager : MonoBehaviour
{
    public GameObject notebookPanel;
    public PlayerController playerController;
    public GameObject notebookButton;
    private bool isOpen = false;

   void Start()

{

    notebookPanel.SetActive(false);

    if (notebookButton != null)

    {

        notebookButton.SetActive(false);

    }

    Cursor.lockState = CursorLockMode.Locked;

    Cursor.visible = false;

}

  void Update()

{

    if (Input.GetKeyDown(KeyCode.N))

    {

        OpenNotebook();

    }

    if (isOpen && Input.GetKeyDown(KeyCode.Escape))

    {

        CloseNotebook();

    }

}
    public void OpenNotebook()
    {
        isOpen = true;
        notebookPanel.SetActive(true);

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseNotebook()
    {
        isOpen = false;
        notebookPanel.SetActive(false);

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
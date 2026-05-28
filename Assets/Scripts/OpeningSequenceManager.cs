using System.Collections;

using UnityEngine;

public class OpeningSequenceManager : MonoBehaviour

{

    public Camera openingCamera;

    public Camera playerCamera;

    public PlayerController playerController;

    public GameObject characterModel;

    public float openingDuration = 3f;

    void Start()

    {

        StartCoroutine(PlayOpening());

    }

    IEnumerator PlayOpening()

    {

        openingCamera.gameObject.SetActive(true);

        playerCamera.gameObject.SetActive(false);

        playerController.enabled = false;

        if (characterModel != null)

        {

            characterModel.SetActive(true);

        }

        yield return new WaitForSeconds(openingDuration);

        if (characterModel != null)

        {

            characterModel.SetActive(false);

        }

        openingCamera.gameObject.SetActive(false);

        playerCamera.gameObject.SetActive(true);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }

}
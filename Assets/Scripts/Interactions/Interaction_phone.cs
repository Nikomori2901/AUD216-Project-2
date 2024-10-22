using UnityEngine;
using TMPro;
using AK.Wwise;

public class Interaction_phone : MonoBehaviour
{
    public string eventName;
    public string textToDisplay;
    public GameObject interactUI;
    public GameObject phoneHandSet;
    public GameObject phoneRinging; // This can be null for phones that don't need ringing
    public TextMeshProUGUI interactText;
    private bool playerInRange = false;
    private bool phoneHandSetEnabled = false;
    public int transitionDuration = 0;

    private void Start()
    {
        if (interactUI != null)
        {
            interactUI.SetActive(false);
        }

        // Register this game object with Wwise
        AkSoundEngine.RegisterGameObj(gameObject);
        //Debug.Log($"Registered phone object: {gameObject.name} (ID: {gameObject.GetInstanceID()})");

        // Register phoneRinging object if it exists
        if (phoneRinging != null)
        {
            AkSoundEngine.RegisterGameObj(phoneRinging);
            //Debug.Log($"Registered phone ringing object: {phoneRinging.name} (ID: {phoneRinging.GetInstanceID()})");
        }
    }

    private void OnDestroy()
    {
        // Unregister this game object from Wwise when destroyed
        AkSoundEngine.UnregisterGameObj(gameObject);
        //Debug.Log($"Unregistered phone object: {gameObject.name} (ID: {gameObject.GetInstanceID()})");

        // Unregister phoneRinging object if it exists
        if (phoneRinging != null)
        {
            AkSoundEngine.UnregisterGameObj(phoneRinging);
            //Debug.Log($"Unregistered phone ringing object: {phoneRinging.name} (ID: {phoneRinging.GetInstanceID()})");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StopAudioFile();
            PlayPhoneAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactUI != null)
            {
                interactUI.SetActive(true);
                if (interactText != null)
                {
                    interactText.text = textToDisplay;
                }
   
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactUI != null)
            {
                interactUI.SetActive(false);
            }
        }
    }

    private void PlayPhoneAudio()
    {
        if (gameObject != null && gameObject.activeInHierarchy)
        {
            //Debug.Log($"Playing audio event: {eventName} on game object: {gameObject.name} (ID: {gameObject.GetInstanceID()})");
            AkSoundEngine.PostEvent(eventName, gameObject);
        }
        else
        {
            Debug.LogWarning($"Cannot play audio event: {eventName}. Game object is null or inactive.");
        }
    }

    private void StopAudioFile()
    {
        if (phoneRinging != null)
        {
            AkAmbient akAmbient = phoneRinging.GetComponent<AkAmbient>();
            if (akAmbient != null)
            {
                //Debug.Log($"Stopping audio on: {phoneRinging.name} (ID: {phoneRinging.GetInstanceID()})");
                akAmbient.Stop(transitionDuration);
            }
            else
            {
                Debug.LogWarning($"AkAmbient component not found on the phoneRinging object: {phoneRinging.name}");
            }
        }
        else
        {
            Debug.Log("No phoneRinging object set for this phone. Skipping audio stop.");
        }
    }
}

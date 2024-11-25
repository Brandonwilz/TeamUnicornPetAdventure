using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Player_Sounds : MonoBehaviour {
    [SerializeField] private Player_Movement playerMovement = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private float movementSoundInterval = 1f;
    [SerializeField] private float movementSoundVolume = 0.5f;
    [SerializeField] private float damageSoundVolume = 1f;

    private List<AudioClip> movementSounds = new List<AudioClip>();
    private List<AudioClip> damageSounds = new List<AudioClip>();

    private bool isMovementSoundLocked = false;

    void Start() {
        movementSounds.Add(Resources.Load("Sounds/Ninja Cat Footsteps/Ninja Cat foot slide 1") as AudioClip);
        movementSounds.Add(Resources.Load("Sounds/Ninja Cat Footsteps/Ninja cat footstep 2") as AudioClip);
        movementSounds.Add(Resources.Load("Sounds/Ninja Cat Footsteps/Ninja cat footstep 3") as AudioClip);
        movementSounds.Add(Resources.Load("Sounds/Ninja Cat Footsteps/Ninja cat footstep 4") as AudioClip);
        movementSounds.Add(Resources.Load("Sounds/Ninja Cat Footsteps/Ninja Cat Footstep one") as AudioClip);

        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/Cat damage 1") as AudioClip);
        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/cat damage 2") as AudioClip);
        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/cat damage 3") as AudioClip);
        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/cat damage 4") as AudioClip);
        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/cat damage 5") as AudioClip);
        damageSounds.Add(Resources.Load("Sounds/Ninja Cat Takes Damage-Impact/cat damage 6") as AudioClip);
    }

    void Update() {
        if(playerMovement == null || audioSource == null) {
            return;
        }

        if (!isMovementSoundLocked && playerMovement.isGrounded()) {
            isMovementSoundLocked = true;
            PlayMovementSound();
            StartCoroutine(LockMovementSound(movementSoundInterval));
        }
    }

    private IEnumerator LockMovementSound (float time) {
        yield return new WaitForSeconds (time);
        isMovementSoundLocked = false;
    }

    private void PlayMovementSound() {
        audioSource.volume = movementSoundVolume;
        int index = (int)(Random.value * movementSounds.Count);
        audioSource.PlayOneShot(movementSounds[index]);
    }

    public void PlayDamageSound() {
        audioSource.volume = damageSoundVolume;
        int index = (int)(Random.value * damageSounds.Count);
        audioSource.PlayOneShot(damageSounds[index]);
    }
}

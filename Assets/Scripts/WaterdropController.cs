using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterdropController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip catchClip;
    public AudioClip landClip;

    public SoundsController soundsController;
    public GameMaster gameMaster;
    public CloudController cloudController;

    public bool isDirty = false;
    public bool isDiamond = false;

    public float movementSpeedMultiplier = 1;

    float movementSpeed;

    void Start()
    {
        audioSource = GameObject.FindWithTag("GameMaster").GetComponent<AudioSource>();
        soundsController = GameObject.FindWithTag("GameMaster").GetComponent<SoundsController>();
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

        movementSpeed = cloudController.waterdropMovementSpeed;
        movementSpeed *= movementSpeedMultiplier;
    }

    void Update()
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime);
        }

        if (transform.position.y < -5)
        {
            audioSource.volume = soundsController.soundEffectsVolume;
            audioSource.PlayOneShot(landClip);

            if (isDirty == false && isDiamond == false)
            {
                gameMaster.DamagePlayer(1);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameMaster.gamePaused == false && gameMaster.gameOn == true)
        {
            if (collision.gameObject.tag == "Bowl")
            {
                audioSource.volume = soundsController.soundEffectsVolume;
                audioSource.PlayOneShot(catchClip);

                if (isDiamond == true)
                {
                    gameMaster.AddDiamonds(1);
                }
                else if (isDirty == true)
                {
                    gameMaster.DamagePlayer(1);
                }
                else
                {
                    gameMaster.AddScore(1);
                }
                Destroy(gameObject);
            }
        }
    }
}

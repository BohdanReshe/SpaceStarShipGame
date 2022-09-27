using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float downBound = -1;
    private float upBound = 8;
    private float xRange = 19;

    [Header("Speed of ship")]
    [SerializeField] float speed = 25;

    [SerializeField] GameObject projectilePrefab;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip[] launchSFx;

    [SerializeField] ParticleSystem explosionParticle;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < downBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, downBound);
        }

        if (transform.position.z > upBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upBound);
        }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * speed/2 * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                int i = Random.Range(0, launchSFx.Length);
                audioSource.PlayOneShot(launchSFx[i]);

                pooledProjectile.SetActive(true);
                pooledProjectile.transform.position = transform.position;

                uiManager.UpdateAmountOfMissiles();
                uiManager.UpdateAccuracy();
            }
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayParticle(Vector3 particlePosition)
    {
        Instantiate(explosionParticle, particlePosition, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heart"))
        {
            uiManager.UpdateAmountOfLives(1);
            Destroy(other.gameObject);
        }
    }
}
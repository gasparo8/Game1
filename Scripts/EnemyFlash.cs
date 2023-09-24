using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour
{

    [SerializeField] private EnemyFlash flashEffect;
    [SerializeField] private KeyCode flashKey;

    public Demon demon;

    //the SpriteRenderer that should flash
    private SpriteRenderer spriteRenderer;

    //Material in use when the script started.
    private Material originalMaterial;

    //Material to switch to for flash
    [SerializeField] private Material flashMaterial;

    //Duration of Flash
    [SerializeField] private float duration;

    //The currently running coroutine
    private Coroutine flashRoutine;



   // Start is called before the first frame update
   void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Gets the material that the SpriteRenderer uses, so we can switch after flash
        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flashKey))
        //if (demon.TakeDamage)
        {
            flashEffect.Flash();
        }
    }
    

    public void Flash()
    {
        //If the flash routine is not null, than it is currently running.
        if (flashRoutine != null)
        {
            //In this case, we should stop it first.
            // Multiple flashroutine the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }

        //Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        //Swap the flash material
        spriteRenderer.material = flashMaterial;

        //Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        //After the pause, swap back to the original material
        spriteRenderer.material = originalMaterial;

        //Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }
}

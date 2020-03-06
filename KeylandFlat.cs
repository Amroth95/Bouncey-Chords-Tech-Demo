using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeylandFlat : MonoBehaviour
{
    AudioSource Audiosource;
    Animation Animationsource;

    // Start is called before the first frame update
    void Start()
    {
      Audiosource = GetComponent<AudioSource>();
      Animationsource = GetComponent<Animation>();
      gameObject.GetComponent<Renderer>().material.color = Color.white;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Audiosource.Play();
        Animationsource.Play();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(ChangeColorBack());
    }

    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

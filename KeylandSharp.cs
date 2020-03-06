using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeylandSharp : MonoBehaviour
{
    AudioSource Audiosource;
    Animation Animationsource;

    // Start is called before the first frame update
    void Start()
    {
      Audiosource = GetComponent<AudioSource>();
      Animationsource = GetComponent<Animation>();
      gameObject.GetComponent<Renderer>().material.color = Color.black;

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
        gameObject.GetComponent<Renderer>().material.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

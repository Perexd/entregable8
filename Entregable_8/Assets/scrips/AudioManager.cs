using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] listaDeCanciones;
    private AudioSource source;

    private int CancionRep;

    public Text tituloCancion;
    private int FullLenght;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //cuando acaba una cancion se reproduce la siguiente
    IEnumerator FinCancion()
    {
        while (source.isPlaying)
        {
            yield return null;
        }
        Siguiente();
    }
    
    //en el tecto de abajo de los botones sale en nombre de la cancion
    public void CancioNombre()
    {
        tituloCancion.text = source.clip.name;
        
        FullLenght = (int)source.clip.length;
    }
    //reproduce la siguinte cancion de la lista
    public void Siguiente()
    {
        source.Stop();
        CancionRep++;
        if (CancionRep > listaDeCanciones.Length - 1)
        {
            CancionRep = 0;
        }
        source.clip = listaDeCanciones[CancionRep];
        source.Play();

        CancioNombre();

        StartCoroutine("FinCancion");
    }

    //reproduce la cancion anterior
    public void AnteriorCancion()
    {
        source.Stop();
        CancionRep--;
        if (CancionRep < 0)
        {
            CancionRep= listaDeCanciones.Length - 1;
        }
        source.clip = listaDeCanciones[CancionRep];
        source.Play();

        CancioNombre();

        StartCoroutine("FinCancion");
    }
    //inicia la reproducion
    public void Reproductor()
    {
        if (source.isPlaying)
        {
            return;
        }

        CancionRep--;
        if (CancionRep < 0)
        {
            CancionRep = listaDeCanciones.Length - 1;
        }
        StartCoroutine("FinCancion");
    }

    //cancion Aleatoria
    public void Aletorio()
    {
        source.clip = listaDeCanciones[Random.Range(0, listaDeCanciones.Length)];
        source.Play();

        CancioNombre();

        StartCoroutine("FinCancion");
    }

  //el boton de stop no me funcionaba 
    
}
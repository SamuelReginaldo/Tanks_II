using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class Script_Menu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumenMaster;
    public Slider volumenFX;
    public Toggle silenciar;

    private void Awake()
    {
        silenciar.onValueChanged.AddListener(silenciarMetodo);
        volumenMaster.onValueChanged.AddListener(cambiarVolumenMaster);
        volumenFX.onValueChanged.AddListener(cambiarVolumenFX);
    }
    public void EmpezarNivel(string NombreNivel)
    {   
        SceneManager.LoadScene(NombreNivel);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aquí se cierra el juego");
    }

    public void cambiarVolumenMaster(float v)
    {
        Debug.Log(v);
        mixer.SetFloat("volMaster", v);
    }
    public void cambiarVolumenFX(float v)
    {
        
        Debug.Log(v);
        mixer.SetFloat("volMusic", v);
    }
    public void silenciarMetodo(Boolean silenciar)
    {
        Debug.Log(silenciar);
        if (silenciar)
        {
            mixer.SetFloat("volMaster", -80);
        }
        else
        {
            mixer.SetFloat("volMaster", 0); 
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Script_Menu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumenMaster;
    public Slider volumenFX;
    public Toggle silenciar;

    private void Awake()
    {
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
        mixer.SetFloat("volMaster", v);
    }
    public void cambiarVolumenFX(float v)
    {
        mixer.SetFloat("volMusica", v);
    }
}

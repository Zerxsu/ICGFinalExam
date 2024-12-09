using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradingScript : MonoBehaviour
{
    //public Shader awesomeShader = null;
    public Material m_renderMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination0) 
    {
        Graphics.Blit(source, destination0, m_renderMaterial);
    }
}

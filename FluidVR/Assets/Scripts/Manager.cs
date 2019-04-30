using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public ParticleSystem[] particleSystemsArray;

    public float maxParticleSize = 0.5f;
    public float minParticleSize = 0.01f;
    public float maxParticleSpeed = 1f;
    public float minParticleSpeed = 0.01f;

    private GameObject settingsPanel;
    public GameObject[] settingsPanelArray;

    private ParticleSystem.MainModule main;
    private ParticleSystem.ShapeModule shape;
    private ParticleSystem.SizeBySpeedModule sizeBySpeed;
    private ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime;
    private ParticleLauncher launcher;
    private int index = 0;
    
    
    void Start()
    {
        particleSystem = particleSystemsArray[index];
        settingsPanel = settingsPanelArray[index];
        main = particleSystem.main;
        shape = particleSystem.shape;
        sizeBySpeed = particleSystem.sizeBySpeed;
        limitVelocityOverLifetime = particleSystem.limitVelocityOverLifetime;
        launcher = GetComponent<ParticleLauncher>();
    }


    public void ChangeParticleSystem()
    {
        if (index == 0)
        {
            index = 1;
        }
        else
        {
            index = 0;
        }

        bool isActive = settingsPanel.activeSelf;
        
        particleSystem = particleSystemsArray[index];
        
        settingsPanel.SetActive(false);
        settingsPanel = settingsPanelArray[index];
        if (isActive)
        {
            settingsPanel.SetActive(true);
        }
        
        main = particleSystem.main;
        shape = particleSystem.shape;
        sizeBySpeed = particleSystem.sizeBySpeed;
        limitVelocityOverLifetime = particleSystem.limitVelocityOverLifetime;
        launcher.UpdateParticleSystem();
    }

    public ParticleSystem GetCurrentParticleSystem()
    {
        return particleSystem;
    }

    public void ClearSpace()
    {
        foreach (ParticleSystem system in particleSystemsArray)
        {
            system.Clear();
        }
    }

    public void ChangeParticleSize(float value)
    {
        value = minParticleSize + (maxParticleSize - minParticleSize) * value;
        main.startSize = new ParticleSystem.MinMaxCurve(minParticleSize, value);
    }

    public void ChangeParticleNumber(float value)
    {
        launcher.numParticles = Mathf.CeilToInt(value);
    }

    public void ChangeParticleDiffusion(float value)
    {
        value = minParticleSpeed + (maxParticleSpeed - minParticleSpeed) * value;
        main.startSpeed = new ParticleSystem.MinMaxCurve(minParticleSpeed, value);
        sizeBySpeed.range = new Vector2(0, value);
        limitVelocityOverLifetime.limit = new ParticleSystem.MinMaxCurve(0, value);
    }

    public void ChangeColor(Color color)
    {
        main.startColor = color;
    }

    public void ChangeBrushType(float value)
    {
        int v = (int) value;

        shape.radius = 0.1f;
        ChangeBrushScale(1f);
        
        if (v == 0)
        {
            shape.shapeType = ParticleSystemShapeType.SingleSidedEdge;
            shape.radius = 0.5f;
        }
        else if (v == 1)
        {
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.scale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (v == 2)
        {
            shape.shapeType = ParticleSystemShapeType.BoxShell;
            shape.scale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (v == 3)
        {
            shape.shapeType = ParticleSystemShapeType.Circle;
        }
        else if (v == 4)
        {
            shape.shapeType = ParticleSystemShapeType.Sphere;
            shape.radius = 0.05f;
        }
    }

    public void ChangeBrushScale(float value)
    {
        if (shape.shapeType == ParticleSystemShapeType.BoxShell)
        {
            value *= 0.2f;
        }

        if (shape.shapeType == ParticleSystemShapeType.Sprite)
        {
            value *= 0.2f;
        }
        
        shape.scale = new Vector3(value, value, value);
    }
}

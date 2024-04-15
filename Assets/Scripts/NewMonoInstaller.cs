using UnityEngine;
using Zenject;

public class NewMonoInstaller : MonoInstaller
{
    [SerializeField] private Camera _uiCamera;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_uiCamera).AsSingle();
    }
}
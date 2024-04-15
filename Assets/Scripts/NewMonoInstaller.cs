using UnityEngine;
using Zenject;

public class NewMonoInstaller : MonoInstaller
{
    [SerializeField] private Camera _uiCamera;
    [SerializeField] private OfferPanel _validatableOfferPanel;

    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_uiCamera).AsSingle();
        Container.Bind<OfferPanel>().FromInstance(_validatableOfferPanel).AsSingle();
    }
}
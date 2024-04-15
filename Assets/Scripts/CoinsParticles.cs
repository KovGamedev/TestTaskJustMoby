using Newtonsoft.Json.Linq;
using UnityEngine;
using Zenject;

public class CoinsParticles : MonoBehaviour
{
    private Camera _uiCamera;
    private RectTransform _rectTransform;
    private ParticleSystem _particles;

    [Inject]
    public void Construct(Camera uiCamera)
    {
        _uiCamera = uiCamera;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _particles = GetComponent<ParticleSystem>();
    }

    public void Spread()
    {
        var mouseRay = _uiCamera.ScreenPointToRay(Input.mousePosition);
        _rectTransform.position = mouseRay.GetPoint(transform.parent.position.z - 1);
        _particles.Play();
    }
}

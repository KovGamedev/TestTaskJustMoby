using UnityEngine;

public class CoinsParticles : MonoBehaviour
{
    [SerializeField] private Camera _uiCamera;

    private RectTransform _rectTransform;
    private ParticleSystem _particles;

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

using UnityEngine.Audio;
using UnityEngine;

public class ExplodedObstacle : MonoBehaviour
{
  //public PlayerMovement playerMovement;
    public GameObject originalObstacle;
    public GameObject explodedObstacle;
    public ParticleSystem particleSystemPrefab;


    //[SerializeField] ParticleSystem _system;
    [SerializeField] private bool _broken;


    public float minForce = 2;
    public float maxForce = 20;
    public float explosionRadius = 10;

    public  void Explode()
    {
        if (_broken) return;
        _broken = true;
        Instantiate(explodedObstacle, transform.position, Quaternion.identity);
        Destroy(originalObstacle);
        
      var rbs = explodedObstacle.GetComponentsInChildren<Rigidbody>();
      foreach (var rb in rbs)
      {
          rb.AddExplosionForce(Random.Range(minForce, maxForce), explodedObstacle.transform.position, explosionRadius);
            Destroy(rb);

        }
  //    var exp = GetComponentInParent<ParticleSystem>(); 
//      exp.Play();

    //  Destroy(explodedObstacle, 1.5f);

        GameObject instantiated_GO = Instantiate(explodedObstacle);
        particleSystemPrefab.GetComponent<ParticleSystem>().Play();
        Destroy(instantiated_GO, 1.5f);

        ParticleSystem instantiated_PS = Instantiate(particleSystemPrefab);
        instantiated_PS.Play();
        Destroy(instantiated_PS.gameObject, 0.5f);
    }






    


// Within some method

}

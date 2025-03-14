using UnityEngine;
using UnityEngine.Events;


public class BallController : MonoBehaviour
  {
  [SerializeField] private float force = 1f;
  [SerializeField] private Transform ballAnchor;
  [SerializeField] private Transform launchIndicator;


    private bool isBallLaunched;
  private Rigidbody ballRB;
  private InputManager inputManager;
 
  void Start()
  {
  ballRB = GetComponent<Rigidbody>();
  inputManager.OnSpacePressed.AddListener(LaunchBall);
  transform.parent = ballAnchor;
  transform.localPosition = Vector3.zero;
  ballRB.isKinematic = true;
   ResetBall();

    }

    public void ResetBall()
 {
  isBallLaunched = false;

  //We are setting the ball to be a Kinematic Body
  ballRB.isKinematic = true;
 
  launchIndicator.gameObject.SetActive(true);
  transform.parent = ballAnchor;
  transform.localPosition = Vector3.zero;
  }

private void LaunchBall()
  {
      if (isBallLaunched) return;
      isBallLaunched = true;
      transform.parent = null;
      ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
          launchIndicator.gameObject.SetActive(false);
    }
  }

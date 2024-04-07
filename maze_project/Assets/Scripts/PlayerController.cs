using UnityEngine;

namespace maze_game
{
    public class PlayerController : MonoBehaviour
    {
        private const float SPEED = 2.5f;
        private Rigidbody _body;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector2 force = transform.position;
            if(Input.GetAxis("Vertical") > 0.0f)
            {
                force += new Vector2(0.0f, SPEED * Time.fixedDeltaTime);
            }

            if (Input.GetAxis("Vertical") < 0.0f)
            {
                force += new Vector2(0.0f, -SPEED * Time.fixedDeltaTime);
            }

            if (Input.GetAxis("Horizontal") < 0.0f)
            {
                force += new Vector2(-SPEED * Time.fixedDeltaTime, 0.0f);
            }

            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                force += new Vector2(SPEED * Time.fixedDeltaTime, 0.0f);
            }

            _body.MovePosition(force);
        }
    }
}

using UnityEngine;

namespace maze_game.Managers
{
    public class EnvironmentManager : BaseManager
    {
        #region Private members
        [SerializeField]
        private Camera _camera;
        #endregion

        #region Methods
        public override void Init()
        {
            CurrentState = State.Initialized;
        }

        public void CenterMazeOnCamera(int rows, int cols)
        {
            _camera.transform.Translate(new Vector3(rows / 2, cols / 2));
        }
        #endregion
    }
}

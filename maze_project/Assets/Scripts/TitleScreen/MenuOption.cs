using UnityEngine;

namespace maze_game.TitleScreen
{
    public class MenuOption : MonoBehaviour
    {
        public enum AvailableOption { NewGame, LoadGame }

        [SerializeField]
        private Transform _cursor;
        [SerializeField]
        private AvailableOption _option;

        public AvailableOption Option { get { return _option; } }

        #region Unity Methods
        private void Awake()
        {
            if(!_cursor)
            {
                _cursor = transform.Find("Cursor");
            }
        }
        #endregion

        #region Methods
        public void Select()
        {
            _cursor.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            _cursor.gameObject.SetActive(false);
        }
        #endregion
    }
}

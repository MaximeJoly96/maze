using UnityEngine;

namespace maze_game.TitleScreen
{
    public class TitleScreenManager : MonoBehaviour
    {
        [SerializeField]
        private MenuOption _newGameOption;

        [SerializeField]
        private MenuOption _loadGameOption;

        public MenuOption.AvailableOption SelectedOption { get; private set; }

        #region Unity Methods
        private void Awake()
        {
            PutCursorOnNewGame();
        }

        private void Update()
        {
            if (Input.GetAxis("Vertical") > 0.0f)
            {
                PutCursorOnNewGame();
            }

            if (Input.GetAxis("Vertical") < 0.0f)
            {
                PutCursorOnLoadGame();
            }

            if(Input.GetButton("Submit"))
            {
                Debug.Log(SelectedOption);
            }
        }
        #endregion

        #region Methods
        private void PutCursorOnNewGame()
        {
            _newGameOption.Select();
            _loadGameOption.Unselect();

            SelectedOption = _newGameOption.Option;
        }

        private void PutCursorOnLoadGame()
        {
            _newGameOption.Unselect();
            _loadGameOption.Select();

            SelectedOption = _loadGameOption.Option;
        }
        #endregion
    }
}

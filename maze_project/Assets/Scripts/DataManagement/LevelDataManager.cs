using UnityEngine;

namespace maze_game.DataManagement
{
    public static class LevelDataManager
    {
        #region Constants
        public static readonly string CELL_KEYWORD = "cell";
        public static readonly string START_KEYWORD = "start";
        public static readonly string EXIT_KEYWORD = "exit";
        public static readonly char SEPARATOR = '#';

        public static string SAVES_PATH { get { return Application.persistentDataPath + "/Saves/"; } }
        public static readonly string SAVE_FILE_NAME = "save.mz";
        #endregion
    }
}

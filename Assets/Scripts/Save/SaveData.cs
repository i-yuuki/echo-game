using System;

namespace Echo{
    // 仮セーブ
    [Serializable]
    public sealed class SaveData{

        public long playCount = 0;
        public int levelsCompleted = 0;
        public int health = 4;
        public int maxHealth = 4;

    }
}

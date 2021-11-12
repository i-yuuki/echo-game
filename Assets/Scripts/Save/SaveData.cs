using System;

namespace Echo{
    // 仮セーブ
    [Serializable]
    public sealed class SaveData{

        public int levelsCompleted = 0;
        public bool isFinalBossUnlocked = false;
        public int health = 4;
        public int maxHealth = 4;

    }
}

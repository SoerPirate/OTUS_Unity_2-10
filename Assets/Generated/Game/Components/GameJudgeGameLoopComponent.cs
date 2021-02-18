//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public JudgeGameLoopComponent judgeGameLoop { get { return (JudgeGameLoopComponent)GetComponent(GameComponentsLookup.JudgeGameLoop); } }
    public bool hasJudgeGameLoop { get { return HasComponent(GameComponentsLookup.JudgeGameLoop); } }

    public void AddJudgeGameLoop(int newEnemyCount) {
        var index = GameComponentsLookup.JudgeGameLoop;
        var component = (JudgeGameLoopComponent)CreateComponent(index, typeof(JudgeGameLoopComponent));
        component.enemyCount = newEnemyCount;
        AddComponent(index, component);
    }

    public void ReplaceJudgeGameLoop(int newEnemyCount) {
        var index = GameComponentsLookup.JudgeGameLoop;
        var component = (JudgeGameLoopComponent)CreateComponent(index, typeof(JudgeGameLoopComponent));
        component.enemyCount = newEnemyCount;
        ReplaceComponent(index, component);
    }

    public void RemoveJudgeGameLoop() {
        RemoveComponent(GameComponentsLookup.JudgeGameLoop);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherJudgeGameLoop;

    public static Entitas.IMatcher<GameEntity> JudgeGameLoop {
        get {
            if (_matcherJudgeGameLoop == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JudgeGameLoop);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJudgeGameLoop = matcher;
            }

            return _matcherJudgeGameLoop;
        }
    }
}
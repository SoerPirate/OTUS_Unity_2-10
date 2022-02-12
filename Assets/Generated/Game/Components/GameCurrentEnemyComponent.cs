//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly CurrentEnemyComponent currentEnemyComponent = new CurrentEnemyComponent();

    public bool isCurrentEnemy {
        get { return HasComponent(GameComponentsLookup.CurrentEnemy); }
        set {
            if (value != isCurrentEnemy) {
                var index = GameComponentsLookup.CurrentEnemy;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : currentEnemyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentEnemy;

    public static Entitas.IMatcher<GameEntity> CurrentEnemy {
        get {
            if (_matcherCurrentEnemy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentEnemy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentEnemy = matcher;
            }

            return _matcherCurrentEnemy;
        }
    }
}
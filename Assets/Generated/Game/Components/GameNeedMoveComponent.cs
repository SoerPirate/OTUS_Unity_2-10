//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NeedMoveComponent needMoveComponent = new NeedMoveComponent();

    public bool isNeedMove {
        get { return HasComponent(GameComponentsLookup.NeedMove); }
        set {
            if (value != isNeedMove) {
                var index = GameComponentsLookup.NeedMove;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : needMoveComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherNeedMove;

    public static Entitas.IMatcher<GameEntity> NeedMove {
        get {
            if (_matcherNeedMove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NeedMove);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNeedMove = matcher;
            }

            return _matcherNeedMove;
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Debug2Component debug2Component = new Debug2Component();

    public bool isDebug2 {
        get { return HasComponent(GameComponentsLookup.Debug2); }
        set {
            if (value != isDebug2) {
                var index = GameComponentsLookup.Debug2;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : debug2Component;

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

    static Entitas.IMatcher<GameEntity> _matcherDebug2;

    public static Entitas.IMatcher<GameEntity> Debug2 {
        get {
            if (_matcherDebug2 == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Debug2);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDebug2 = matcher;
            }

            return _matcherDebug2;
        }
    }
}
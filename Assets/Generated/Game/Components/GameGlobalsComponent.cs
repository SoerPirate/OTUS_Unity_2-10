//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity globalsEntity { get { return GetGroup(GameMatcher.Globals).GetSingleEntity(); } }
    public GlobalsComponent globals { get { return globalsEntity.globals; } }
    public bool hasGlobals { get { return globalsEntity != null; } }

    public GameEntity SetGlobals(float newSpeed, GameEntity newCurrentPlayer, GameEntity newCurrentEnemy, GameEntity newPlayerTarget, GameEntity newEnemyTarget, bool newNowPlayerTurn, bool newNowEnemуTurn, bool newNeedFindCurrentPlayer, bool newNeedFindCurrentEnemy, bool newNeedFillPlayerTarget, bool newNeedFillEnemyTarget, bool newNextTargetButton, bool newAttackButton, int newCurrentEnemyIndex, bool newChangeDeadEnemy, bool newChangeDeadPlayer, UnityEngine.CanvasGroup newPlayerMenu, int newEnemyCount, int newPlayerCount) {
        if (hasGlobals) {
            throw new Entitas.EntitasException("Could not set Globals!\n" + this + " already has an entity with GlobalsComponent!",
                "You should check if the context already has a globalsEntity before setting it or use context.ReplaceGlobals().");
        }
        var entity = CreateEntity();
        entity.AddGlobals(newSpeed, newCurrentPlayer, newCurrentEnemy, newPlayerTarget, newEnemyTarget, newNowPlayerTurn, newNowEnemуTurn, newNeedFindCurrentPlayer, newNeedFindCurrentEnemy, newNeedFillPlayerTarget, newNeedFillEnemyTarget, newNextTargetButton, newAttackButton, newCurrentEnemyIndex, newChangeDeadEnemy, newChangeDeadPlayer, newPlayerMenu, newEnemyCount, newPlayerCount);
        return entity;
    }

    public void ReplaceGlobals(float newSpeed, GameEntity newCurrentPlayer, GameEntity newCurrentEnemy, GameEntity newPlayerTarget, GameEntity newEnemyTarget, bool newNowPlayerTurn, bool newNowEnemуTurn, bool newNeedFindCurrentPlayer, bool newNeedFindCurrentEnemy, bool newNeedFillPlayerTarget, bool newNeedFillEnemyTarget, bool newNextTargetButton, bool newAttackButton, int newCurrentEnemyIndex, bool newChangeDeadEnemy, bool newChangeDeadPlayer, UnityEngine.CanvasGroup newPlayerMenu, int newEnemyCount, int newPlayerCount) {
        var entity = globalsEntity;
        if (entity == null) {
            entity = SetGlobals(newSpeed, newCurrentPlayer, newCurrentEnemy, newPlayerTarget, newEnemyTarget, newNowPlayerTurn, newNowEnemуTurn, newNeedFindCurrentPlayer, newNeedFindCurrentEnemy, newNeedFillPlayerTarget, newNeedFillEnemyTarget, newNextTargetButton, newAttackButton, newCurrentEnemyIndex, newChangeDeadEnemy, newChangeDeadPlayer, newPlayerMenu, newEnemyCount, newPlayerCount);
        } else {
            entity.ReplaceGlobals(newSpeed, newCurrentPlayer, newCurrentEnemy, newPlayerTarget, newEnemyTarget, newNowPlayerTurn, newNowEnemуTurn, newNeedFindCurrentPlayer, newNeedFindCurrentEnemy, newNeedFillPlayerTarget, newNeedFillEnemyTarget, newNextTargetButton, newAttackButton, newCurrentEnemyIndex, newChangeDeadEnemy, newChangeDeadPlayer, newPlayerMenu, newEnemyCount, newPlayerCount);
        }
    }

    public void RemoveGlobals() {
        globalsEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GlobalsComponent globals { get { return (GlobalsComponent)GetComponent(GameComponentsLookup.Globals); } }
    public bool hasGlobals { get { return HasComponent(GameComponentsLookup.Globals); } }

    public void AddGlobals(float newSpeed, GameEntity newCurrentPlayer, GameEntity newCurrentEnemy, GameEntity newPlayerTarget, GameEntity newEnemyTarget, bool newNowPlayerTurn, bool newNowEnemуTurn, bool newNeedFindCurrentPlayer, bool newNeedFindCurrentEnemy, bool newNeedFillPlayerTarget, bool newNeedFillEnemyTarget, bool newNextTargetButton, bool newAttackButton, int newCurrentEnemyIndex, bool newChangeDeadEnemy, bool newChangeDeadPlayer, UnityEngine.CanvasGroup newPlayerMenu, int newEnemyCount, int newPlayerCount) {
        var index = GameComponentsLookup.Globals;
        var component = (GlobalsComponent)CreateComponent(index, typeof(GlobalsComponent));
        component.speed = newSpeed;
        component.currentPlayer = newCurrentPlayer;
        component.currentEnemy = newCurrentEnemy;
        component.playerTarget = newPlayerTarget;
        component.enemyTarget = newEnemyTarget;
        component.nowPlayerTurn = newNowPlayerTurn;
        component.nowEnemуTurn = newNowEnemуTurn;
        component.needFindCurrentPlayer = newNeedFindCurrentPlayer;
        component.needFindCurrentEnemy = newNeedFindCurrentEnemy;
        component.needFillPlayerTarget = newNeedFillPlayerTarget;
        component.needFillEnemyTarget = newNeedFillEnemyTarget;
        component.nextTargetButton = newNextTargetButton;
        component.attackButton = newAttackButton;
        component.currentEnemyIndex = newCurrentEnemyIndex;
        component.changeDeadEnemy = newChangeDeadEnemy;
        component.changeDeadPlayer = newChangeDeadPlayer;
        component.playerMenu = newPlayerMenu;
        component.enemyCount = newEnemyCount;
        component.playerCount = newPlayerCount;
        AddComponent(index, component);
    }

    public void ReplaceGlobals(float newSpeed, GameEntity newCurrentPlayer, GameEntity newCurrentEnemy, GameEntity newPlayerTarget, GameEntity newEnemyTarget, bool newNowPlayerTurn, bool newNowEnemуTurn, bool newNeedFindCurrentPlayer, bool newNeedFindCurrentEnemy, bool newNeedFillPlayerTarget, bool newNeedFillEnemyTarget, bool newNextTargetButton, bool newAttackButton, int newCurrentEnemyIndex, bool newChangeDeadEnemy, bool newChangeDeadPlayer, UnityEngine.CanvasGroup newPlayerMenu, int newEnemyCount, int newPlayerCount) {
        var index = GameComponentsLookup.Globals;
        var component = (GlobalsComponent)CreateComponent(index, typeof(GlobalsComponent));
        component.speed = newSpeed;
        component.currentPlayer = newCurrentPlayer;
        component.currentEnemy = newCurrentEnemy;
        component.playerTarget = newPlayerTarget;
        component.enemyTarget = newEnemyTarget;
        component.nowPlayerTurn = newNowPlayerTurn;
        component.nowEnemуTurn = newNowEnemуTurn;
        component.needFindCurrentPlayer = newNeedFindCurrentPlayer;
        component.needFindCurrentEnemy = newNeedFindCurrentEnemy;
        component.needFillPlayerTarget = newNeedFillPlayerTarget;
        component.needFillEnemyTarget = newNeedFillEnemyTarget;
        component.nextTargetButton = newNextTargetButton;
        component.attackButton = newAttackButton;
        component.currentEnemyIndex = newCurrentEnemyIndex;
        component.changeDeadEnemy = newChangeDeadEnemy;
        component.changeDeadPlayer = newChangeDeadPlayer;
        component.playerMenu = newPlayerMenu;
        component.enemyCount = newEnemyCount;
        component.playerCount = newPlayerCount;
        ReplaceComponent(index, component);
    }

    public void RemoveGlobals() {
        RemoveComponent(GameComponentsLookup.Globals);
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

    static Entitas.IMatcher<GameEntity> _matcherGlobals;

    public static Entitas.IMatcher<GameEntity> Globals {
        get {
            if (_matcherGlobals == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Globals);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGlobals = matcher;
            }

            return _matcherGlobals;
        }
    }
}

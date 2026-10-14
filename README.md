# Clicker & Auto-Collect — Zenject test task

A tap-to-earn clicker with passive auto-collect, built with **Zenject** and **UniTask**.

## Task

- Tapping the clicker spends energy and grants soft currency, with a floating number animation
- Auto-collect grants X currency every N seconds
- Optional: 10% of the auto-collect amount is added to every tap
- All values are configured by game designers in a ScriptableObject

## Implementation

**Composition root.** `GameInstaller` (Zenject `MonoInstaller`) binds the settings, services and views; coin popups are created through a Zenject factory.

**Game logic lives in plain C# services**, separate from MonoBehaviour views:

| Service | Responsibility |
|---|---|
| `TapManager` | Handles a tap: checks energy, calculates the reward, updates the balance, spawns a popup |
| `AutoCollector` | UniTask loop that adds currency every N ms |
| `EnergyController` | Energy pool; every tap spends a configurable share, taps are blocked at zero |
| `CountdownTimer` (`ITickable`) | Resets the per-period tap income every T seconds |

**Views** only display data and forward input: `ClickerObject`, `CurrencyView`, `EnergyBarView`, `CoinSpawner` / `CoinsView` (floating popup animated with UniTask).

**Balance** is set in `GameSettings` (ScriptableObject): base reward per tap, tap modifier, period T and divisor, energy cost per tap, auto-collect interval and amount, bonus percent and an on/off toggle. The tap reward is calculated in `GameSettings.EarnPerTap`.

## Why this approach

- **Plain C# services with constructor injection** — logic doesn't depend on scene objects, dependencies are explicit, and the classes are easy to unit-test.
- **Thin views** — visuals can change without touching game logic.
- **One ScriptableObject for all numbers** — designers tune the balance without code changes.
- **UniTask for timers and animations** — async loops work in plain classes, where coroutines are not available.

## Running

- Unity **2022.3.50f1**
- Open the `Clicker/` folder in Unity Hub, then `Assets/Scenes/MainScene.unity`

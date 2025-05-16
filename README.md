# Arissa’s Destiny

> **Embark on a magical journey** with Arissa—a Unity-powered educational RPG that teaches core game mechanics through interactive lessons and animations.

---

## 🎯 Project Overview

Arissa’s Destiny is a tutorial-focused Unity project designed to guide developers (and players) through fundamental game development concepts:

1. **Scene & Level Design Lessons**: Step-by-step tutorials teaching scene transitions, environment setup, and level progression.
2. **Character Movement & Animations**: Implementing `Animator` and `AnimationController` for idle, walk, run, and attack states.
3. **Game Flow Management**: Using `GameManager` and `LessonManager` scripts to orchestrate lesson sequences, UI prompts, and player guidance.
4. **UI & Input Handling**: Crafting intuitive menus, HUD elements, and touch/keyboard controls.

> **Target Audience:** Unity beginners and intermediate developers seeking hands-on examples of animations, scripting patterns, and lesson-driven gameplay.

---

## 📁 Project Structure

```
Arissa-s-Destiny/
├── Assets/
│   ├── Scenes/                 # Unity scene files (.unity)
│   │   ├── MainMenu.unity      # Entry point with navigation UI
│   │   ├── Lesson1.unity       # Lesson: Scene setup & camera control
│   │   ├── Lesson2.unity       # Lesson: Character movement & animation
│   │   └── BattleScene.unity   # Demo combat with attack animations
│   ├── Scripts/                # C# scripts for game logic
│   │   ├── GameManager.cs      # Singleton managing global game state
│   │   ├── LessonManager.cs    # Controls lesson flow and triggers
│   │   ├── PlayerController.cs # Movement, input, and physics
│   │   ├── UIController.cs     # Handles menu/navigation and HUD
│   │   └── AnimationHandler.cs # Maps input to Animator states
│   ├── Animations/             # AnimationClips and AnimatorControllers
│   │   ├── Arissa_Idle.anim
│   │   ├── Arissa_Run.anim
│   │   ├── Arissa_Attack.anim
│   │   └── Arissa_Controller.controller
│   ├── Prefabs/                # Reusable GameObjects
│   │   ├── Player.prefab
│   │   ├── UI_Canvas.prefab
│   │   └── LessonPopup.prefab
│   ├── UI/                      # UI assets (images, fonts)
│   └── Audio/                   # Background music & SFX
├── ProjectSettings/             # Unity-generated project settings
├── README.md                    # (this file)
└── LICENSE                      # MIT License
```

---

## 🛠️ Prerequisites & Setup

1. **Unity Version**: 2021.3 LTS or newer.
2. **IDE**: Visual Studio 2019+ or Rider with Unity support.
3. **Mobile Modules** (optional): Android/iOS via Unity Hub if targeting devices.

**Open Project**:

```bash
git clone https://github.com/Tharindu714/Arissa-s-Destiny.git
# In Unity Hub: "Add" this folder → Open.
```

---

## 🌟 Core Components & Scripts

### 1. GameManager.cs

* **Pattern**: Singleton (`DontDestroyOnLoad`).
* **Responsibilities**:

  * Store persistent data (player progress, settings).
  * Load scenes and manage global state transitions.

```csharp
public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    void Awake() {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }
    public void StartGame() => SceneManager.LoadScene("Lesson1");
}
```

### 2. LessonManager.cs

* **Manages** tutorial steps within each scene.
* **Uses** coroutines to sequence popups and wait for player actions.

```csharp
public class LessonManager : MonoBehaviour {
    public GameObject popupPrefab;
    IEnumerator Start() {
        yield return ShowStep("Welcome to Lesson 1: Camera Control");
        // Wait for user to click Continue...
        yield return ShowStep("Use WASD or arrow keys to move the camera.");
    }
}
```

### 3. PlayerController.cs

* **Handles** input (keyboard/touch) and applies to **Rigidbody** physics.
* **Triggers** animation states via `AnimationHandler`.

```csharp
void Update() {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    Vector3 move = new Vector3(h, 0, v);
    rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    animHandler.SetMovement(move.magnitude);
}
```

### 4. AnimationHandler.cs

* **Interfaces** with the **Animator** component.
* **Parameters**: `Speed` (float), `Attack` (trigger).

```csharp
public void SetMovement(float speed) {
    animator.SetFloat("Speed", speed);
}
public void Attack() {
    animator.SetTrigger("Attack");
}
```

### 5. UIController.cs

* **Navigates** between menu screens and in-game HUD.
* **Methods** bound to UI Buttons (e.g., `OnStartClicked()`, `OnQuitClicked()`).

```csharp
public void OnStartClicked() => GameManager.Instance.StartGame();
public void OnQuitClicked() => Application.Quit();
```

---

## 📚 Lessons & Scenes

| Scene         | Focus                                 | Key Components                |
| ------------- | ------------------------------------- | ----------------------------- |
| `MainMenu`    | Entry navigation                      | UIController, Canvas, Buttons |
| `Lesson1`     | Camera controls and environment setup | LessonManager, free camera    |
| `Lesson2`     | Character movement & animations       | PlayerController, Animator    |
| `BattleScene` | Basic combat demo with attack states  | AnimationHandler, health UI   |

Each scene includes a **LessonPopup.prefab** to guide the player, instantiated by `LessonManager`.

---

## 🔄 Animation Workflow

1. **Animator Controller**: Defines states (`Idle`, `Run`, `Attack`) and transitions based on parameters.
2. **Blend Tree**: Smoothly transitions between idle and run based on `Speed`.
3. **Animation Clips**: Imported from `Animations/`, configured in **AnimationWindow**.
4. **Event Hooks**: Use animation events to trigger sound effects (via `AudioSource.PlayOneShot`).

---

## 🚀 Running & Testing

* **Play Mode**: Click **Play** in Unity Editor to test scenes interactively.
* **Build Settings**: File ▶ Build Settings ▶ Add scenes, select platform, and **Build & Run**.
* **Profiler**: Window ▶ Analysis ▶ Profiler to inspect performance and memory.

---

## 🛠️ Extending Arissa’s Destiny

* **Add More Lessons**: Create new scenes and extend `LessonManager` coroutines.
* **Enhance Combat**: Implement health systems, UI bars, and enemy AI.
* **Save Progress**: Integrate **PlayerPrefs** or **ScriptableObjects** for persistence.
* **Mobile Controls**: Add **Touch Input** support with on-screen joysticks.

---
## 🛠️ Screenshots of the making of game

**Unity Game Designing Screenshot**
![image](https://github.com/user-attachments/assets/e50676a9-b938-4913-a6f7-26f80ee9c1fe)

**Gameplay Simulation View**
![image](https://github.com/user-attachments/assets/eb5a0521-d67c-4d89-bace-08ac7b01e63b)

**Player Idel Pose Gameplay**
![image](https://github.com/user-attachments/assets/8cb3464b-6102-473a-8d9d-8b72336b9ed9)

**Player Fast Run Pose Gameplay**
![image](https://github.com/user-attachments/assets/b49ce4ba-4dd3-4982-a5bc-ca9ec1d01c15)

**Enemy Design and Animation**
![image](https://github.com/user-attachments/assets/8f235239-a62c-47af-8d8c-896ce35a081d)

**New Features**
![New1](https://github.com/user-attachments/assets/485f1fc6-c032-474f-99e6-c59d079e448a)
![New2](https://github.com/user-attachments/assets/bc743808-dc45-4df9-bb6b-4c7373c2ebde)

---
## 🤝 Contributing

Contributions welcome! Please fork the repo, create a feature branch, and submit a pull request.

---

## 📄 License

MIT © Tharindu714

 

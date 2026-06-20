# Q-Learning Reinforcement

**Q-Learning reinforcement learning agent visualization in C# WinForms. An agent learns optimal paths through a randomly-connected room environment using temporal difference learning.**

## Features

- **Room-Based Environment**: Configurable number of rooms graphically arranged in a grid layout
- **Random Path Generation**: Bidirectional paths between neighboring rooms created randomly
- **Q-Learning Agent**: Tabular Q-Learning with epsilon-greedy exploration
- **Visual Training**: Click to train the agent over multiple episodes
- **Path Display**: After learning, click to find and visualize the optimal path from start to goal
- **Step-by-Step Path Log**: Rich text box shows the sequence of rooms traversed

## Project Structure

```
q-learning-reinforcement/
├── QLearning_1.sln
├── QLearning_1/
│   ├── Form1.cs              # Main form: environment, Q-learning, visualization
│   ├── Form1.Designer.cs     # Designer-generated layout
│   ├── Program.cs            # Application entry point
│   └── Properties/
│       ├── AssemblyInfo.cs
│       ├── Resources.Designer.cs
│       └── Settings.Designer.cs
└── README.md
```

## System Architecture

```mermaid
flowchart TD
    subgraph Environment
        A[Room Layout<br>Grid-based positions]
        B[Reward Matrix R(s,a)<br>-1: no connection<br>0: connected<br>100: goal connection]
    end
    
    subgraph Agent
        C[Q-Table Q(s,a)<br>Initialized to 0]
        D[Epsilon-greedy<br>Action Selection]
        E[Q-Value Update:<br>Q = R + γ·maxQ']
    end
    
    subgraph Visualization
        F[Room Circles<br>with numbers]
        G[Path Lines<br>Blue: connections<br>Red: chosen path]
        H[Path Log<br>Text output]
    end
    
    A --> B
    B --> C
    C --> D
    D --> E
    E --> C
    C --> G
    C --> H
    F --> G
```

## Core Concepts

### Q-Learning

Q-Learning is a **model-free reinforcement learning** algorithm. The agent learns an optimal policy by interacting with the environment:

$$Q(s_t, a_t) \leftarrow Q(s_t, a_t) + \alpha \left[ R(s_t, a_t) + \gamma \max_{a'} Q(s_{t+1}, a') - Q(s_t, a_t) \right]$$

Where:
- **Q(s, a)**: Expected future reward for taking action `a` in state `s`
- **R(s, a)**: Immediate reward for action `a` in state `s`
- **α (alpha)**: Learning rate (how much new info overrides old)
- **γ (gamma)**: Discount factor (importance of future rewards)

Since this implementation uses `α = 1` (no learning rate parameter in the update formula), the simplified update becomes:

$$Q(s, a) = R(s, a) + \gamma \max_{a'} Q(s', a')$$

### Reward Matrix (R Table)

The R table defines the environment's reward structure:
- **R[s, a] = -1**: No connection between room `s` and room `a`
- **R[s, a] = 0**: Connected rooms (regular transition)
- **R[s, a] = 100**: Connection that leads directly **to the goal room**

### Algorithm Flow

```mermaid
flowchart TD
    A[Start: Generate room layout] --> B[Create random connections<br>between neighboring rooms]
    B --> C[Set goal room connections<br>R = 100 for goal-directed paths]
    C --> D[Training Loop:<br>N episodes]
    D --> E[Start in random room]
    E --> F{At goal?}
    F -->|Yes| G[Episode complete]
    G --> D
    F -->|No| H[Pick action:<br>random from available R > -1]
    H --> I[Compute max Q' for next state]
    I --> J[Update Q-table:<br>Q = R + γ·maxQ']
    J --> K[Move to next state]
    K --> F
    D --> L[Training complete]
    L --> M[Find Optimal Path:<br>Start → follow max Q until goal]
```

### Environment Layout

Rooms are arranged in a grid. Each room has up to 8 neighbors (cardinal + diagonal). The system randomly determines which connections exist (50% probability per potential connection).

```mermaid
graph TD
    subgraph "Example: 4 rooms"
        A[Room 1] --- B[Room 2]
        A --- C[Room 3]
        B --- D[Room 4]
        C --- D
    end
    style A fill:#4CAF90
    style B fill:#4CAF90
    style C fill:#4CAF90
    style D fill:#4CAF90,stroke:#f00,stroke-width:4px
```

### Key Data Structures

| Structure | Description |
|---|---|
| `yTablosu[,]` | `Yer[]` grid mapping rooms to pixel positions |
| `R_Tablosu[,]` | Reward matrix: R[from, to] = -1/0/100 |
| `Q_Tablosu[,]` | Q-value matrix learned during training |
| `Yer` class | Stores room `X`, `Y` pixel coordinates and `Deger` (room number) |

### Learning Process

1. Random start room selected
2. Agent picks an available action (room it's connected to)
3. If the next room connects to goal, reward is 100
4. Q-value updated using the Bellman equation
5. Repeat for configured number of episodes

### Path Finding

After training, to find the optimal path from start to goal:
1. Start at the given room
2. Select the action (next room) with the **highest Q-value** among connected rooms
3. Move to that room and repeat
4. Stop when reaching the goal

## How to Use

1. Configure number of rooms using numeric up-down
2. Set the goal room number
3. Set the start room number
4. Enter a learning rate (α)
5. Rooms and random connections are automatically drawn
6. Set the number of training episodes
7. Click **"Öğrenmeyi Başlat"** (Start Learning) to train
8. Click **"Yolu Bul"** (Find Path) to visualize the optimal route

## Building

Open `QLearning_1.sln` in Visual Studio 2008+ (retarget .NET Framework if needed) and build.

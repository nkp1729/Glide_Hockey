[//]: # (Image References)

[image1]: HockeyAnimation.gif "Trained Agent"



# Houston Machine Learning Meet Up : Glide Hockey

### Introduction

For this project, you will work creating a custom Hockey enviroment

![Trained Agent][image1]

In this environment, two agents control Glide hockey players to hit a puck towards a goal. If an agent hits the goal, it receives a reward.  Thus, the goal of each agent is to keep score as many goals as possible.

The observation space consists of 8 variables corresponding to the position and velocity of the puck and player. Each agent receives its own, local observation.  Two continuous actions are available.

The task is episodic, and in order to solve the environment, the agents must get an average score of +0.5 (over 100 consecutive episodes, after taking the maximum over both agents). Specifically,


- After each episode, we add up the rewards that each agent received (without discounting), to get a score for each agent. This yields 2 (potentially different) scores. We then take the maximum of these 2 scores.
- This yields a single **score** for each episode.

The environment is considered solved, when the average (over 100 episodes) of those **scores** is at least +0.5.

### Getting Started

1. Check [mlagents installation](https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation.md), and follow the instructions.

2. Install pytorch and its dependencies for your machine [pytorch](https://pytorch.org/). Its recomended to create a conda environment and activate this.

3. Clone this repository, change directory.
``` bash
git clone https://github.com/nkp1729/Glide_Hockey
```

3. Open Unity and open a new project pointing to the 'Hockey' folder.
![Add Folder][AddFolder.tiff]

4. Goto File -> Build settings. Then chose the appropriate output for your platform and build to 'AirHockey' in the top level of the folder '/Glide_Hockey'

![Build Settings][BuildSettings.tiff]


### Instructions

Follow the instructions in `GlideHockeyTraining.ipynb` to get started with training your own agent!  

# Ludum Dare 40
Repo for my Ludum Dare 40 Entry

This repo will be updated at each hour I am working on the project. An Inital Commit includes a Unity Project with a few settings to make getting going a little easier.


# Game Information
The More You Have the Worse It Is

The Papers

You are a hoarder of newspapers. Everyday you recieve a thing of papers, each day the amount increases as your addiction grows. Inside your room you have several furniture items. You have to leave your bed open to sleep each night, and your door open to recieve your next days worth of papers. You also have a ladder that allows you to reach the ceiling. The goal is to have as many newspapers as possible in your house while still being able to sleep each night. You can only lift so many papers at a time, and if a stack is to high and you bump into it it could fall over. Throughout the room there are various other furniture objects to cause more chaos. Occasionally things within your house will break. You must then call someone to fix it, but the worker has to be able to access the broken item. Examples of things that could break are light (dim lighting when trying to work), the heater (you start to slowly freeze to death until you can get it fixed), and a window (it will rain and destroy all the newspaper near the window, this won't end the game but will remove points). If papers are to close to the heater they will start a fire and your papers will start to burn away, there is a fire extinguisher. You also have a paper shreader, but there is a penalty when using it which has not yet been decided. You can increase the time before things break, if they break, by turning off the lights at night, and turning off the heater during the day.

You win the game by hitting a threshold of the optimal amount of newspapers, this will be figured out when the room is complete. You can lose by knocking over a stack, losing your entire collection, or not being able to sleep one night.

When the base game is done and working to a point I can say is good I will split it off and work on a version where rooms are randomly generated to give you a new challenge each game.

# Summary of Commits
# Inital Game Idea
Within this commit I outline my basic plans for the game. This is all I am doing for tonight as I worked all day, tomorrow morning I will start on building out the basic of the game, newspaper manipulation and sleeping.
# New Ideas
While in bed last night thought of a few more things that would be cool for the game. Ready to start the day!
# Basic Character and Paper Pickup
Woke up this morning and started right away. Unfortunatly I have work this morning so I have to stop after only an hour of work but good progress was made! I currently have a working character moving around and the ability to pick up newspapers. My next step will be making it so papers highlight when you can grab them. I also need to implement the point system, 1 point for everypaper that is stacked. Also while writing this I thought of a penalty for not sleeping, the longer you don't sleep more random it is to control the player.
# Highlighting and Scoring
Did this while at work. Allows for the papers to highlight to let you know what you are selecting and added a basic scoring system. Unfortunatly this does not 100% work as when papers fall over if they fall together it still counts as a stack.
# Added Door, Mat, and Bed
I removed the old scoring system, now it will be time based, you have to sleep in a certain amount of time, and the mail arrives at a certain time. I made it so you have to sleep to get a delivery, and each delivery has one more paper stack than the last. Next steps will be figuring out a sleep transition and setting up the timing.

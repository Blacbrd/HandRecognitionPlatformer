# HandRecognitionPlatformer
OCR A level (2024) comptuer science project that links hand recognition with 2D platforming

This program taught me how to use the Unity Game engine, how to use OpenCV Python, how to use gesture recognition with Google's MediaPipe, how to work with threading and how to work with network sockets (to communicate between 2 different programming languages).

This game is about a wizard that is trapped in a cave. They have to try and escape a series of puzzles to make their way out to the surface. They complete these puzzles by using their platforming skills, alongside their magical abilities: Fireball, a standard horizontally travelling projectile; WaterFountain, which is a rising platform of water and LightningBolt, a projectile that crashes down from the ceiling and dissapears when it comes into contact with the floor.

I had 1 year to complete this project, including forming an analysis, developing the program, formulating multiple test plans, receiving stakeholder feedback and then evaluating my code.

What you see in the files is the final state of the code for when I submitted the code. Due to time constraints, it may be messy, unoptimised, and have potential privacy issues (especially regarding the terminal commands). However, I ended up making something that I thought wasn't possible, therefore expanding my programming experience.

Synopsis of how program works:

* Player can move around and jump across the stage
* Camera can move from room to room as player traverses the stage
* Player can press the "J" and "K" key to summon a fireball and water platform respectively
* Player can press the "F" key to run the Hand recognition python program
* When F is pressed:
* C# opens new thread -> C# starts TCP server -> C# runs Python HandRecognition scripts in terminal -> Python opens socket server on same IP and Port -> HandRecognition program recognises Player's hand gesture -> Result sent from Python socket server over to the C# server -> Input recognised -> Spell is cast in Unity game

I do not plan on finishing this game, or improving the code, as I am currently working on other projects.

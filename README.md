# Engines-Lab-4-Exercise-2

For this exercise I have implemented a observer design pattern to play an audio source and a singleton pattern used to save the value of 
variable.

For the observer pattern, it will play an audio source when an object gets destroyed after the player has collided with it.
To achieve this I mainly refrenced the code from Parisa's lab 4 but added it to my own script.

In my 'PlayerMovement" script I have an action called destroyed which I invoke once the player has collided with an object.
Once the action is invoked, I use it to call the 'PlayAudio' function which causes the audio to play upon destroying the object.

For the singleton pattern, I used it to save the value of the players health after destroying a gameobject. This is script is mainly referenced from Parisa's
lab 4, however I made some slight adjusments. In my script, i set an integer value called health to 100 and converted it to text.

This text stores one instance of that variable and is used in a function called subtrcat health. This function is used to subtract the health based off 
the argument that is passed. 

Then, in my playermovement script, I call this function after the player collides with an object and pass the value 1 to the 'SubtractHelth' Function. From there, 
the player loses 1 health each time they collide with an object and only one instance of text is stored.

References: https://drive.google.com/file/d/1mKuH4BzcJgqX2wQFOKWYbX6r7i3cS7mQ/view

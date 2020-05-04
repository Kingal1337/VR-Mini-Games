Eddie Marrero Jr. Started 4/30/20 Last Updated 5/3/2020


Most elements of the game are complete and just need to be implemented into VR. 

Movement.cs and MouseLooker.cs are both temp scripts for movement that should be removed after vr is put in (movement with rigid body made it wierd anyways).

GameManager.cs has control of all basic functions

Skii ball scripts are under SkiiballRow>GameTable & balls

GameTrigger scripts are under Environment>GameTrigger

ClampName.cs requires there to be a tagged main camera

GameTrigger.cs requires there to be a tagged Player for animations to work properly

ScoreKeeper.cs requires there to be a tagged ball for score to work properly

I purposley created the skii ball table in blender to break into parts so you can easily interact with inteded parts.
Under the table's hierarchy it may look a bit messy but it was easier to leave it that way. If there is any graphics update or
adjustments needed to the skii ball table I can easily change it.

If you create an empty object as a root parent and scale down the world, the light will be off. I briefly tried messing with this,
but I was just thinking to scale the light intensity of each light by the same amount as the rest of the world. (if world scale is .2 multiply intensity by .2)

ArcadeMachines, TableTop Machines, and Skiiball tables labeled props are intended to be props that add life to the game.

I tried to write as many comments on the code as possible for simplicity's sake, if there are any questions I can try to explain to the best of my capabilities
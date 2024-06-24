
# Programmer Test - Hermit Crab Game Studio

Test of a programmer role at Hermit Crab Game Studio.

## Info
* Unity version: 2020.3.48f1
* Build Platform: Android
* Time spent: Around 25 hours

## Major difficulties

Without a doubt, my biggest difficulty at the beginning of development was to decide what the code structure would be, especially the character scripts (player and enemy). I knew that i should separate the behaviours in different modules/scripts, but how would them communicate with each other in a way that minimizes dependencies between them?

I decided then to create base classes to control these behaviours, such as animations, movement, actions and health. And derive these classes to the character. I also created a generic base class to control these behaviours, in a way that is easier to use into other characters such as the player and the enemies.

Basically the major difficulty of the development was the time spent thinking about what would be the best way to structure the project, considering the pros and cons of each approach.

## Project architecture

To structure the project, my mindset was to make it as scalable as possible, following mainly the Single Responsibility Principle, this way, I try to separate the responsibilities of scripts and methods as much as possible, making it easier to maintain and scale. I also try to avoid hard dependencies between classes in a way that most of the entities in the project are independent from other entities.

A design pattern that i normally use and used in the project is the Observer Pattern.
For exemple, to display the player's health, when receiving damage or being healed, an event is issued with the value of his health, this event is listened by the responsible UI component (health bar) and gets updated.

Another aspect of the project is that all the screens are separated in different scenes, this way I keep the scenes concise and there is a reduction in memory consumption, for example, the pause screen is only loaded into memory when the player actually pauses the game, and the same goes for the game over screens.

## Next updates

* Improve the player character's physics by applying concepts such as "coyote time" and "edge detection".
* Implement dependency injection through frameworks like Zenject.
* Refactor the organization of the character animator, or even use another solution to control the animations, as the Animator is a relatively expensive component, especially in a mobile game.
* Depending on the number and complexity of enemy states, apply the state pattern to better organize their behaviors.
* Depending on the number of enemies in the scene, it may be interesting to remove their life bar from the canvas and transfer it to the sprite renderer due to the draw calls performance.

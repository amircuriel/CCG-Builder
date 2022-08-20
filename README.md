# CCG-Builder
 A development-focused template of a collectible card game.
 
The goal of this project is to build a card game with an architectural design that is so modular and flexible, anyone could use it to:

1. Design a wide array of different cards using the game's base mechanics, and test them in play against another player.

2. Easily expand it with additional card types, mechanics and more, with little to no coding, in order to create a unique card game of their own.

To achieve that, I've taken the popular card game "Hearthstone" as a template, broke it down to its basic building blocks, and extracted from it a set of simple rules, mechanics and keywords which can be combined to define complex effects and interactions.
</br>This flexible foundation allows the game to support high levels of mechanical complexity out-of-the-box, while also allowing you to easily expand or change the rules in the future to support additional effects, mechanics, card types and more, without needing to re-write the whole architecture or add special cases for everything.

For more info, read this script:
</br>*[Triggered Effect](Assets/Scripts/Core%20Mechanics/TriggeredEffect.cs)*

Example of a card being designed in the inspector:
</br>(Currently WIP)
![](GitHub%20Metadata/Screenshot%201.png)
</br>Of course, in order to try and test everything, I've also created a basic gameplay demo that allows you to build a deck with all the cards you've created, and play with them against another player (on the same computer, currently), using the basic gameplay structure of the original game (alternating turns between players, win/lose condition based on the players' health, etc.).
</br>[This part is currently unfinished]

**Detailed explanation:**

I have designated an "Event" for every action in the game, such as playing a card, attacking, having something die, ending your turn, etc.

Every card in the game has a list of "Triggered Effects": Effects that are listening to a specific event from a specific origin, so that whenever that event is called from that origin, the attached effect is triggered.

It is built this way to homogenize all effects within the game and make them all follow the same process, whether they are a triggered once when you play the card, or called multiple times over the card's lifetime. 

For Example, a card with an effect that is listening to the **"OnPlay"** event could set its origin to **"This"**, so the card will trigger its effect when it is played from hand. However, if the event origin is set to **"Other"**, whenever the card is on the board (as a minion, for example) and another card is played, the effect will then trigger. This logic of course applies to all other types of events.

So whenever anything occurs in the game, a message is sent to the GameManager, which processes the event, and then to the EventManager, which notifies all active listeners of this event to check if the event origin matches theirs, and if so, the triggered effect is sent to the GameManager to be activated.
